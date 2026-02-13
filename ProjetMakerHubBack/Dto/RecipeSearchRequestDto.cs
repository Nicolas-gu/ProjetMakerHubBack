namespace ProjetMakerHubBack.API.Dto
{
    public class RecipeSearchRequestDto
    {
        public string? Q { get; set; }
        public List<Guid>? TagIds { get; set; } = new();
        public bool Favorite { get; set; } = false;
        public bool Mine { get; set; } = false;
    }
}
