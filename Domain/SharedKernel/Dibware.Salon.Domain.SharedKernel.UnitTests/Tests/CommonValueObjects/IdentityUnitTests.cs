//-----------------------------------------------------------------------
// <copyright file="IdentityUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.CommonValueObjects;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.CommonValueObjects
{
    /// <summary>
    /// Test for <see cref="Identity"/> structure
    /// </summary>
    [TestFixture]
    public class IdentityUnitTests
    {
        /// <summary>
        /// Given the create method when called with less than minimum value then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreateMethod_WhenCalledWithLessThanMinimumValue_ThenReturnsFailResult()
        {
            // ARRANGE
            const int value = Identity.MinimumValue -1;

            // ACT
            var actual = Identity.Create(value);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(IdentityErrorKeys.IsLessThanMinimum);
        }

        /// <summary>Given the create method, when called with minimum value then returns success result.</summary>
        [Test]
        public void GivenCreateMethod_WhenCalledWithMinimumValue_ThenReturnsSuccessResult()
        {
            // ARRANGE
            const int value = Identity.MinimumValue;

            // ACT
            var actual = Identity.Create(value);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the equals when supplied same reference the returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedSameReference_TheReturnsTrue()
        {
            // ARRANGE
            const int value1 = 7;
            var identityResult1 = Identity.Create(value1);
            var identity1 = identityResult1.Value;
            var identity2 = identity1;

            // ACT
            var actual = identity1.Equals(identity2);

            // ASSERT
            actual.Should().BeTrue("because the values were identical");
        }

        /// <summary>
        /// Given the equals when supplied same value the returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedSameValue_TheReturnsTrue()
        {
            // ARRANGE
            const int value1 = 7;
            var identityResult1 = Identity.Create(value1);
            var identity1 = identityResult1.Value;
            var identityResult2 = Identity.Create(value1);
            var identity2 = identityResult2.Value;

            // ACT
            var actual = identity1.Equals(identity2);

            // ASSERT
            actual.Should().BeTrue("because the values were identical");
        }

        /// <summary>
        /// Givens the equals when supplied differnt value the returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedDifferntValue_TheReturnsFalse()
        {
            // ARRANGE
            const int value1 = 7;
            var identityResult1 = Identity.Create(value1);
            var identity1 = identityResult1.Value;
            const int value2 = 8;
            var identityResult2 = Identity.Create(value2);
            var identity2 = identityResult2.Value;

            // ACT
            var actual = identity1.Equals(identity2);

            // ASSERT
            actual.Should().BeFalse("because the values were NOT identical");
        }

        /// <summary>
        /// Givens the equals when supplied null value the returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedNullValue_TheReturnsFalse()
        {
            // ARRANGE
            const int value1 = 7;
            const Identity nullIdentity = (Identity)null;
            var identityResult1 = Identity.Create(value1);
            var identity1 = identityResult1.Value;

            // ACT
            var actual = identity1.Equals(nullIdentity);

            // ASSERT
            actual.Should().BeFalse("because the values were NOT identical");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var identity1Result = Identity.Create(4);
            var identity1 = identity1Result.Value;
            var identity2Result = Identity.Create(4);
            var identity2 = identity2Result.Value;

            // ACT
            var actual = identity1.GetHashCode().Equals(identity2.GetHashCode());

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the get hash code, when different values then returns false.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenDifferentValues_ThenReturnsFalse()
        {
            // ARRANGE
            var identity1Result = Identity.Create(1);
            var identity1 = identity1Result.Value;
            var identity2Result = Identity.Create(2);
            var identity2 = identity2Result.Value;

            // ACT
            var actual = identity1.GetHashCode().Equals(identity2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the has value when called after construction then returns true.
        /// </summary>
        [Test]
        public void GivenHasValue_WhenCalledAfterConstruction_ThenReturnsTrue()
        {
            // ARRANGE
            const int value = Identity.MinimumValue + 7;
            var identityResult = Identity.Create(value);
            var identity = identityResult.Value;

            // ACT
            var actual = identity.HasValue;

            // ASSERT
            actual.Should().BeTrue("because there is always a value after successful construction");
        }

        /// <summary>
        /// Given the has value when called for not set then returns false.
        /// </summary>
        [Test]
        public void GivenHasValue_WhenCalledForNotSet_ThenReturnsFalse()
        {
            // ARRANGE

            // ACT
            var actual = Identity.NotSet.HasValue;

            // ASSERT
            actual.Should().BeFalse("because an empty identity never has a value");
        }

        /// <summary>
        /// Given the value when read after valid construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenReadAfterValidConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            const int value = Identity.MinimumValue + 7;
            var identityResult = Identity.Create(value);
            var identity = identityResult.Value;

            // ACT
            var actual = identity.Value;

            // ASSERT
            actual.Should().Be(value, "because the value should be the same as the value passed to the constructor");
        }
    }
}