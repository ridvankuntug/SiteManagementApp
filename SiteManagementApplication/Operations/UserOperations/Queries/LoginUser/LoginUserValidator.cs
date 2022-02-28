using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.LoginUser
{
    public class LoginUserValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator()
        {

            RuleFor(c => c.newUserName).NotEmpty().NotNull().MaximumLength(30).WithMessage("Kullanıcı adı 30 karakterden kısa olmalı.");
            RuleFor(c => c.newPassword).NotEmpty().NotNull().MaximumLength(30).WithMessage("Şifre 30 karakterden kısa olmalı.");
        }

    }
}
