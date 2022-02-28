using FluentValidation;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.AddApartment
{
    public class AddApartmentValidator : AbstractValidator<AddApartmentCommand>
    {
        public AddApartmentValidator()
        {
            RuleFor(c => c.Model.ApartmentBlock).NotNull().WithMessage("Blok boş bırakılamaz.");
            RuleFor(c => c.Model.ApartmentFloor).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(99).WithMessage("Kat 0 ile 99 arasında olmalı.");
            RuleFor(c => c.Model.ApartmentNo).NotNull().GreaterThan(0).LessThanOrEqualTo(999).WithMessage("Daire no 0 ile 999 arasında olmalı.");
            RuleFor(c => c.Model.ApartmentType).NotNull().Must(t => t.Trim() != string.Empty || t.Trim().Length <= 3).WithMessage("Apartman tipi 3 haneli olmalı, ör: 3+1.");

        }
    }
}
