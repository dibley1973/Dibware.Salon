// <copyright file="ZeroDurationSubtractionStrategyUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using Dibware.Salon.Domain.SharedKernel.Measures;
using Dibware.Salon.Domain.SharedKernel.Measures.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Measures.Strategies
{
    /// <summary>
    /// Provides unit tests for the <see cref="ZeroDurationSubtractionStrategy"/> class.
    /// </summary>
    [TestFixture]
    public class ZeroDurationSubtractionStrategyUnitTests
    {
        private static readonly object[] DurationSubtractionData =
        {
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(10), new MinutesPastAnHour(0)),
                new Duration(new Hours(2), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(8)),
                new Duration(new Hours(0), new MinutesPastAnHour(3))
            },
            new object[]
            {
                new Duration(new Hours(2), new MinutesPastAnHour(10)),
                new Duration(new Hours(1), new MinutesPastAnHour(12))
            }
        };

        /// <summary>
        /// Given the duration of the subtract when called then always returns zero.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        [Test]
        [TestCaseSource(nameof(DurationSubtractionData))]
        public void GivenSubtract_WhenCalled_ThenAlwaysReturnsZeroDuration(
            Duration duration1,
            Duration duration2)
        {
            // ARRANGE
            var expectedDuration = Duration.Zero;
            var strategy = new ZeroDurationSubtractionStrategy();

            // ACT
            var actual = strategy.Subtract(duration1, duration2);

            // ASSERT
            actual.Should().Be(expectedDuration, "because the subtraction of the two durations should equal the special case zero duration.");
        }
    }
}