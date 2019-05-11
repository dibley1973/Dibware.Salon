//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.BaseClasses;

// ReSharper disable InconsistentNaming
namespace Dibware.Salon.Domain.SharedKernel.Financial
{
    /// <summary>
    /// Encapsulates currency data and behaviour.
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class Currency : ValueObject<Currency>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Currency"/> class.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if isoCode is null, empty or white space.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified ISO currency code appears to be invalid.
        /// </exception>
        internal Currency(CurrencyIsoCode isoCode)
        {
            IsoCode = isoCode ??
                throw new ArgumentNullException(nameof(isoCode));
        }

        /// <summary>
        /// Gets the three letter ISO 4217 code.
        /// </summary>
        /// <value>
        /// The three letter ISO 4217 code.
        /// </value>
        public CurrencyIsoCode IsoCode { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CurrencyIsoCode"/> to <see cref="Currency"/>.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Currency(CurrencyIsoCode isoCode)
        {
            return new Currency(isoCode);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Currency"/> to <see cref="CurrencyIsoCode"/>.
        /// </summary>
        /// <param name="currency">The three letter ISO 4217 code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CurrencyIsoCode(Currency currency)
        {
            return currency.IsoCode;
        }

        /// <summary>
        /// Instance specific implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Currency other)
        {
            return IsoCodesMatch(other);
        }

        /// <summary>
        /// Instance specific implementation of `GetHashCode`.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="T:System.Int32" /> representation of the hash code
        /// </returns>
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = IsoCode.GetHashCode();

                hashCode = hashCode * 373;

                return hashCode;
            }
        }

        /// <summary>
        /// Determines if the three letter ISO codes for the current instance and the specified
        /// <see cref="Currency"/> match.
        /// </summary>
        /// <param name="other">The other <see cref="Currency"/> to check.</param>
        /// <returns>
        ///   <c>true</c> if the ISO codes match; otherwise, <c>false</c>.
        /// </returns>
        private bool IsoCodesMatch(Currency other)
        {
            return Equals(other.IsoCode, IsoCode);
        }

        /// <summary>
        /// Encapsulates known currencies
        /// </summary>
        public static class KnownCurrencies
        {
            /// <summary>
            /// The Pound Sterling currency
            /// </summary>
            public static readonly Currency GBP = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.GBP);

            /// <summary>
            /// The Danish krone currency
            /// </summary>
            public static readonly Currency DKK = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.DKK);

            /// <summary>
            /// The euro currency
            /// </summary>
            public static readonly Currency EUR = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.EUR);

            /// <summary>
            /// The Norwegian krone currency
            /// </summary>
            public static readonly Currency NOK = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.NOK);

            /// <summary>
            /// The Swedish krona/kronor currency
            /// </summary>
            public static readonly Currency SEK = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.SEK);

            /// <summary>
            /// The US dollar currency
            /// </summary>
            public static readonly Currency USD = new Currency(CurrencyIsoCode.KnownCurrencyIsoCodes.USD);
        }
    }
}