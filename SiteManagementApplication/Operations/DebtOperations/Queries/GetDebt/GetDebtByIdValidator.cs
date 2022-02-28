using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Queries.GetDebt
{
    public class GetDebtByIdValidator : AbstractValidator<GetDebtByIdQuery>
    {
        public GetDebtByIdValidator()
        {
            RuleFor(c => c.newDebtId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Id 0dan büyük olmalı");
        }
    }
}
