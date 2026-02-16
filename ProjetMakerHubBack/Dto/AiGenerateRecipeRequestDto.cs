namespace ProjetMakerHubBack.API.Dto
{
    public class AiGenerateRecipeRequestDto
    {
        public List<string> Ingredients { get; set; } = new();
        public int Servings { get; set; } = 2;
        public string? MealType { get; set; }
        public int? MaxTotalMinutes { get; set; }
        public List<string>? Avoid { get; set; }
    }

    public class AiImportUrlRequestDto
    {
        public string Url { get; set; } = "";
    }
}
