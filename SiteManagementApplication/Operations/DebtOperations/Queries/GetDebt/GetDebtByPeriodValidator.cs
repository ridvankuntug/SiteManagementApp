using FluentValidation;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByPeriodValidator : AbstractValidator<GetDebtByPeriodQuery>
    {
        public GetDebtByPeriodValidator()
        {
            RuleFor(c => c.newDebtMonth).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(12);
            RuleFor(c => c.newDebtYear).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(9999);
        }
    }
}
