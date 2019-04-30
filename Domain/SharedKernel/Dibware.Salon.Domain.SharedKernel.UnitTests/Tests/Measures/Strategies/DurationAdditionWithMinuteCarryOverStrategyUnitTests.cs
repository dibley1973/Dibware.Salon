// <copyright file="DurationAdditionWithMinuteCarryOverStrategyUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;
using Dibware.Salon.Domain.SharedKernel.Measures;
using Dibware.Salon.Domain.SharedKernel.Measures.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Measures.Strategies
{
    /// <summary>
    /// Provides unit tests for the <see cref="CarryOverMinuteDurationAdditionStrategy"/> class.
    /// </summary>
    [TestFixture]
    public class DurationAdditionWithMinuteCarryOverStrategyUnitTests
    {
        private static readonly object[] ValidDurationAdditionData =
        {
            new object[]
            {
                new Duration(new Hours(1), new MinutesPastAnHour(59)),
                new Duration(new Hours(1), new MinutesPastAnHour(2)),
                new Duration(new Hours(3), new MinutesPastAnHour(1))
            },
            new object[]
            {
                new Duration(new Hours(12), new MinutesPastAnHour(40)),
                new Duration(new Hours(2), new MinutesPastAnHour(40)),
                new Duration(new Hours(15), new MinutesPastAnHour(20))
            },
        };

        private static readonly object[] InvalidDurationAdditionData =
        {
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(1), new MinutesPastAnHour(0)),
                new Duration(new Hours(2), new MinutesPastAnHour(0)),
                new Duration(new Hours(3), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(4)),
                new Duration(new Hours(0), new MinutesPastAnHour(5)),
                new Duration(new Hours(0), new MinutesPastAnHour(9))
            },
            new object[]
            {
                new Duration(new Hours(1), new MinutesPastAnHour(4)),
                new Duration(new Hours(2), new MinutesPastAnHour(5)),
                new Duration(new Hours(3), new MinutesPastAnHour(9))
            }
        };

        /// <summary>
        /// Given the add when supplied valid other then returns constructed duration with correct value.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        /// <param name="expectedDuration">The expected duration.</param>
        [Test]
        [TestCaseSource(nameof(ValidDurationAdditionData))]
        public void GivenAdd_WhenSuppliedValidDurations_ThenReturnsConstructedDurationWithCorrectValue(
            Duration duration1,
            Duration duration2,
            Duration expectedDuration)
        {
            // ARRANGE
            var strategy = new CarryOverMinuteDurationAdditionStrategy();

            // ACT
            var actual = strategy.Add(duration1, duration2);

            // ASSERT
            actual.Should().Be(expectedDuration, "because the addition of the two durations should equal the result");
        }

        /// <summary>
        /// Given the add when supplied invalid durations then throws exception.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        /// <param name="expectedDuration">The expected duration.</param>
        [Test]
        [TestCaseSource(nameof(InvalidDurationAdditionData))]
        public void GivenAdd_WhenSuppliedInvalidDurations_ThenThrowsException(
            Duration duration1,
            Duration duration2,
            Duration expectedDuration)
        {
            // ARRANGE
            var strategy = new CarryOverMinuteDurationAdditionStrategy();

            // ACT
            Action actual = () => strategy.Add(duration1, duration2);

            // ASSERT
            actual.Should().Throw<InvalidOperationException>("because minutes of the two specified durations could be added so another strategy should be used");
        }
    }
}