using FluentValidation;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment
{
    public class AddApartmentValidator : AbstractValidator<AddApartmentCommand>
    {
        public AddApartmentValidator()
        {
            RuleFor(c => c.Model.ApartmentBlock).NotNull();
            RuleFor(c => c.Model.ApartmentFloor).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);
            RuleFor(c => c.Model.ApartmentNo).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(999);
            RuleFor(c => c.Model.ApartmentType).NotNull().Must(t => t.Trim() != string.Empty || t.Trim().Length <= 3);

        }
    }
}
