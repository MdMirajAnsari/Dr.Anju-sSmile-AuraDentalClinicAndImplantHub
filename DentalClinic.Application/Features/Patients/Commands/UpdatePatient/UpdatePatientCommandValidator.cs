using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidator() 
        {
            RuleFor(_ => _.Name)
                .NotEmpty()
                .WithMessage("Patient name is required.")
                .MaximumLength(100)
                .WithMessage("Patient name must not exceed 100 characters.");
            RuleFor(_ => _.Email)
                .NotEmpty()
                .WithMessage("Patient email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .MaximumLength(100)
                .WithMessage("Patient email must not exceed 100 characters.");

        }

    }
}
