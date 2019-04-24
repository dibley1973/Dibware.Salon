//-----------------------------------------------------------------------
// <copyright file="Duration.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.BaseClasses;
using Dibware.Salon.Domain.SharedKernel.Guards;
using Dibware.Salon.Domain.SharedKernel.Primitives;

namespace Dibware.Salon.Domain.SharedKernel.Measures
{
    /// <summary>
    /// Represents a duration in time measured in hours and minutes
    /// </summary>
    /// <seealso cref="ValueObject{T}" />
    public class Duration : ValueObject<Duration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Duration"/> class.
        /// </summary>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        public Duration(PositiveInteger hour, PositiveInteger minute)
        {
            Ensure.IsNotNull(hour, (ArgumentName)nameof(hour));
            Ensure.IsNotNull(minute, (ArgumentName)nameof(minute));

            Hour = hour;
            Minute = minute;
        }

        /// <summary>Gets the hour.</summary>
        /// <value>The hour.</value>
        public PositiveInteger Hour { get; }

        /// <summary> Gets the minute. </summary>
        /// <value> The minute. </value>
        public PositiveInteger Minute { get; }

        /// <summary>
        /// Override this method with the derived implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Duration other)
        {
            return Hour == other.Hour && Minute == other.Minute;
        }

        /// <summary>Override this method with the derived implementation of `GetsHashCode`.</summary>
        /// <returns>Returns a <see cref="T:System.Int32"/> representation of the has code</returns>
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Hour.GetHashCode();
                hashCode = (hashCode * 397) ^ Minute.GetHashCode();

                return hashCode;
            }
        }
    }
}