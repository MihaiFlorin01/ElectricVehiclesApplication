using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rentals
    {
        public int Id { get; set; }
        public int BikeId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int InvoiceId { get; set; }
    }
}
