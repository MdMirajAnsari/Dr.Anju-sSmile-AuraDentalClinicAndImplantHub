using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.DentalOffices.Commands.UpdateDentalOffice
{
    public class UpdateDentalOfficeCommandValidator : AbstractValidator<UpdateDentalOfficeCommand>
    {
        public UpdateDentalOfficeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("name is required");
        }
    }
}
