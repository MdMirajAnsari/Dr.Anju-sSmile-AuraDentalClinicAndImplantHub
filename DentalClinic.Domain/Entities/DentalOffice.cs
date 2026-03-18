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

        private DentalOffice() { }

        public DentalOffice(string name)
        {
            EnforceNameBusinessRules(name);
            Name = name;
            Id = Guid.CreateVersion7();
        }

        public void Update(string name)
        {
           EnforceNameBusinessRules(name);
            Name = name;
        }

        private void EnforceNameBusinessRules(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"The {nameof(Name)} field is required.");
            }
        }
    }
}
