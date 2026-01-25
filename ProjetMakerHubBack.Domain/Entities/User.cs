using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class User
    {
        public Guid Id { get; set; }
        public required string Email { get; set; }
        public required string HashPassword { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Recipe>? Recipes { get; set; }
        public List<RecipeFavorite>? Favorites { get; set; }
        public List<Plan>? Plans { get; set; }
        public List<HomeStock>? Stocks { get; set; }
        // liste de course
        // 

    }
}
