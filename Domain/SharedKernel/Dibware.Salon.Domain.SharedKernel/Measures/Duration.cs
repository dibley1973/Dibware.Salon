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
        /// <param name="hours">The hours.</param>
        /// <param name="minutes">The minutes.</param>
        public Duration(PositiveInteger hours, PositiveInteger minutes)
        {
            Ensure.IsNotNull(hours, (ArgumentName)nameof(hours));
            Ensure.IsNotNull(minutes, (ArgumentName)nameof(minutes));

            Hours = hours;
            Minutes = minutes;
        }

        /// <summary>Gets the number of minutes in an hour.</summary>
        /// <value>The minutes in hour.</value>
        public static PositiveInteger NumberOfMinutesInAnHour => new PositiveInteger(60);

        /// <summary>Gets the hours passed in the duration.</summary>
        /// <value>The number of hours</value>
        public PositiveInteger Hours { get; }

        /// <summary> Gets the minutes passed in the duration following after the last complete hour. </summary>
        /// <value> The number of minutes. </value>
        public PositiveInteger Minutes { get; }

        // TODO: Uncomment when Positive integer addition implementation is ready
        //public PositiveInteger TotalMinutes() => (Hours * NumberOfMinutesInAnHour + Minutes);

        /// <summary>
        /// Override this method with the derived implementation of `Equals`.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if it equals; otherwise <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(Duration other)
        {
            return Hours == other.Hours && Minutes == other.Minutes;
        }

        /// <summary>Override this method with the derived implementation of `GetsHashCode`.</summary>
        /// <returns>Returns a <see cref="T:System.Int32"/> representation of the has code</returns>
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Hours.GetHashCode();
                hashCode = (hashCode * 397) ^ Minutes.GetHashCode();

                return hashCode;
            }
        }
    }
}