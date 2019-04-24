﻿//-----------------------------------------------------------------------
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
    }
}