// <copyright file="PositiveIntegerUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.Primitives;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Primitives
{
    /// <summary>
    /// Provides unit tests for the <see cref="PositiveInteger"/> class.
    /// </summary>
    [TestFixture]
    public class PositiveIntegerUnitTests
    {
        /// <summary>Given the constructor when passed negative value throws exception.</summary>
        [Test]
        public void GivenConstructor_WhenPassedNegativeValue_ThenThrowsException()
        {
            // ARRANGE
            const int negativeNumber = -1;

            // ACT
            Action actual = () => new PositiveInteger(negativeNumber);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a null object is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed a non negative value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedANonNegativeValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const int argumentValue1 = 0;
            const int argumentValue2 = 1;

            // ACT
            Action action1 = () => new PositiveInteger(argumentValue1);
            Action action2 = () => new PositiveInteger(argumentValue2);

            // ASSERT
            action1.Should().NotThrow<ArgumentNullException>();
            action2.Should().NotThrow<ArgumentNullException>();
        }
    }
}