using FluentValidation;
using System;

namespace SiteManagementApplication.Operations.UserOperations.Commands.AddUser
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(c => c.Model.UserName).NotNull().MaximumLength(30).WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(c => c.Model.UserFullName).NotNull().MaximumLength(30).WithMessage("İsim 30 dan uzun olamaz.");
            RuleFor(c => c.Model.UserTc.ToString()).NotNull().Length(11).WithMessage("Tc 11 hane olmalı.");
            RuleFor(c => c.Model.Email).NotNull().EmailAddress().MaximumLength(30).WithMessage("Mail 30 dan uzun olamaz.");
            RuleFor(c => c.Model.PhoneNumber).NotNull().MaximumLength(10).WithMessage("Telefon numarası 10 hane olmalı.");
            RuleFor(c => c.Model.PasswordHash).NotNull().MinimumLength(6).WithMessage("Şifre 6 handen kısa olmamalı.");
            RuleFor(c => c.Model.UserVehicle).MaximumLength(20).WithMessage("Araç özelliği 20 handen kısa olmalı.");
            RuleFor(c => c.Model.IsAdmin).NotNull();
        }
    }
}
