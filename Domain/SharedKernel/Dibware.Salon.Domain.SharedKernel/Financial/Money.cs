// <copyright file="Money.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;
using Dibware.Salon.Domain.SharedKernel.BaseClasses;

namespace Dibware.Salon.Domain.SharedKernel.Financial
{
    /// <summary>
    /// Encapsulates money data and behaviour.
    /// </summary>
    /// <seealso cref="Currency" />
    /// <seealso cref="ValueObject{T}" />
    public class Money : ValueObject<Money>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Money"/> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currency">The currency.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if currency is null
        /// </exception>
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public Currency Currency { get; }

        /// <summary>
        /// Instance specific implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Money other)
        {
            return Amount == other.Amount && Currency == other.Currency;
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
                int hashCode = Amount.GetHashCode();
                hashCode = (hashCode * 397) ^ Currency.GetHashCode();

                return hashCode;
            }
        }
    }
}