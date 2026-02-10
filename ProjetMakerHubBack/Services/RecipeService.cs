using Microsoft.EntityFrameworkCore;
using ProjetMakerHubBack.API.Data;
using ProjetMakerHubBack.API.Dto;
using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Services
{
    public class RecipeService(AppDbContext _db)
    {
        public async Task<Recipe> CreateAsync(RecipeCreateDTO dto, Guid userId)
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

        public async Task DeleteAsync(Guid recipeId)
        {
            Recipe? toDelete = _db.Recipes.Find(recipeId);
            if(toDelete == null)
            {
                throw new KeyNotFoundException();
            }

            _db.Recipes.Remove(toDelete);
            await _db.SaveChangesAsync();
        }
    }
}
