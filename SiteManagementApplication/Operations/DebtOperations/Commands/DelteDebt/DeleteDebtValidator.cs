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
            RuleFor(c => c.newDebtId).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(2147483647);
        }
    }
}
