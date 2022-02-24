using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetMessageBySenderIdAndReciverIdValidator 
        : AbstractValidator<GetMessageBySenderIdAndReciverIdQuery>
    {
        public GetMessageBySenderIdAndReciverIdValidator()
        {
            RuleFor(m => m.newReciverId).NotEmpty().GreaterThan(0);
            RuleFor(m => m.newSenderId).NotEmpty().GreaterThan(0);
        }
    }
}
