
using FluentValidation;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.DeleteApartment
{
    public class DeleteApartmentValidator : AbstractValidator<DeleteApartmentCommand>
    {
        public DeleteApartmentValidator()
        {
            RuleFor(c => c.newApartmentBlock).NotNull();
            RuleFor(c => c.newApartmentFloor).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);
            RuleFor(c => c.newApartmentNo).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(999);

        }
    }
}
