using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetMessageBySenderIdValidator : AbstractValidator<GetMessageBySenderIdQuery>
    {
        public GetMessageBySenderIdValidator()
        {
            RuleFor(m => m.newSenderId).NotEmpty().GreaterThan(0);
        }
    }
}
