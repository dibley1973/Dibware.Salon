//-----------------------------------------------------------------------
// <copyright file="CurrencyIsoCode.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Dibware.Salon.Domain.SharedKernel.BaseClasses;

// ReSharper disable InconsistentNaming
namespace Dibware.Salon.Domain.SharedKernel.Financial
{
    /// <summary>
    /// Encapsulates currency data and behaviour.
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class CurrencyIsoCode : ValueObject<CurrencyIsoCode>
    {
        /// <summary>
        /// The expected iso4217 code length
        /// </summary>
        public const int ExpectedIso4217CodeLength = 3;

        /// <summary>
        /// The whitelist
        /// </summary>
        internal static readonly HashSet<string> Whitelist = new HashSet<string>
        {
            "GBP",
            "DKK",
            "EUR",
            "NOK",
            "SEK",
            "USD"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyIsoCode"/> class.
        /// </summary>
        /// <param name="value">The three letter ISO 4217 code.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if isoCode is null, empty or white space.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if the specified ISO currency code appears to be invalid.
        /// </exception>
        internal CurrencyIsoCode(string value)
        {
            EnsureNotNullOrWhiteSpace(value);
            EnsureCorrectLength(value);
            EnsureOnTheWhiteList(value);

            Value = value;
        }

        /// <summary>
        /// Gets the three letter ISO 4217 code.
        /// </summary>
        /// <value>
        /// The three letter ISO 4217 code.
        /// </value>
        public string Value { get; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="Currency"/>.
        /// </summary>
        /// <param name="isoCode">The three letter ISO 4217 code.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator CurrencyIsoCode(string isoCode)
        {
            return new CurrencyIsoCode(isoCode);
        }

        /// <summary>
        /// Instance specific implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(CurrencyIsoCode other)
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
                int hashCode = Value.GetHashCode();

                hashCode = hashCode * 383;

                return hashCode;
            }
        }

        /// <summary>
        /// Ensures value is on the white list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">The value of {nameof(value)}</exception>
        private static void EnsureOnTheWhiteList(string value)
        {
            if (IsNotOnWhiteList(value))
            {
                throw new ArgumentException($"The value of {nameof(value)} is an unrecognised ISO currency code");
            }
        }

        /// <summary>
        /// Ensures value is the length of the correct.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentException">Specified ISO code length was incorrect. Expected length of {ExpectedIso4217CodeLength}</exception>
        private static void EnsureCorrectLength(string value)
        {
            if (value.Length != ExpectedIso4217CodeLength)
            {
                throw new ArgumentException(
                    $"Specified ISO code length was incorrect. Expected length of {ExpectedIso4217CodeLength}",
                    value);
            }
        }

        /// <summary>
        /// Ensures value is not null or white space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">value</exception>
        private static void EnsureNotNullOrWhiteSpace(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        /// Determines whether the specified value is not on white list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is not on white list; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsNotOnWhiteList(string value)
        {
            return !Whitelist.Contains(value);
        }

        /// <summary>
        /// Determines if the three letter ISO codes for the current instance and the iso
        /// code for the specified <see cref="CurrencyIsoCode"/> match.
        /// </summary>
        /// <param name="other">The other <see cref="CurrencyIsoCode"/> to check.</param>
        /// <returns>
        ///   <c>true</c> if the ISO codes match; otherwise, <c>false</c>.
        /// </returns>
        private bool IsoCodesMatch(CurrencyIsoCode other)
        {
            return Equals(other.Value, Value);
        }

        /// <summary>
        /// Encapsulates known currency ISO codes
        /// </summary>
        public static class KnownCurrencyIsoCodes
        {
            /// <summary>
            /// The Pound Sterling currency ISO code
            /// </summary>
            public static readonly CurrencyIsoCode GBP = new CurrencyIsoCode("GBP");

            /// <summary>
            /// The Danish krone currency ISO code
            /// </summary>
            public static readonly CurrencyIsoCode DKK = new CurrencyIsoCode("DKK");

            /// <summary>
            /// The euro currency ISO code
            /// </summary>
            public static readonly CurrencyIsoCode EUR = new CurrencyIsoCode("EUR");

            /// <summary>
            /// The Norwegian krone currency ISO code
            /// </summary>
            public static readonly CurrencyIsoCode NOK = new CurrencyIsoCode("NOK");

            /// <summary>
            /// The Swedish krona/kronor currency ISO code
            /// </summary>
            public static readonly CurrencyIsoCode SEK = new CurrencyIsoCode("SEK");

            /// <summary>
            /// The US dollar currency ISO code
            /// </summary>
            public static readonly CurrencyIsoCode USD = new CurrencyIsoCode("USD");
        }
    }
}