using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Domain.Entities;

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

            //TODO ajouter validation ingredient et tag existe?

            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new ArgumentException("Title required");
            }
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new ArgumentException("Description required");
            }
            if (dto.BasePortion <= 0)
            {
                throw new ArgumentException("BasePortion must be > 0");
            }
            if (dto.CookTime <= 0)
            {
                throw new ArgumentException("CookTime must be > 0");
            }
            if (dto.PrepTime <= 0)
            {
                throw new ArgumentException("PrepTime must be > 0");
            }
            if (dto.Ingredients.Count <= 0)
            {
                throw new ArgumentException("add at least one ingredient");
            }
            if (dto.Steps.Count <= 0)
            {
                throw new ArgumentException("add at least one step");
            }

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
        public async Task DeleteAsync(Guid recipeId)
        {
            Recipe? toDelete = _db.Recipes.Find(recipeId);
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

    }
}
