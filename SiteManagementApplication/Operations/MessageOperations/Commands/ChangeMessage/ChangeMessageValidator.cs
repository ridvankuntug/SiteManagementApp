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
            RuleFor(m => m.newMessageId).NotEmpty().WithMessage("Id boş olamaz.");
            RuleFor(m => m.Model.MessageText).MaximumLength(999).WithMessage("Mesaj 999 karakterden fazla olamaz.");
        }
    }
}
