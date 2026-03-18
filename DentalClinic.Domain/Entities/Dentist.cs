using DentalClinic.Domain.Exceptions;
using DentalClinic.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DentalClinic.Domain.Entities
{
    
    public class Dentist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
       
        public Email Email { get; private set; } = null!;

        private Dentist() { }

        public Dentist(string name, Email email) 
        {
            if(string.IsNullOrWhiteSpace(name))
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
