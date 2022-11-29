﻿namespace Dtos
{
    public class InvoiceDto
    {
        public long Id { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal VAT { get; set; }
        public decimal NetAmount { get; set; }
        public bool Paid { get; set; }
    }
}
