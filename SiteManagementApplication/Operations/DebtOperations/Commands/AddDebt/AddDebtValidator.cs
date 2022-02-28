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
            RuleFor(d => d.Model.DebtBill).NotNull().LessThanOrEqualTo(9999).WithMessage("Fatura 9999 dan büyük olamaz.");
            RuleFor(d => d.Model.DebtDue).NotNull().LessThanOrEqualTo(9999).WithMessage("Aidat 9999 dan büyük olamaz.");
            RuleFor(d => d.Model.DebtYear).NotNull().LessThanOrEqualTo(9999).WithMessage("Yıl 9999 dan büyük olamaz.");
            RuleFor(d => d.Model.DebtMonth).NotNull().LessThanOrEqualTo(12).WithMessage("Ay 12den büyük olamaz.");
            RuleFor(d => d.Model.User_Id).NotNull().LessThanOrEqualTo(9999).WithMessage("User_Id 9999 dan büyük olamaz.");
            RuleFor(d => d.Model.IsPaid).NotNull();
        }
    }
}
