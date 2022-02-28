
using FluentValidation;

namespace SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment
{
    public class GetApartmentByAdressValidator : AbstractValidator<GetApartmentByAdressQuery>
    {
        public GetApartmentByAdressValidator()
        {
            RuleFor(c => c.newApartmentBlock).NotEmpty().NotNull().MinimumLength(1).MaximumLength(3).WithMessage("Blok boş bırakılamaz.");
            RuleFor(c => c.newApartmentFloor).NotEmpty().NotNull().GreaterThan(0).LessThan(99).WithMessage("Blok boş bırakılamaz.");
            RuleFor(c => c.newApartmentNo).NotEmpty().NotNull().GreaterThan(0).LessThan(999).WithMessage("Daire no 0 ile 999 arasında olmalı.");
        }
    }
}
