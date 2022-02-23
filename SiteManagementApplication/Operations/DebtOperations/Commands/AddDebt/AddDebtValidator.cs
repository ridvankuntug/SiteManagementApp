using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.DebtOperations.Commands.AddDebt
{
    public class AddDebtValidator : AbstractValidator<AddDebtCommand>
    {
        public AddDebtValidator()
        {
            RuleFor(d => d.Model.DebtBill).NotNull().LessThan(9999);
            RuleFor(d => d.Model.DebtDue).NotNull().LessThan(9999);
            RuleFor(d => d.Model.DebtPeriod).NotNull().Must(date => date != default(DateTime));
            RuleFor(d => d.Model.User_Id).NotNull().LessThan(9999);
        }
    }
}
