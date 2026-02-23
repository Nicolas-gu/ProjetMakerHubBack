using ProjetMakerHubBack.Domain.Entities;

namespace ProjetMakerHubBack.API.Dto
{
    public class RecipeSearchResponseDto()
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsPublic { get; set; }
        public bool IsFavorite { get; set; }
        public int CookTime { get; set; }
        public int PrepTime { get; set; }
        public int BasePortion { get; set; }

    }
}
