using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BikeTypeModels
{
    public class BikeTypeForCreation
    {
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
