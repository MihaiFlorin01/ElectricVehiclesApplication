namespace CQRS.Queries.BikeTypeQueries
{
    public class ViewBikeTypeQuery
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
