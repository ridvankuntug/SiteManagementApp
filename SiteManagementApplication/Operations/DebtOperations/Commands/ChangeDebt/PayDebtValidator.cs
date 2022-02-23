using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.ChangeDebt
{
    public class PayDebtValidator: AbstractValidator<PayDebtCommand>
    {
        public PayDebtValidator()
        {
                RuleFor(d => d.newDebtId).NotEmpty().GreaterThan(0);
        }
    }
}
