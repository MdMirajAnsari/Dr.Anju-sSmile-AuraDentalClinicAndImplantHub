using DentalClinic.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.Domain.Entities
{
    public class DentalOffice
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;

        public DentalOffice(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} field is required.");
            }
            Name = name;
            Id = Guid.CreateVersion7();
        }
    }
}
