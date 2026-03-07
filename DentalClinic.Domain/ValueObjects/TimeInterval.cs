using System;
using System.Collections.Generic;
using System.Text;

namespace DentalClinic.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeInterval(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException("Start time must be before end time.");
            }
            Start = start;
            End = end;
        }
    }
}
