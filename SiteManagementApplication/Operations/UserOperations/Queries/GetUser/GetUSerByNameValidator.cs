using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.GetUser
{
    public class GetUserByNameValidator : AbstractValidator<GetUserByNameQuery>
    {
        public GetUserByNameValidator()
        {
            RuleFor(c => c.newUserName).NotEmpty().NotNull().MaximumLength(30).WithMessage("Id sıfırdan büyük olmalı.");
        }
    }
}
