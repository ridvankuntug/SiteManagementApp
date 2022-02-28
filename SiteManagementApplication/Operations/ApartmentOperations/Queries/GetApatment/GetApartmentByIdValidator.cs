using FluentValidation;
using SiteManagementDomain.Entities;

namespace SiteManagementApplication.Operations.ApartmentOperations.Queries.GetApatment
{
    public class GetApartmentByIdValidator : AbstractValidator<GetApartmentByIdQuery>
    {
        public GetApartmentByIdValidator()
        {
            RuleFor(c => c.newApartmentId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Id boş yada 0 olamaz.");
        }
    }
}
