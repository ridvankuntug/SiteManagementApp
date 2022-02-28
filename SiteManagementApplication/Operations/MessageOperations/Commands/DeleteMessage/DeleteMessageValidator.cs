using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.MessageOperations.Commands.DeleteMessage
{
    public class DeleteMessageValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageValidator()
        {
            RuleFor(c => c.newMessageId).NotNull().GreaterThan(0).WithMessage("Id sıfırdan büyük olmalı.");
        }
    }
}
