using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CustomerModels
{
    public class CustomerForUpdate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
    }
}
