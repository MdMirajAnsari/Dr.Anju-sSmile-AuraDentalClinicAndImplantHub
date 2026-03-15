using DentalClinic.Domain.Exceptions;
using DentalClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DentalClinic.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        private Patient() { }

        public Patient(string name, Email email) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} field is required.");
            }

           if(email == null)
            {
                throw new BusinessRuleException($"The {nameof(Email)} field is required.");
            }

            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }
    }
}
