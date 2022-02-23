
using FluentValidation;

namespace SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment
{
    public class GetApartmentByAdressValidator : AbstractValidator<GetApartmentByAdressQuery>
    {
        public GetApartmentByAdressValidator()
        {
            RuleFor(c => c.newApartmentBlock).NotEmpty().NotNull().MinimumLength(1).MaximumLength(3);
            RuleFor(c => c.newApartmentFloor).NotEmpty().NotNull().GreaterThan(0).LessThan(99);
            RuleFor(c => c.newApartmentNo).NotEmpty().NotNull().GreaterThan(0).LessThan(999);
        }
    }
}
