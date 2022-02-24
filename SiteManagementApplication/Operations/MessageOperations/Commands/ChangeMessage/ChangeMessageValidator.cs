using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.ChangeMessage
{
    public class ChangeMessageValidator : AbstractValidator<ChangeMessageCommand>
    {
        public ChangeMessageValidator()
        {
            RuleFor(m => m.newMessageId).NotEmpty();
            RuleFor(m => m.Model.MessageText).MaximumLength(999);
        }
    }
}
