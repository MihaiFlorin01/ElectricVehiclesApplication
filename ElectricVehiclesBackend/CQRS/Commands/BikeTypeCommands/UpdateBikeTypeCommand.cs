namespace CQRS.Commands.BikeTypeCommands
{
    public class UpdateBikeTypeCommand
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
