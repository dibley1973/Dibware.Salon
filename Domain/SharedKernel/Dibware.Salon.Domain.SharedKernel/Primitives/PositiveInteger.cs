//-----------------------------------------------------------------------
// <copyright file="PositiveInteger.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.BaseClasses;
using Dibware.Salon.Domain.SharedKernel.Guards;

namespace Dibware.Salon.Domain.SharedKernel.Primitives
{
    /// <summary>
    /// Represents a zero or positive integer
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class PositiveInteger : ValueObject<PositiveInteger>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveInteger"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the specified value is negative
        /// </exception>
        public PositiveInteger(int value)
        {
            Ensure.IsNotNegative(value, (ArgumentName)nameof(value));

            Value = value;
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public int Value { get; }

        /// <summary>
        /// Override this method with the derived implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(PositiveInteger other)
        {
            return Value.Equals(other.Value);
        }

        /// <summary>
        /// Override this method with the derived implementation of `GetsHashCode`.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="T:System.Int32" /> representation of the hash code
        /// </returns>
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Value.GetHashCode();
                hashCode = hashCode * 373;

                return hashCode;
            }
        }
    }
}