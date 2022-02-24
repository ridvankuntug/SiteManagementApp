using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetMessageByReciverIdValidator : AbstractValidator<GetMessageByReciverIdQuery>
    {
        public GetMessageByReciverIdValidator()
        {
            RuleFor(m => m.newReciverId).NotNull().GreaterThan(0);
        }
    }
}
