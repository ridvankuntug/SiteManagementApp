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
            RuleFor(c => c.newApartmentBlock).NotNull();
            RuleFor(c => c.newApartmentFloor).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(99);
            RuleFor(c => c.newApartmentNo).NotNull().GreaterThanOrEqualTo(1).LessThanOrEqualTo(999);

            RuleFor(c => c.Model.ApartmentType).Must(t => t.Trim() == string.Empty || t.Trim().Length <= 3);
            //RuleFor(c => c.Model.User_Id);
        }
    }
}
