﻿using FluentValidation;
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
            RuleFor(d => d.Model.DebtBill).NotNull().LessThanOrEqualTo(9999);
            RuleFor(d => d.Model.DebtDue).NotNull().LessThanOrEqualTo(9999);
            RuleFor(d => d.Model.DebtYear).NotNull().LessThanOrEqualTo(9999);
            RuleFor(d => d.Model.DebtMonth).NotNull().LessThanOrEqualTo(12);
            RuleFor(d => d.Model.User_Id).NotNull().LessThanOrEqualTo(9999);
            RuleFor(d => d.Model.IsPaid).NotNull();
        }
    }
}