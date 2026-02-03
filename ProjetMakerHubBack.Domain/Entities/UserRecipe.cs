using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class UserRecipe
    {
        public bool IsFavorite { get; set; }
        public DateTime AddedAt { get; set; }


        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}
