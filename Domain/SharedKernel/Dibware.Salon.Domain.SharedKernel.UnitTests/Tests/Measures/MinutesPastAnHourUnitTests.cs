//-----------------------------------------------------------------------
// <copyright file="MinutesPastAnHourUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Measures;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Measures
{
    /// <summary>
    /// Provides unit tests for the <see cref="MinutesPastAnHour"/> class.
    /// </summary>
    [TestFixture]
    public class MinutesPastAnHourUnitTests
    {
        /// <summary>
        /// Given the constructor when passed negative number then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedNegativeNumber_ThenThrowsException()
        {
            // ARRANGE
            const int negativeValue = -1;

            // ACT
            Action actual = () => new MinutesPastAnHour(negativeValue);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a negative minutes value is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed zero number then does not throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedZeroNumber_ThenDoesNotThrowsException()
        {
            // ARRANGE
            const int zeroValue = 0;

            // ACT
            Action actual = () => new MinutesPastAnHour(zeroValue);

            // ASSERT
            actual.Should().NotThrow("because a zero minutes value is permitted");
        }

        /// <summary>
        /// Given the constructor when passed positive number within boundary number then does not throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedPositiveNumberWithinBoundaryNumber_ThenDoesNotThrowsException()
        {
            // ARRANGE
            const int lowLimitValue = 1;
            const int topLimitValue = 59;

            // ACT
            Action actual1 = () => new MinutesPastAnHour(lowLimitValue);
            Action actual2 = () => new MinutesPastAnHour(topLimitValue);

            // ASSERT
            actual1.Should().NotThrow("because a 1 minutes value is permitted");
            actual2.Should().NotThrow("because a 12 minutes value is permitted");
        }

        /// <summary>
        /// Given the constructor when passed positive number outside boundary number then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedPositiveNumberOutsideBoundaryNumber_ThenThrowsException()
        {
            // ARRANGE
            const int valueTooBig = 60;

            // ACT
            Action actual = () => new MinutesPastAnHour(valueTooBig);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a 25 minutes value is not permitted");
        }

        /// <summary>
        /// Given the add when supplied with null other then throws exception.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedWithNullOther_ThenThrowsException()
        {
            // ARRANGE
            const MinutesPastAnHour nullMinutesPastAnHour = null;
            var initialMinutesPastAnHour = new MinutesPastAnHour(30);

            // ACT
            Action actual = () => initialMinutesPastAnHour.Add(nullMinutesPastAnHour);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null other is not permitted");
        }

        /// <summary>
        /// Given the add when supplied with other where combined values are greater than upper boundary then returns false.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedWithOtherWhereCombinedValuesAreGreaterThanUpperBoundary_ThenThrowsException()
        {
            // ARRANGE
            var initialMinutesPastAnHour = new MinutesPastAnHour(30);
            var otherMinutesPastAnHour = new MinutesPastAnHour(30);

            // ACT
            Action actual = () => initialMinutesPastAnHour.Add(otherMinutesPastAnHour);

            // ASSERT
            actual.Should().
                Throw<ArgumentOutOfRangeException>("because addition cannot take place if the result would exceed the upper boundary")
                .WithMessage($"CalculatedValueIsGreaterThanMax ( 30 + 30 = 60, Max: 59 )\r\nParameter name: other\r\nActual value was 30.");
        }

        /// <summary>
        /// Given the add when supplied with other where combined values are less than upper boundary then returns true.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedWithOtherWhereCombinedValuesAreLessThanUpperBoundary_ThenReturnsTrue()
        {
            // ARRANGE
            var initialMinutesPastAnHour = new MinutesPastAnHour(30);
            var otherMinutesPastAnHour = new MinutesPastAnHour(29);

            // ACT
            var actual = initialMinutesPastAnHour.Add(otherMinutesPastAnHour);

            // ASSERT
            actual.Value.Should().Be(59, "because the sum should be correct");
            actual.Should().NotBeSameAs(initialMinutesPastAnHour, "because the reference must not be the same as the first");
            actual.Should().NotBeSameAs(otherMinutesPastAnHour, "because the reference must not be the same as the second");
        }

        /// <summary>
        /// Given the can add when supplied with null other then throws exception.
        /// </summary>
        [Test]
        public void GivenCanAdd_WhenSuppliedWithNullOther_ThenThrowsException()
        {
            // ARRANGE
            const MinutesPastAnHour nullMinutesPastAnHour = null;
            var initialMinutesPastAnHour = new MinutesPastAnHour(30);

            // ACT
            Action actual = () => initialMinutesPastAnHour.CanAdd(nullMinutesPastAnHour);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null other is not permitted");
        }

        /// <summary>
        /// Given the can add when supplied with other where combined values are greater than upper boundary then returns false.
        /// </summary>
        [Test]
        public void GivenCanAdd_WhenSuppliedWithOtherWhereCombinedValuesAreGreaterThanUpperBoundary_ThenReturnsFalse()
        {
            // ARRANGE
            var initialMinutesPastAnHour = new MinutesPastAnHour(30);
            var otherMinutesPastAnHour = new MinutesPastAnHour(30);

            // ACT
            var actual = initialMinutesPastAnHour.CanAdd(otherMinutesPastAnHour);

            // ASSERT
            actual.Should().BeFalse("because addition cannot take place if the result would exceed the upper boundary");
        }

        /// <summary>
        /// Given the can add when supplied with other where combined values are less than upper boundary then returns true.
        /// </summary>
        [Test]
        public void GivenCanAdd_WhenSuppliedWithOtherWhereCombinedValuesAreLessThanUpperBoundary_ThenReturnsTrue()
        {
            // ARRANGE
            var initialMinutesPastAnHour = new MinutesPastAnHour(30);
            var otherMinutesPastAnHour = new MinutesPastAnHour(29);

            // ACT
            var actual = initialMinutesPastAnHour.CanAdd(otherMinutesPastAnHour);

            // ASSERT
            actual.Should().BeTrue("because addition can take place if the result would exceed NOT the upper boundary");
        }

        /// <summary>
        /// Given to string when accessed after construction then returns correct formatted text.
        /// </summary>
        [Test]
        public void GivenToString_WhenAccessedAfterConstruction_ThenReturnsCorrectFormattedText()
        {
            // ARRANGE
            var minutesPastAnHour = new MinutesPastAnHour(30);

            // ACT
            var actual = minutesPastAnHour.ToString();

            // ASSERT
            actual.Should().Be("Value: 30");
        }
    }
}