using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BikeTypeModels
{
    public class BikeTypeForUpdate
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
