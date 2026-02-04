using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class UserRecipe
    {
        public bool IsFavorite { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;


        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
        public User User { get; set; } = null!;
        public Recipe Recipe { get; set; } = null!;
    }
}
