//-----------------------------------------------------------------------
// <copyright file="CurrencyIsoCodeUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Financial;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Financial
{
    /// <summary>
    /// Unit tests for the <see cref="CurrencyIsoCode"/>
    /// </summary>
    public class CurrencyIsoCodeUnitTests
    {
        /// <summary>
        /// Given the <see cref="CurrencyIsoCode.ExpectedIso4217CodeLength"/>, when accessed then should have value of three.
        /// </summary>
        [Test]
        public void GivenExpectedIso4217CodeLength_WhenAccessed_ThenShouldHaveValueOfThree()
        {
            // ARRANGE
            const int expected = 3;

            // ACT
            var actual = CurrencyIsoCode.ExpectedIso4217CodeLength;

            // ASSERT
            actual.Should().Be(expected, "because the value should be the length of an ISO 4217 code");
        }

        /// <summary>
        /// Given the constructor when supplied null ISO code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullIsoCode_ThenThrowsException()
        {
            // ARRANGE
            const string nullIsoCode = null;

            // ACT
            Action actual = () => new CurrencyIsoCode(nullIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied empty ISO code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedEmptyIsoCode_ThenThrowsException()
        {
            // ARRANGE
            const string emptyIsoCode = "";

            // ACT
            Action actual = () => new CurrencyIsoCode(emptyIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because an empty ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied whitespace ISO code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedWhitespaceIsoCode_ThenThrowsException()
        {
            // ARRANGE
            var emptyIsoCode = new string(' ', 3);

            // ACT
            Action actual = () => new CurrencyIsoCode(emptyIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a whitespace ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied ISO code too short then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedIsoCodeTooShort_ThenThrowsException()
        {
            // ARRANGE
            var tooShortIsoCode = "GB";

            // ACT
            Action actual = () => new CurrencyIsoCode(tooShortIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentException>("because a too short an ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied ISO code too long then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedIsoCodeTooLong_ThenThrowsException()
        {
            // ARRANGE
            var tooLongIsoCode = "SPAM";

            // ACT
            Action actual = () => new CurrencyIsoCode(tooLongIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentException>("because a too long an ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied unrecognised iso code then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedUnrecognisedIsoCode_ThenThrowsException()
        {
            // ARRANGE
            var unrecognisedIsoCode = "AAA";

            // ACT
            Action actual = () => new CurrencyIsoCode(unrecognisedIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentException>("because an unrecognised ISO code is not permitted");
        }

        /// <summary>
        /// Given the constructor when supplied valid ISO code then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedValidIsoCode_ThenDoesNotThrowException()
        {
            // ARRANGE
            var tooShortIsoCode = "GBP";

            // ACT
            Action actual = () => new CurrencyIsoCode(tooShortIsoCode);

            // ASSERT
            actual.Should().NotThrow("because a valid ISO code is permitted for construction");
        }

        /// <summary>
        /// Given the Value, when accessed after construction with valid ISO code then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenAccessedAfterConstructionWithValidIsoCode_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var validIsoCode = "GBP";
            var currencyIsoCode = new CurrencyIsoCode(validIsoCode);

            // ACT
            var actual = currencyIsoCode.Value;

            // ASSERT
            actual.Should().Be(validIsoCode, "because the property should hold the constructed value");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var gbpIsoCode = "GBP";
            var currency1 = new CurrencyIsoCode(gbpIsoCode);
            var currency2 = new CurrencyIsoCode(gbpIsoCode);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeTrue("because the money structures have identical values");
        }

        /// <summary>
        /// Given the get hash code, when different values then returns false.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenDifferentValues_ThenReturnsFalse()
        {
            // ARRANGE
            var gbpIsoCode = "GBP";
            var usdIsoCode = "USD";
            var currency1 = new CurrencyIsoCode(gbpIsoCode);
            var currency2 = new CurrencyIsoCode(usdIsoCode);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse("because the money structures have differing values");
        }

        /// <summary>
        /// Given the explicit casting from string operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenExplicitCastingFromStringOperator_WhenCalledWithValidValue_ThenCorrectlyCastsValueToCurrencyIsoCode()
        {
            // ARRANGE
            const string validIsoCode = "SEK";

            // ACT
            var actual = (CurrencyIsoCode)validIsoCode;

            // ASSERT
            actual.Value.Should().Be(validIsoCode, "because the cast should have been successful");
        }

        /// <summary>
        /// Given the explicit casting from string operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenCastingFromStringOperator_WhenCalledWithInvalidValue_ThenCorrectlyCastsValueToCurrencyIsoCode()
        {
            // ARRANGE
            const string validIsoCode = "SPAM";
            object currency = null;

            // ACT
            Action actual = () =>
            {
                currency = (CurrencyIsoCode)validIsoCode;
            };

            // ASSERT
            actual.Should().Throw<ArgumentException>(validIsoCode, "because the cast should NOT have been successful");
            currency.Should().BeNull("because the currency should never be assigned.");
        }

        /// <summary>
        /// Given the is equal to when supplied with equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var currency1 = new CurrencyIsoCode("DKK");
            var currency2 = new CurrencyIsoCode("DKK");

            // ACT
            var actual = currency1 == currency2;

            // ASSERT
            actual.Should().BeTrue("because both values were equal.");
        }

        /// <summary>
        /// Given the is equal to when supplied with non equal values then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithNonEqualValues_ThenReturnsFalse()
        {
            // ARRANGE
            var currency1 = new CurrencyIsoCode("DKK");
            var currency2 = new CurrencyIsoCode("SEK");

            // ACT
            var actual = currency1 == currency2;

            // ASSERT
            actual.Should().BeFalse("because both values were NOT equal.");
        }
    }
}