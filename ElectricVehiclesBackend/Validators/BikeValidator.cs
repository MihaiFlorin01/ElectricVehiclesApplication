using Entities;
using FluentValidation;

namespace Validators
{
    public class BikeValidator : AbstractValidator<Bike>
    {
        public BikeValidator()
        {
            RuleFor(x => x.Type).NotNull().NotEmpty().Length(5, 50). WithMessage("Please specify a vehicle type!");
            RuleFor(x => x.RegisterDate).NotNull().NotEmpty().WithMessage("Please specify a register date!");
        }
    }
}
