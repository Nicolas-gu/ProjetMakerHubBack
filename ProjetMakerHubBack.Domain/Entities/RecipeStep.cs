using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class RecipeStep
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string StepInstr { get; set; }
        public Guid RecipeId { get; set; }

    }
}
