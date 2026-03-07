using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; } = [];
        public CustomValidationException(ValidationResult validationResult) 
        {
            foreach (var error in validationResult.Errors) 
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

    }
}
