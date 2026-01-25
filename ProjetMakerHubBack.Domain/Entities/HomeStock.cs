using ProjetMakerHubBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Domain.Entities
{
    internal class HomeStock
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
        public DateTime UpdateAt { get; set; }
        

    }
}
