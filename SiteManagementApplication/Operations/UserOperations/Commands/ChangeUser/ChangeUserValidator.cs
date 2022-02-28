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
            RuleFor(c => c.newUserId).NotEmpty().NotNull().GreaterThan(0).WithMessage("Id boş olamaz");
            RuleFor(c => c.Model.UserName).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 30).WithMessage("Tamamen boş bırakın yada 30 karakterden kısa olsun.");
            RuleFor(c => c.Model.UserFullName).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 30).WithMessage("Tamamen boş bırakın yada 30 karakterden kısa olsun.");
            RuleFor(c => c.Model.UserTc.ToString()).NotNull().Length(11).WithMessage("Tc 11 hane olmalı.");
            RuleFor(c => c.Model.Email).EmailAddress().When(e => !string.IsNullOrEmpty(e.Model.Email.Trim())).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 30).WithMessage("Tamamen boş bırakın yada 30 karakterden kısa olsun.");
            RuleFor(c => c.Model.PhoneNumber).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 10).WithMessage("Tamamen boş bırakın yada 10 karakterden kısa olsun.");
            RuleFor(c => c.Model.PasswordHash).MaximumLength(90);
            RuleFor(c => c.Model.UserVehicle).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 20).WithMessage("Tamamen boş bırakın yada 20 karakterden kısa olsun.");
            RuleFor(c => c.Model.IsAdmin).NotNull();
        }
    }
}
