using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("customers")]
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BillingAddress { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
