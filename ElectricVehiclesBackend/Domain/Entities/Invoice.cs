using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("invoices")]
    public class Invoice
    {
        public int Id { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VAT { get; set; }
        public decimal NetAmount { get; set; }
        public bool Paid { get; set; }
    }
}
