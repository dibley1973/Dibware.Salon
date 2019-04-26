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
using Dibware.Salon.Domain.SharedKernel.CommonValueObjects;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using Dibware.Salon.Domain.SharedKernel.Guards;

namespace Dibware.Salon.Domain.SharedKernel.Primitives
{
    /// <summary>
    /// Represents a zero or positive integer
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class PositiveInteger : ValueObject<PositiveInteger>
    {
        /// <summary>The maximum value this instance can hold</summary>
        public const int MaximumValue = int.MaxValue;

        /// <summary>
        /// The minimum value this instance can hold
        /// </summary>
        public const int MinimumValue = 0;

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
        /// Adds the specified value to this instance.
        /// </summary>
        /// <param name="other">The other whose value is to be added.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        /// <returns>
        /// Returns a newly constructed <see cref="PositiveInteger"/> with the calculated values
        /// </returns>
        public PositiveInteger Add(PositiveInteger other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));
            Ensure.IsNotGreaterThanIntMaxValue(
                GetAddedCalculatedValue(other),
                (ArgumentName)nameof(other),
                GetCalculatedValueIsGreaterThanIntMaxValueMessage(other));

            return new PositiveInteger((int)GetAddedCalculatedValue(other));
        }

        /// <summary>
        /// Determines whether this instance can add the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if this instance can add the specified other; otherwise, <c>false</c>.
        /// </returns>
        public bool CanAdd(PositiveInteger other)
        {
            return GetAddedCalculatedValue(other) <= MaximumValue;
        }

        /// <summary>
        /// Determines whether this instance can subtract the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if this instance can subtract the specified other; otherwise, <c>false</c>.
        /// </returns>
        public bool CanSubtract(PositiveInteger other)
        {
            return GetSubtractCalculatedValue(other) >= MinimumValue;
        }

        /// <summary>
        /// Subtracts the specified value.
        /// </summary>
        /// <param name="other">The other whose value is to be added.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        /// <returns>
        /// Returns a newly constructed <see cref="PositiveInteger"/> with the calculated values
        /// </returns>
        public PositiveInteger Subtract(PositiveInteger other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));
            Ensure.IsNotNegative(
                GetSubtractCalculatedValue(other),
                (ArgumentName)nameof(other),
                GetCalculatedValueIsNegativeMessage(other));

            return new PositiveInteger(GetSubtractCalculatedValue(other));
        }

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

        /// <summary>Gets the added calculated value.</summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be added.</param>
        /// <returns>Returns an <see cref="int"/> representation of the calculated value.</returns>
        private long GetAddedCalculatedValue(PositiveInteger other)
        {
            return (long)Value + other.Value;
        }

        /// <summary>
        /// Gets the calculated value is negative message.
        /// </summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be subtracted.</param>
        /// <returns>Returns a <see cref="ShortDescription"/> representation of the message</returns>
        private ShortDescription GetCalculatedValueIsNegativeMessage(PositiveInteger other)
        {
            return (ShortDescription)$"{PrimitiveErrorkeys.CalculatedValueIsNegative} ( {Value} - {other.Value} )";
        }

        /// <summary>
        /// Gets the calculated value is greater than int maximum message.
        /// </summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be added.</param>
        /// <returns>Returns a <see cref="ShortDescription"/> representation of the message</returns>
        private ShortDescription GetCalculatedValueIsGreaterThanIntMaxValueMessage(PositiveInteger other)
        {
            return (ShortDescription)$"{PrimitiveErrorkeys.CalculatedValueIsGreaterThanIntMax} ( {Value} + {other.Value} 0";
        }

        /// <summary>Gets the subtract calculated value.</summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be subtracted.</param>
        /// <returns>Returns an <see cref="int"/> representation of the calculated value.</returns>
        private int GetSubtractCalculatedValue(PositiveInteger other)
        {
            return Value - other.Value;
        }
    }
}