using System;
using DentalClinic.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DentalClinic.Tests.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {
        [TestMethod]
        public void Constructor_ValidInterval_SetsProperties()
        {
            var start = new DateTime(2026, 1, 1, 9, 0, 0);
            var end = new DateTime(2026, 1, 1, 10, 0, 0);

            var interval = new TimeInterval(start, end);

            Assert.AreEqual(start, interval.Start);
            Assert.AreEqual(end, interval.End);
        }

        [TestMethod]
        public void Constructor_StartEqualsEnd_ThrowsArgumentException()
        {
            var time = new DateTime(2026, 1, 1, 9, 0, 0);
            try
            {
                var _ = new TimeInterval(time, time);
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }

        [TestMethod]
        public void Constructor_StartAfterEnd_ThrowsArgumentException()
        {
            var start = new DateTime(2026, 1, 1, 11, 0, 0);
            var end = new DateTime(2026, 1, 1, 10, 0, 0);
            try
            {
                var _ = new TimeInterval(start, end);
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException)
            {
                // Expected
            }
        }
    }
}
