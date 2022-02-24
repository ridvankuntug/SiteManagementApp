using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Queries.GetMeesage
{
    public class GetMessageByIdValidator : AbstractValidator<GetMessageByIdQuery>
    {
        public GetMessageByIdValidator()
        {
            RuleFor(m => m.newMessageId).NotEmpty().GreaterThan(0);
        }
    }
}
