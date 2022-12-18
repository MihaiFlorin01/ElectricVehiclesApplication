namespace CQRS.Commands.BikeTypeCommands
{
    public class CreateBikeTypeCommand
    {
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
