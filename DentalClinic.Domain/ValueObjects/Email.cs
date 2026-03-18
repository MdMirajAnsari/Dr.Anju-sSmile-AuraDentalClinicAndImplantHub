using DentalClinic.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.Domain.ValueObjects
{
    [Owned]
    public record Email
    {
        public string Value { get; } = null!;

        private Email() { }
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException("Email cannot be empty.", nameof(email));
            }
            if (!email.Contains("@"))
            {
                throw new BusinessRuleException("Email must be a valid email address.", nameof(email));
            }
            Value = email;
        }
    }
}
