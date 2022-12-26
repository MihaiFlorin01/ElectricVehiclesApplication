using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.InvoiceDtos
{
    public class UpdateInvoiceDto
    {
        public int Id { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VAT { get; set; }
        public decimal NetAmount { get; set; }
        public bool Paid { get; set; }
    }
}
