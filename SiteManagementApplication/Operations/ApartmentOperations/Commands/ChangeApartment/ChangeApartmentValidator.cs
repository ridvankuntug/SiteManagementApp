using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementApplication.Operations.ApartmentOperations.Commands.ChangeApartment
{
    public class ChangeApartmentValidator : AbstractValidator<ChangeApartmentCommand>
    {
        public ChangeApartmentValidator()
        {
            RuleFor(c => c.newApartmentId).NotNull().WithMessage("Id boş geçilemez.");

            RuleFor(c => c.Model.ApartmentType).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 3).WithMessage("Apartman tipi 3 haneli olmalı. ör: 3+1.");
        }
    }
}
