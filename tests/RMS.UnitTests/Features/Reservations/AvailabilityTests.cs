using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace RMS.UnitTests.Features.Reservations
{
    public class AvailabilityTests
    {
        [Fact]
        public void NoOverlap_WhenNewEndIsBeforeExistingStart_ShouldBeAvailable()
        {
            // Assert.True(true);

            //Exisiting Aug 5-10
            //New: Aug 1-4

            var existingStart = new DateTime(2026,8,5);
            var existingEnd = new DateTime(2026,8,10);
            var newStart = new DateTime(2026,8,1);
            var newEnd = new DateTime(2026,8,4);

            var hasOverlap = existingStart < newEnd && existingEnd > newStart;

            hasOverlap.Should().BeFalse();
        }
 
    }
}