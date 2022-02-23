using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Commands.ChangeUser
{
    public class ChangeUserValidator : AbstractValidator<ChangeUserCommand>
    {
        public ChangeUserValidator()
        {
            RuleFor(c => c.newUserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(c => c.Model.UserName).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 30);
            RuleFor(c => c.Model.UserTc.ToString()).NotNull().Length(11);
            RuleFor(c => c.Model.Email).EmailAddress().When(e => !string.IsNullOrEmpty(e.Model.Email.Trim())).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 30);
            RuleFor(c => c.Model.PhoneNumber).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 10);
            RuleFor(c => c.Model.PasswordHash).MaximumLength(50);
            RuleFor(c => c.Model.UserVehicle).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 20);
            RuleFor(c => c.Model.IsAdmin).NotNull();
        }
    }
}
