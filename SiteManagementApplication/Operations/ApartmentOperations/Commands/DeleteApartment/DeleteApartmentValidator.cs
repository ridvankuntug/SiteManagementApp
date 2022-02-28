
using FluentValidation;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.DeleteApartment
{
    public class DeleteApartmentValidator : AbstractValidator<DeleteApartmentCommand>
    {
        public DeleteApartmentValidator()
        {
            RuleFor(c => c.newApartmentBlock).NotNull().WithMessage("Blok Boş bırakılamaz.");
            RuleFor(c => c.newApartmentFloor).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(99).WithMessage("Kat 0 ile 99 arasında olmalı.");
            RuleFor(c => c.newApartmentNo).NotNull().GreaterThan(0).LessThanOrEqualTo(999).WithMessage("Daire no 0 ile 9999 arasında olmalı.");

        }
    }
}
