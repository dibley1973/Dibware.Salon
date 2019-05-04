//-----------------------------------------------------------------------
// <copyright file="HoursUnitTests.cs" company="Dibware">
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
    /// Provides unit tests for the <see cref="Hours"/> class.
    /// </summary>
    [TestFixture]
    public class HoursUnitTests
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
            Action actual = () => new Hours(negativeValue);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a negative hours value is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed zero number then does not throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedZeroNumber_ThenDoesNotThrowsException()
        {
            // ARRANGE
            const int negativeValue = 0;

            // ACT
            Action actual = () => new Hours(negativeValue);

            // ASSERT
            actual.Should().NotThrow("because a zero hours value is permitted");
        }

        /// <summary>
        /// Given the constructor when passed positive number within boundary number then does not throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedPositiveNumberWithinBoundaryNumber_ThenDoesNotThrowsException()
        {
            // ARRANGE
            const int lowLimitValue = 1;
            const int topLimitValue = 24;

            // ACT
            Action actual1 = () => new Hours(lowLimitValue);
            Action actual2 = () => new Hours(topLimitValue);

            // ASSERT
            actual1.Should().NotThrow("because a 1 hours value is permitted");
            actual2.Should().NotThrow("because a 12 hours value is permitted");
        }

        /// <summary>
        /// Given the constructor when passed positive number outside boundary number then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedPositiveNumberOutsideBoundaryNumber_ThenThrowsException()
        {
            // ARRANGE
            const int negativeValue = 25;

            // ACT
            Action actual = () => new Hours(negativeValue);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a 25 hours value is not permitted");
        }

        /// <summary>
        /// Given the total number of minutes when accessed then returns number of hours times sixty.
        /// </summary>
        /// <param name="hoursValue">The hours value.</param>
        [Test]
        public void GivenTotalNumberOfMinutes_WhenAccessed_ThenReturnsNumberOfHoursTimesSixty(
            [Values(0, 1, 2, 12, 24)] int hoursValue)
        {
            // ARRANGE
            var hours = new Hours(hoursValue);
            var expected = hoursValue * 60;

            // ACT
            var actual = hours.TotalNumberOfMinutes().Value;

            // ASSERT
            actual.Should().Be(expected, "because the number of minutes should be 60x the number of hours");
        }

        /// <summary>
        /// Given to string when accessed after construction then returns correct formatted text.
        /// </summary>
        [Test]
        public void GivenToString_WhenAccessedAfterConstruction_ThenReturnsCorrectFormattedText()
        {
            // ARRANGE
            var minutesPastAnHour = new Hours(14);

            // ACT
            var actual = minutesPastAnHour.ToString();

            // ASSERT
            actual.Should().Be("Value: 14");
        }

        /// <summary>
        /// Given the special case zero property, when accessed, then returns zero value hour.
        /// </summary>
        [Test]
        public void GivenSpecialCaseZero_WhenAccessed_ThenReturnsZeroValueHour()
        {
            // ARRANGE
            var hours = Hours.Zero;

            // ACT
            var actual = hours.Value;

            // ASSERT
            actual.Should().Be(0, "because a value of zero is expected");
        }
    }
}