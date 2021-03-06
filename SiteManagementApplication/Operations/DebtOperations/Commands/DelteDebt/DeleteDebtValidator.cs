using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.DelteDebt
{
    public class DeleteDebtValidator : AbstractValidator<DeleteDebtCommand>
    {
        public DeleteDebtValidator()
        {
            RuleFor(c => c.newDebtId).NotNull().GreaterThan(0).WithMessage("Id 0 dan büyük olmalı.");
        }
    }
}
