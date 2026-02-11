using ProjetMakerHubBack.API.Dto;

namespace ProjetMakerHubBack.API.Validators
{
    public class RecipeValidator
    {
        public static void ValidateForCreate(RecipeCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("Title required");

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentException("Description required");

            if (dto.BasePortion <= 0)
                throw new ArgumentException("BasePortion must be > 0");

            if (dto.CookTime < 0)
                throw new ArgumentException("CookTime must be >= 0");

            if (dto.PrepTime < 0)
                throw new ArgumentException("PrepTime must be >= 0");

            if (dto.Ingredients == null || dto.Ingredients.Count == 0)
                throw new ArgumentException("Add at least one ingredient");

            if (dto.Steps == null || dto.Steps.Count == 0)
                throw new ArgumentException("Add at least one step");
        }

        public static void ValidateForUpdate(RecipeUpdateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ArgumentException("Title required");

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ArgumentException("Description required");

            if (dto.BasePortion <= 0)
                throw new ArgumentException("BasePortion must be > 0");

            if (dto.CookTime < 0)
                throw new ArgumentException("CookTime must be >= 0");

            if (dto.PrepTime < 0)
                throw new ArgumentException("PrepTime must be >= 0");

            if (dto.Ingredients == null || dto.Ingredients.Count == 0)
                throw new ArgumentException("Add at least one ingredient");

            if (dto.Steps == null || dto.Steps.Count == 0)
                throw new ArgumentException("Add at least one step");
        }
    }
}
