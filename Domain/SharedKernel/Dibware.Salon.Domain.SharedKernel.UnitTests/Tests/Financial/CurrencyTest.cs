//-----------------------------------------------------------------------
// <copyright file="CurrencyTest.cs" company="Dibware">
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
    ///  Tests for the <see cref="Currency"/> object.
    /// </summary>
    [TestFixture]
    public class CurrencyTest
    {
        /// <summary>
        /// Given the constructor when supplied null <see cref="CurrencyIsoCode"/> then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullIsoCode_ThenThrowsException()
        {
            // ARRANGE
            const CurrencyIsoCode nullCurrencyIsoCode = null;

            // ACT
            Action actual = () => new Currency(nullCurrencyIsoCode);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null ISO code is not permitted for construction");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var gbpIsoCode = "GBP";
            var gbpCurrencyIsoCode = new CurrencyIsoCode(gbpIsoCode);
            var currency1 = new Currency(gbpCurrencyIsoCode);
            var currency2 = new Currency(gbpCurrencyIsoCode);

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
            var isoCode1 = "GBP";
            var currencyIsoCode1 = new CurrencyIsoCode(isoCode1);
            var currency1 = new Currency(currencyIsoCode1);
            var isoCode2 = "USD";
            var currencyIsoCode2 = new CurrencyIsoCode(isoCode2);
            var currency2 = new Currency(currencyIsoCode2);

            // ACT
            var actual = currency1.GetHashCode().Equals(currency2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse("because the money structures have differing values");
        }

        /// <summary>Given the implicit casting from currency when called then correctly casts to currency iso code.</summary>
        [Test]
        public void GivenImplicitCastingFromCurrency_WhenCalled_ThenCorrectlyCastsToCurrencyIsoCode()
        {
            // ARRANGE
            const string validIsoCode = "SEK";
            var currencyIsoCode = new CurrencyIsoCode(validIsoCode);
            var currency = (Currency)currencyIsoCode;

            // ACT
            CurrencyIsoCode actual = currency;

            // ASSERT
            Assert.AreEqual(actual, currency.IsoCode);
        }

        /// <summary>
        /// Given the explicit casting from <see cref="CurrencyIsoCode"/> operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenExplicitCastingFromCurrencyIsoCodeOperator_WhenCalledWithValidValue_ThenCorrectlyCastsValueToCurrency()
        {
            // ARRANGE
            const string validIsoCode = "SEK";
            var currencyIsoCode = new CurrencyIsoCode(validIsoCode);

            // ACT
            var actual = (Currency)currencyIsoCode;

            // ASSERT
            actual.IsoCode.Value.Should().Be(validIsoCode, "because the cast should have been successful");
        }

        /// <summary>
        /// Given the implicit casting from <see cref="CurrencyIsoCode"/> operator when called with valid value then correctly casts value to currency.
        /// </summary>
        [Test]
        public void GivenImplicitCastingFromCurrencyIsoCodeOperator_WhenCalledWithValidValue_ThenCorrectlyCastsValueToCurrency()
        {
            // ARRANGE
            const string validIsoCode = "SEK";
            var currencyIsoCode = new CurrencyIsoCode(validIsoCode);

            // ACT
            Currency actual = currencyIsoCode;

            // ASSERT
            actual.IsoCode.Value.Should().Be(validIsoCode, "because the cast should have been successful");
        }

        /// <summary>
        /// Given the is equal to when supplied with equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var currencyIsoCode1 = new CurrencyIsoCode("DKK");
            var currency1 = new Currency(currencyIsoCode1);
            var currencyIsoCode2 = new CurrencyIsoCode("DKK");
            var currency2 = new Currency(currencyIsoCode2);

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
            var currencyIsoCode1 = new CurrencyIsoCode("DKK");
            var currency1 = new Currency(currencyIsoCode1);
            var currencyIsoCode2 = new CurrencyIsoCode("SEK");
            var currency2 = new Currency(currencyIsoCode2);

            // ACT
            var actual = currency1 == currency2;

            // ASSERT
            actual.Should().BeFalse("because both values were NOT equal.");
        }
    }
}