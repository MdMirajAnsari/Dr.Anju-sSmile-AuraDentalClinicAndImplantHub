using System;
using System.Collections.Generic;
using System.Text;
using DentalClinic.Domain.Exceptions;
using DentalClinic.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DentalClinic.Tests.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {

        [TestMethod]
        public void Constructor_InvalidEmail_ThrowsBusinessRuleException()
        {
            try
            {
                var _ = new Email("invalid");
                Assert.Fail("Expected BusinessRuleException was not thrown.");
            }
            catch (BusinessRuleException)
            {
                // Expected exception - test passes
            }
        }
    }
}
