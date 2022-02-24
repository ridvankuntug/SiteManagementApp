using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.AddMessage
{
    public class AddMessageValidator : AbstractValidator<AddMessageCommand>
    {
        public AddMessageValidator()
        {
            RuleFor(m => m.Model.MessageText).NotEmpty().MaximumLength(999);
            RuleFor(d => d.Model.Sender_Id).NotEmpty().GreaterThan(0);
            RuleFor(d => d.Model.Reciver_Id).NotEmpty().GreaterThan(0);
        }
    }
}
