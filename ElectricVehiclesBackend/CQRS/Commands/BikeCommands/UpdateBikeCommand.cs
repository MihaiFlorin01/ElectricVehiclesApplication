namespace CQRS.Commands.BikeCommands
{
    public class UpdateBikeCommand
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
