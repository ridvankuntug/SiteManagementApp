using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByUserIdValidator : AbstractValidator<GetDebtByUserIdQuery>
    {
        public GetDebtByUserIdValidator()
        {
            RuleFor(c => c.newUserId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Id sıfırdan büyük olmalı.");
        }
    }
}
