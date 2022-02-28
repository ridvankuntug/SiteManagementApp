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
            RuleFor(c => c.newUserId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Id sıfırdan büyük olmalı.");
            RuleFor(c => c.newDebtMonth).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(12).WithMessage("Ay 12den küçü olmalı.");
            RuleFor(c => c.newDebtYear).NotEmpty().NotNull().GreaterThan(0).LessThanOrEqualTo(9999).WithMessage("Yıl 9999 dan büyük olamaz.");
        }
    }
}
