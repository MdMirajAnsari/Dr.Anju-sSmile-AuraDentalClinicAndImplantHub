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
            EnforceNameBusinessRules(name);
            EnforceEmailBusinessRules(email);


            if (email == null)
            {
                throw new BusinessRuleException($"The {nameof(Email)} field is required.");
            }

            Name = name;
            Email = email;
            Id = Guid.CreateVersion7();
        }

        public void UpdateName(string name)
        {
            EnforceNameBusinessRules(name);
        }

        private void EnforceNameBusinessRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} field is required.");
            }
        }
        public void UpdateEmail(Email email)
        {
            EnforceEmailBusinessRules(email);
            Email = email;
        }

        private void EnforceEmailBusinessRules(Email email)
        {
            if (email == null)
            {
                throw new BusinessRuleException($"The {nameof(Email)} field is required.");
            }
        }
    }
}
