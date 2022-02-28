using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Commands.DeleteUser
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(c => c.newUserId).NotNull().GreaterThan(0).WithMessage("Id 0dan büyük olmalı.");
        }
    }
}
