namespace Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int BikeId { get; set; }
        public BikeDto? Bike { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int InvoiceId { get; set; }
    }
}
