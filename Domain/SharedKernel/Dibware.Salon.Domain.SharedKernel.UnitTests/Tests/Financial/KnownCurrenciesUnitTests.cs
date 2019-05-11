//-----------------------------------------------------------------------
// <copyright file="KnownCurrenciesUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Financial;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Financial
{
    /// <summary>
    /// Unit tests for the <see cref="Currency.KnownCurrencies"/> class.
    /// </summary>
    public class KnownCurrenciesUnitTests
    {
        /// <summary>
        /// Given the known currencies, then has all instances.
        /// </summary>
        [Test]
        public void GivenKnownCurrencies_ThenHasAllInstances()
        {
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.GBP);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.DKK);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.EUR);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.NOK);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.SEK);
            Assert.IsInstanceOf<Currency>(Currency.KnownCurrencies.USD);
        }

        /// <summary>
        /// Given the known currency iso codes then has all instances.
        /// </summary>
        [Test]
        public void GivenKnownCurrencyIsoCodes_ThenHasAllInstances()
        {
            Assert.IsInstanceOf<CurrencyIsoCode>(CurrencyIsoCode.KnownCurrencyIsoCodes.GBP);
            Assert.IsInstanceOf<CurrencyIsoCode>(CurrencyIsoCode.KnownCurrencyIsoCodes.DKK);
            Assert.IsInstanceOf<CurrencyIsoCode>(CurrencyIsoCode.KnownCurrencyIsoCodes.EUR);
            Assert.IsInstanceOf<CurrencyIsoCode>(CurrencyIsoCode.KnownCurrencyIsoCodes.NOK);
            Assert.IsInstanceOf<CurrencyIsoCode>(CurrencyIsoCode.KnownCurrencyIsoCodes.SEK);
            Assert.IsInstanceOf<CurrencyIsoCode>(CurrencyIsoCode.KnownCurrencyIsoCodes.USD);
        }
    }
}