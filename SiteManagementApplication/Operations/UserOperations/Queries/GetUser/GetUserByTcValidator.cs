using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.UserOperations.Queries.GetUser
{
    public class GetUserByTcValidator : AbstractValidator<GetUserByTcQuery>
    {
        public GetUserByTcValidator()
        {
            RuleFor(c => c.newUserTc).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
