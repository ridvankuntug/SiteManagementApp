using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.ChangeMessage
{
    public class ReadMessageValidator : AbstractValidator<ReadMessageCommand>
    {
        public ReadMessageValidator()
        {
            RuleFor(m => m.newMessageId).NotEmpty();
        }
    }
}
