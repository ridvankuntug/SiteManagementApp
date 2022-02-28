using FluentValidation;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByPeriodValidator : AbstractValidator<GetDebtByPeriodQuery>
    {
        public GetDebtByPeriodValidator()
        {
            RuleFor(c => c.newDebtMonth).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(12).WithMessage("Ay 12den küçük olmalı");
            RuleFor(c => c.newDebtYear).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(9999).WithMessage("Yıl 9999 dan büyük olamaz.");
        }
    }
}
