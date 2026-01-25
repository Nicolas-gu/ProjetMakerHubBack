using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class RecipeTag
    {
        public Guid RecipeId { get; set; }
        public Guid TagId { get; set; }
    }
}
