// <copyright file="BasicDurationSubtractionStrategyUnitTests.cs" company="Dibware">
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
    /// Provides unit tests for the <see cref="BasicDurationSubtractionStrategy"/> class.
    /// </summary>
    [TestFixture]
    public class BasicDurationSubtractionStrategyUnitTests
    {
        private static readonly object[] ValidDurationSubtractionData =
        {
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(10), new MinutesPastAnHour(0)),
                new Duration(new Hours(2), new MinutesPastAnHour(0)),
                new Duration(new Hours(8), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(8)),
                new Duration(new Hours(0), new MinutesPastAnHour(3)),
                new Duration(new Hours(0), new MinutesPastAnHour(5))
            }
        };

        private static readonly object[] InvalidDurationSubtractionData =
        {
            new object[]
            {
                new Duration(new Hours(2), new MinutesPastAnHour(10)),
                new Duration(new Hours(1), new MinutesPastAnHour(12)),
                new Duration(new Hours(0), new MinutesPastAnHour(58))
            }
        };

        /// <summary>
        /// Given the subtract when supplied with null primary then throws exception.
        /// </summary>
        [Test]
        public void GivenSubtract_WhenSuppliedWithNullPrimary_ThenThrowsException()
        {
            // ARRANGE
            const Duration nullDuration = null;
            var validDuration = new Duration(new Hours(2), new MinutesPastAnHour(10));
            var strategy = new BasicDurationSubtractionStrategy();

            // ACT
            Action actual = () => strategy.Subtract(nullDuration, validDuration);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null primary duration is not permitted");
        }

        /// <summary>
        /// Given the subtract when supplied with null secondary then throws exception.
        /// </summary>
        [Test]
        public void GivenSubtract_WhenSuppliedWithNullSecondary_ThenThrowsException()
        {
            // ARRANGE
            const Duration nullDuration = null;
            var validDuration = new Duration(new Hours(2), new MinutesPastAnHour(10));
            var strategy = new BasicDurationSubtractionStrategy();

            // ACT
            Action actual = () => strategy.Subtract(validDuration, nullDuration);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null secondary duration is not permitted");
        }

        /// <summary>
        /// Given the subtract when supplied valid durations then returns constructed duration with correct value.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        /// <param name="expectedDuration">The expected duration.</param>
        [Test]
        [TestCaseSource(nameof(ValidDurationSubtractionData))]
        public void GivenSubtract_WhenSuppliedValidDurations_ThenReturnsConstructedDurationWithCorrectValue(
            Duration duration1,
            Duration duration2,
            Duration expectedDuration)
        {
            // ARRANGE
            var strategy = new BasicDurationSubtractionStrategy();

            // ACT
            var actual = strategy.Subtract(duration1, duration2);

            // ASSERT
            actual.Should().Be(expectedDuration, "because the addition of the two durations should equal the result");
        }

        /// <summary>
        /// Given the subtract when supplied invalid durations then throws exception.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        /// <param name="expectedDuration">The expected duration.</param>
        [Test]
        [TestCaseSource(nameof(InvalidDurationSubtractionData))]
        public void GivenSubtract_WhenSuppliedInvalidDurations_ThenThrowsException(
            Duration duration1,
            Duration duration2,
            Duration expectedDuration)
        {
            // ARRANGE
            var strategy = new BasicDurationSubtractionStrategy();

            // ACT
            Action actual = () => strategy.Subtract(duration1, duration2);

            // ASSERT
            actual.Should().Throw<InvalidOperationException>("because minutes of the two specified durations can not be added");
        }
    }
}