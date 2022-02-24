using FluentValidation;
using System;

namespace SiteManagementApplication.Operations.UserOperations.Commands.AddUser
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(c => c.Model.UserName).NotNull().MaximumLength(30);
            RuleFor(c => c.Model.UserFullName).NotNull().MaximumLength(30);
            RuleFor(c => c.Model.UserTc.ToString()).NotNull().Length(11);
            RuleFor(c => c.Model.Email).NotNull().EmailAddress().MaximumLength(30);
            RuleFor(c => c.Model.PhoneNumber).NotNull().MaximumLength(10);
            RuleFor(c => c.Model.PasswordHash).NotNull().MinimumLength(6);
            RuleFor(c => c.Model.UserVehicle).MaximumLength(20);
            RuleFor(c => c.Model.IsAdmin).NotNull();
        }
    }
}
