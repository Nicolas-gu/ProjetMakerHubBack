using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    public class RecipeStep
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string StepInstruction { get; set; } = null!;


        public Recipe Recipe { get; set; } = null!;
        public Guid RecipeId { get; set; }
    }
}
