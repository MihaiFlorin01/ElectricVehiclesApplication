using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.RentalDtos
{
    public class CreateRentalDto
    {
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
    }
}
