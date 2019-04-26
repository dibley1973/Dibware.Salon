//-----------------------------------------------------------------------
// <copyright file="MinutesUnitTests.cs" company="Dibware">
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
    /// Provides unit tests for the <see cref="Minutes"/> class.
    /// </summary>
    [TestFixture]
    public class MinutesUnitTests
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
            Action actual = () => new Minutes(negativeValue);

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
            const int negativeValue = 0;

            // ACT
            Action actual = () => new Minutes(negativeValue);

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
            Action actual1 = () => new Minutes(lowLimitValue);
            Action actual2 = () => new Minutes(topLimitValue);

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
            const int negativeValue = 60;

            // ACT
            Action actual = () => new Minutes(negativeValue);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a 25 minutes value is not permitted");
        }
    }
}