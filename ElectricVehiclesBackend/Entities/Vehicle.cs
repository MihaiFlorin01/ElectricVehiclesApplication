using Abstractions;
using Utils.Enums;

namespace Entities
{
    public class Vehicle : BaseEntityModel
    {
        public VehicleTypeRegistered Type { get; set; }
        public DateTimeOffset RegisterDate { get; set; }
        public VehicleType? VehicleType { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}