﻿namespace Domain.Entities
{
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
