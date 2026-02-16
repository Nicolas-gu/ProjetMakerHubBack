namespace ProjetMakerHubBack.API.Dto
{
    public class RecipeSuggestionDto
    {
        public Guid RecipeId { get; set; }
        public string Title { get; set; } = "";
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public bool IsPublic { get; set; }
        public int MissingCount { get; set; }
        public List<string> MissingIngredients { get; set; } = new();
    }
}
