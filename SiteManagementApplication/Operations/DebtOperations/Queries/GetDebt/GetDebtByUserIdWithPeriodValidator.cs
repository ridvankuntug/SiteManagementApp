using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByUserIdWithPeriodValidator : AbstractValidator<GetDebtByUserIdWithPeriodQuery>
    {
        public GetDebtByUserIdWithPeriodValidator()
        {
            RuleFor(c => c.newUserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(c => c.newDebtMonth).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(12);
            RuleFor(c => c.newDebtYear).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(9999);
        }
    }
}
