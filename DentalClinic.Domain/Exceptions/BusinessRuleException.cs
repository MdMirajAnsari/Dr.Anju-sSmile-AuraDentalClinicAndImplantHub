using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.Domain.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public string ParamName { get; }

        public BusinessRuleException(string message): base(message)
        {
        }

        public BusinessRuleException(string message, string paramName) : base(message)
        {
            ParamName = paramName;
        }
    }
}
