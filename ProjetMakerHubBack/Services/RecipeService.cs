using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Validators;
using ProjetMakerHubBack.Domain.Entities;
using ProjetMakerHubBack.Domain.Enums;
using System.Security.Claims;

namespace ProjetMakerHubBack.API.Services
{
    public class RecipeService(AppDbContext _db)
    {
        /// <summary>
        /// Search recipes
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<RecipeSearchResponseDto>> SearchAsync(RecipeSearchRequestDto dto, Guid userId)
        {
            var query = _db.Recipes
                .AsNoTracking()
                .AsQueryable();

            // recette publique ou créée par moi
            query = query.Where(r => r.IsPublic || r.CreatedByUserId == userId);

            // recherche par nom via input
            if(!string.IsNullOrWhiteSpace(dto.Q))
            {
                var searchData = dto.Q.Trim();
                query = query.Where(r => r.Title.Contains(searchData));
            }

            // recherche par tag
            if(dto.TagIds != null && dto.TagIds.Count > 0)
            {
                query = query.Where(r => r.Tags.Any(t => dto.TagIds.Contains(t.Id)));
            }

            // recherche par favoris
            if (dto.Favorite)
            {
                query = query.Where(r => r.UserRecipes.Any(ur => ur.UserId == userId && ur.IsFavorite));
            }
            // recherche par perso
            if (dto.Mine)
            {
                query = query.Where(r => r.CreatedByUserId == userId);
            }

            return await query
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new RecipeSearchResponseDto
                {
                    Id = r.Id,
                    Title = r.Title,
                    CookTime = r.CookTime,
                    PrepTime = r.PrepTime,
                    IsPublic = r.IsPublic
                }).ToListAsync();
        }

        /// <summary>
        /// Create a recipe
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// 
        public async Task<Recipe> CreateAsync(RecipeCreateDto dto, Guid userId)
        {
            // Validations
            RecipeValidator.ValidateForCreate(dto);

            // creation d la recette
            var recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                BasePortion = dto.BasePortion,
                PrepTime = dto.PrepTime,
                CookTime = dto.CookTime,
                IsPublic = dto.IsPublic,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = userId
            };

            for (int i = 0; i < dto.Steps.Count; i++)
            {
                var steptext = dto.Steps[i];
                recipe.RecipeSteps.Add(new RecipeStep
                {
                    Id = Guid.NewGuid(),
                    StepNumber = i + 1,
                    StepInstruction = steptext,
                    RecipeId = recipe.Id
                });
            }

            foreach (var i in dto.Ingredients)
            {
                Guid? ingId;
                var normalized = i.Name.Trim().Replace(" ", "").ToLower();
                Ingredient? ingredient = _db.Ingredients.FirstOrDefault(ing => ing.SearchName == normalized);
                ingId = ingredient?.Id;
                if (ingredient == null)
                {
                    ingId = Guid.NewGuid();
                    _db.Ingredients.Add(new Ingredient { Id = ingId.Value, Name = i.Name, SearchName = normalized });
                }

                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = ingId!.Value,
                    BaseQuantity = i.BaseQuantity,
                    Unit = i.Unit,
                    QuantityText = i.QuantityText
                });
            }

            if(dto.TagIds.Count > 0)
            {
                // tag recup tt les tags de la db dont l'id est ds le dto 
                var tag = await _db.Tags.Where(t => dto.TagIds.Contains(t.Id)).ToListAsync();
                foreach (var t in tag)
                {
                    recipe.Tags.Add(t);
                }
            }

            _db.Recipes.Add(recipe);
            await _db.SaveChangesAsync();

            return recipe;
        }

        /// <summary>
        /// Get recipe detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<RecipeDetailResponseDto> GetByIdAsync(Guid id, Guid userId)
        {
            var recipe = await _db.Recipes
                .AsNoTracking()
                .Where(r => r.Id == id && (r.IsPublic || r.CreatedByUserId == userId))
                .Select(r => new RecipeDetailResponseDto
                {
                    // donnée de la recette
                    Title = r.Title,
                    Description = r.Description,
                    BasePortion = r.BasePortion,
                    PrepTime = r.PrepTime,
                    CookTime = r.CookTime,
                    IsPublic = r.IsPublic,
                    IsFavorite = r.UserRecipes
                        .Any(ur => ur.UserId == userId && ur.IsFavorite),
                    // etape depuis recipestep
                    Steps = r.RecipeSteps
                        .OrderBy(rs => rs.StepNumber)
                        .Select(re => re.StepInstruction)
                        .ToList(),
                    // ingrdient depuis recipeingredient
                    Ingredients = r.RecipeIngredients
                        .Select(ri => new IngredientDetailDto
                        {
                            Name = ri.Ingredient.Name,
                            Quantity = ri.BaseQuantity,
                            QuantityText = ri.QuantityText,
                            Unit = (int)ri.Unit
                        })
                        .ToList(),
                    // tag depuis recipetag
                    Tags = r.Tags
                        .Select(t => t.Name)
                        .ToList(),
                })
                .FirstOrDefaultAsync();


            return recipe;
        }

        /// <summary>
        /// Update a recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        public async Task UpdateAsync(Guid recipeId, RecipeUpdateDto dto, Guid userId, string? role)
        {
            RecipeValidator.ValidateForUpdate(dto);

            //recup recette + collections
            var recipe = await _db.Recipes
                .Include(r => r.RecipeIngredients)
                .Include(r => r.Tags)
                .Include(r => r.RecipeSteps)
                .FirstOrDefaultAsync(r => r.Id == recipeId);

            if (recipe == null)
            {
                throw new KeyNotFoundException("Recipe not found.");
            }

            // verifie si admin ou recette perso
            var isAdmin = string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
            if (!isAdmin && recipe.CreatedByUserId != userId)
            {
                throw new UnauthorizedAccessException("You cannot update this recipe.");
            }
                
            // maj des champ de la recette
            recipe.Title = dto.Title;
            recipe.Description = dto.Description;
            recipe.BasePortion = dto.BasePortion;
            recipe.PrepTime = dto.PrepTime;
            recipe.CookTime = dto.CookTime;
            recipe.IsPublic = dto.IsPublic;

            recipe.RecipeSteps.Clear();
            recipe.RecipeIngredients.Clear();
            recipe.Tags.Clear();
            await _db.SaveChangesAsync();


            //maj des steps
            for (int i = 0; i < dto.Steps.Count; i++)
            {
                var steptext = dto.Steps[i];
                _db.RecipeSteps.Add(new RecipeStep
                {
                    Id = Guid.NewGuid(),
                    StepNumber = i + 1,
                    StepInstruction = steptext,
                    RecipeId = recipe.Id
                });
            }

            // maj des ingredient
            foreach (var i in dto.Ingredients)
            {
                Guid? ingId;
                var normalized = i.Name.Trim().Replace(" ", "").ToLower();
                Ingredient? ingredient = _db.Ingredients.FirstOrDefault(ing => ing.SearchName == normalized);
                ingId = ingredient?.Id;
                if (ingredient == null)
                {
                    ingId = Guid.NewGuid();
                    _db.Ingredients.Add(new Ingredient { Id = ingId.Value, Name = i.Name, SearchName = normalized });
                }

                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = ingId!.Value,
                    BaseQuantity = i.Quantity,
                    Unit = i.Unit,
                    QuantityText = i.QuantityText
                });
            }

            // maj des tag
            if (dto.Tags.Count > 0)
            {
                var tags = _db.Tags.Where(t => dto.Tags.Contains(t.Name));
                foreach (var t in tags)
                {
                    recipe.Tags.Add(t);
                }
            }

            await _db.SaveChangesAsync();

        }

        /// <summary>
        /// Delete a recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(Guid recipeId, Guid userId, string role)
        {
            var recipe = await _db.Recipes
                .FirstOrDefaultAsync(r => r.Id == recipeId);
            if (recipe == null)
            {
                throw new KeyNotFoundException("Recipe not found.");
            }

            bool isOwner = recipe.CreatedByUserId == userId;
            bool isAdmin = role == "Admin";

            if (!isOwner && !isAdmin)
            {
                throw new UnauthorizedAccessException("You cannot delete this recipe.");
            }

            var isUsedInPlan = await _db.PlanSlots.AnyAsync(s => s.RecipeId == recipeId);
            if (isUsedInPlan)
            {
                throw new InvalidOperationException("Recipe is used in a plan. Remove it from planning first.");
            }

            _db.Recipes.Remove(recipe);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Add or remove recipe to favorite
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="recipeId"></param>
        /// <param name="isFavorite"></param>
        /// <returns></returns>
        public async Task SetFavoriteAsync(Guid userId, Guid recipeId, bool isFavorite)
        {
            var link = await _db.UserRecipes.FindAsync(userId, recipeId);

            if(link == null)
            {
                link = new UserRecipe
                {
                    UserId = userId,
                    RecipeId = recipeId,
                    AddedAt = DateTime.UtcNow,
                    IsFavorite = isFavorite
                };
                _db.UserRecipes.Add(link);
            }
            else
            {
                link.IsFavorite = isFavorite;
                _db.UserRecipes.Remove(link);

            }

            await _db.SaveChangesAsync();

        }
    }
}
