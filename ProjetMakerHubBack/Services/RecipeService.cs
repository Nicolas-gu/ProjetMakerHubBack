using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.API.Validators;
using ProjetMakerHubBack.Domain.Entities;
using ProjetMakerHubBack.Domain.Enums;

namespace ProjetMakerHubBack.API.Services
{
    public class RecipeService(AppDbContext _db)
    {
        /// <summary>
        /// Create a recipe
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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
                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = i.IngredientId,
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
        /// Delete a recipe
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task DeleteAsync(Guid id)
        {
            Recipe? toDelete = _db.Recipes.Find(id);
            if(toDelete == null)
            {
                throw new KeyNotFoundException("Recipe does not exist.");
            }

            _db.Recipes.Remove(toDelete);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Search recipes
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<RecipeSearchResponseDto>> SearchAsync(RecipeSearchRequestDto dto, Guid userId)
        {
            var query = _db.Recipes.AsNoTracking().AsQueryable();

            // recette publique ou créée par moi
            query = query.Where(r => r.IsPublic || r.CreatedByUserId == userId);

            // recherche par nom via input
            if(!string.IsNullOrWhiteSpace(dto.Search))
            {
                var searchData = dto.Search.Trim();
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
                throw new KeyNotFoundException("Recipe not found.");

            // verifie si admin ou recette perso
            var isAdmin = string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase);
            if (!isAdmin && recipe.CreatedByUserId != userId)
                throw new UnauthorizedAccessException();

            // maj des champ de la recette
            recipe.Title = dto.Title;
            recipe.Description = dto.Description;
            recipe.BasePortion = dto.BasePortion;
            recipe.PrepTime = dto.PrepTime;
            recipe.CookTime = dto.CookTime;
            recipe.IsPublic = dto.IsPublic;

            // maj des steps
            recipe.RecipeSteps.Clear();
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

            recipe.RecipeIngredients.Clear();
            foreach (var i in dto.Ingredients)
            {
                recipe.RecipeIngredients.Add(new RecipeIngredient
                {
                    RecipeId = recipe.Id,
                    IngredientId = i.IngredientId,
                    BaseQuantity = i.Quantity,
                    Unit = i.Unit,
                    QuantityText = i.QuantityText
                });
            }

            recipe.Tags.Clear();
            if (dto.Tags.Count > 0)
            {
                var tag = await _db.Tags.Where(t => dto.Tags.Contains(t.Id)).ToListAsync();
                foreach (var t in tag)
                {
                    recipe.Tags.Add(t);
                }
            }

            await _db.SaveChangesAsync();

        }
    }
}
