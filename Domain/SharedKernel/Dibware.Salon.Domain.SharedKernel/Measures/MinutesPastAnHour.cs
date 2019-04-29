//-----------------------------------------------------------------------
// <copyright file="MinutesPastAnHour.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.CommonValueObjects;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using Dibware.Salon.Domain.SharedKernel.Guards;
using Dibware.Salon.Domain.SharedKernel.Primitives;

namespace Dibware.Salon.Domain.SharedKernel.Measures
{
    /// <summary>
    /// Represents a measure of minutes with a maximum limit of 60
    /// </summary>
    public sealed class MinutesPastAnHour : LimitedPositiveInteger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MinutesPastAnHour"/> class.
        /// </summary>
        /// <param name="value">The value, which must be less than or equal to <see cref="UpperBoundary"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown is the value is greater than the value of <see cref="UpperBoundary"/>.
        /// </exception>
        public MinutesPastAnHour(int value)
            : base(value)
        {
            if (ValueExceedsUpperBoundary)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Value os {value} exceeds {UpperBoundary}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinutesPastAnHour"/> class.
        /// </summary>
        /// <param name="positiveInteger">Whose value must be less than or equal to <see cref="UpperBoundary"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown is the value of positiveInteger is greater than the value of <see cref="UpperBoundary"/>.
        /// </exception>
        private MinutesPastAnHour(PositiveInteger positiveInteger)
            : this(positiveInteger.Value)
        {
        }

        /// <summary>
        /// Gets the maximum number of minutes upper boundary for the limit.
        /// </summary>
        /// <value>The upper boundary.</value>
        public override int UpperBoundary => 59;

        /// <summary>
        /// Adds the value of the specified other to the value of this instance.
        /// </summary>
        /// <param name="other">The other whose value to add.</param>
        /// <returns>
        /// Returns a newly constructed <see cref="MinutesPastAnHour"/> instance.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value of the other when added to the value of this exceeds the <see cref="UpperBoundary"/> value.
        /// </exception>
        public MinutesPastAnHour Add(MinutesPastAnHour other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));

            if (CanAdd(other))
            {
                return new MinutesPastAnHour(GetAddedCalculatedValue(other));
            }

            throw new ArgumentOutOfRangeException((ArgumentName)nameof(other), other.Value, GetCalculatedValueIsGreaterThanMaxValueMessage(other));
        }

        /// <summary>
        /// Determines whether this instance can add the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if this instance can add the specified other; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">thrown if other is null.</exception>
        public bool CanAdd(MinutesPastAnHour other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));

            return GetAddedCalculatedValue(other).Value <= UpperBoundary;
        }

        /// <summary>
        /// Determines whether this instance can subtract the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if this instance can subtract the specified other; otherwise, <c>false</c>.
        /// </returns>
        public bool CanSubtract(MinutesPastAnHour other)
        {
            return GetSubtractCalculatedValue(other) >= MinimumValue;
        }

        /// <summary>
        /// Subtracts the specified value from this instance.
        /// </summary>
        /// <param name="other">The other whose value is to be subtracted.</param>
        /// <returns>
        /// Returns a newly constructed <see cref="T:Dibware.Salon.Domain.SharedKernel.Primitives.PositiveInteger" /> with the calculated values
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">other</exception>
        public MinutesPastAnHour Subtract(MinutesPastAnHour other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));

            if (CanSubtract(other))
            {
                return new MinutesPastAnHour(GetSubtractCalculatedValue(other));
            }

            throw new ArgumentOutOfRangeException((ArgumentName)nameof(other), other.Value, GetCalculatedValueIsNegativeMessage(other));
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }

        /// <summary>Gets the added calculated value.</summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be added.</param>
        /// <returns>Returns an <see cref="int"/> representation of the calculated value.</returns>
        private PositiveInteger GetAddedCalculatedValue(MinutesPastAnHour other)
        {
            return this + other;
        }

        /// <summary>
        /// Gets the calculated value is greater than maximum message.
        /// </summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be added.</param>
        /// <returns>Returns a <see cref="ShortDescription"/> representation of the message</returns>
        private ShortDescription GetCalculatedValueIsGreaterThanMaxValueMessage(MinutesPastAnHour other)
        {
            return (ShortDescription)$"{MinuteErrorKeys.CalculatedValueIsGreaterThanMax} ( {Value} + {other.Value} = {GetAddedCalculatedValue(other).Value}, Max: {UpperBoundary} )";
        }

        /// <summary>
        /// Gets the calculated value is negative message.
        /// </summary>
        /// <param name="other">The other <see cref="PositiveInteger"/> whose value is to be subtracted.</param>
        /// <returns>Returns a <see cref="ShortDescription"/> representation of the message</returns>
        private ShortDescription GetCalculatedValueIsNegativeMessage(PositiveInteger other)
        {
            return (ShortDescription)$"{PrimitiveErrorKeys.CalculatedValueIsNegative} ( {Value} - {other.Value} )";
        }
    }
}