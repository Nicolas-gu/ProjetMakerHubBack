using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string DisplayName { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public List<Recipe> Recipes { get; set; } = new();
        public List<UserRecipe> UserRecipes { get; set; } = new();
        public List<Plan> Plans { get; set; } = new();
        public List<PantryItem> PantryItems { get; set; } = new();
        public List<ShoppingList> ShoppingLists { get; set; } = new();

    }
}
