//-----------------------------------------------------------------------
// <copyright file="MoneyUnitTests.cs" company="Dibware">
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
    ///  Tests for the <see cref="Money"/> object.
    /// </summary>
    [TestFixture]
    public class MoneyUnitTests
    {
        private const decimal ValidAmount = 4711;

        /// <summary>
        /// Given the constructor when supplied null currency then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedNullCurrency_ThenThrowsException()
        {
            // ARRANGE
            const Currency nullCurrency = null;

            // ACT
            Action actual = () => new Money(ValidAmount, nullCurrency);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null currency is not permitted for construction");
        }

        /// <summary>
        /// Given the constructor when supplied valid currency then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenSuppliedValidCurrency_ThenDoesNotThrowException()
        {
            // ARRANGE
            var validCurrency = Currency.KnownCurrencies.SEK;

            // ACT
            Action actual = () => new Money(ValidAmount, validCurrency);

            // ASSERT
            actual.Should().NotThrow("because no exception should be thrown for valid currency values");
        }

        /// <summary>
        /// Given the amount when accessed after construction then contains constructed value.
        /// </summary>
        [Test]
        public void GivenAmount_WhenAccessedAfterConstruction_ThenContainsConstructedValue()
        {
            // ARRANGE
            var money = new Money(ValidAmount, Currency.KnownCurrencies.SEK);

            // ACT
            var actual = money.Amount;

            // ASSERT
            actual.Should().Be(ValidAmount, "because the value should match the constructed value");
        }

        /// <summary>
        /// Given the currency when accessed after construction then contains constructed value.
        /// </summary>
        [Test]
        public void GivenCurrency_WhenAccessedAfterConstruction_ThenContainsConstructedValue()
        {
            // ARRANGE
            var money = new Money(4711, Currency.KnownCurrencies.SEK);

            // ACT
            var actual = money.Currency;

            // ASSERT
            actual.Should().Be(Currency.KnownCurrencies.SEK, "because the value should match the constructed value");
        }

        /// <summary>
        /// Given the get hash code, when same values then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValues_ThenReturnsTrue()
        {
            // ARRANGE
            var money1 = new Money(13, Currency.KnownCurrencies.GBP);
            var money2 = new Money(13, Currency.KnownCurrencies.GBP);

            // ACT
            var actual = money1.GetHashCode().Equals(money2.GetHashCode());

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
            var money1 = new Money(13, Currency.KnownCurrencies.GBP);
            var money2 = new Money(13, Currency.KnownCurrencies.DKK);
            var money3 = new Money(14, Currency.KnownCurrencies.DKK);

            // ACT
            var actual1 = money1.GetHashCode().Equals(money2.GetHashCode());
            var actual2 = money2.GetHashCode().Equals(money3.GetHashCode());

            // ASSERT
            actual1.Should().BeFalse("because the money structures have differing values");
            actual2.Should().BeFalse("because the money structures have differing values");
        }

        /// <summary>
        /// Given the is equal to when supplied with equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var money1 = new Money(13, Currency.KnownCurrencies.DKK);
            var money2 = new Money(13, Currency.KnownCurrencies.DKK);

            // ACT
            var actual = money1 == money2;

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
            var money1 = new Money(13, Currency.KnownCurrencies.DKK);
            var money2 = new Money(13, Currency.KnownCurrencies.SEK);

            // ACT
            var actual = money1 == money2;

            // ASSERT
            actual.Should().BeFalse("because both values were NOT equal.");
        }
    }
}