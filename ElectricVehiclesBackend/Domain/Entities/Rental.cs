using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("rentals")]
    public class Rental
    {
        public int Id { get; set; }
        public int BikeId { get; set; }
        public Bike? Bike { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int InvoiceId { get; set; }
    }
}
