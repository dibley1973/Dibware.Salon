//-----------------------------------------------------------------------
// <copyright file="Duration.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.BaseClasses;
using Dibware.Salon.Domain.SharedKernel.Guards;
using Dibware.Salon.Domain.SharedKernel.Measures.Factories;
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the value of hours or minutes is null.
        /// </exception>
        public Duration(Hours hours, MinutesPastAnHour minutes)
        {
            Ensure.IsNotNull(hours, (ArgumentName)nameof(hours));
            Ensure.IsNotNull(minutes, (ArgumentName)nameof(minutes));

            Hours = hours;
            Minutes = minutes;
        }

        /// <summary>Gets the hours passed in the duration.</summary>
        /// <value>The number of hours as a <see cref="PositiveInteger"/></value>
        public Hours Hours { get; }

        /// <summary> Gets the minutes passed in the duration following after the last complete hour. </summary>
        /// <value> The number of minutes as a <see cref="PositiveInteger"/>. </value>
        public MinutesPastAnHour Minutes { get; }

        /// <summary>
        /// Implementation of the + operator. Adds the values of the two specified instances
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Duration operator +(Duration primary, Duration secondary)
        {
            Ensure.IsNotNull(primary, (ArgumentName)nameof(primary));
            Ensure.IsNotNull(secondary, (ArgumentName)nameof(secondary));

            return primary.Add(secondary);
        }

        /// <summary>
        /// Implementation of the - operator. Subtracts the values of the secondary
        /// specified <see cref="Duration"/> from the first specified <see cref="Duration"/>.
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Duration operator -(Duration primary, Duration secondary)
        {
            Ensure.IsNotNull(primary, (ArgumentName)nameof(primary));
            Ensure.IsNotNull(secondary, (ArgumentName)nameof(secondary));

            return primary.Subtract(secondary);
        }

        /// <summary>Adds the specified other.</summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns a newly constructed <see cref="Duration"/> with summed values.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown if the value of other is null.</exception>
        public Duration Add(Duration other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));

            var strategy = DurationStrategiesFactory.GetDurationAdditionStrategy(MinutesCanBeAdded(other));

            var duration = strategy.Add(this, other);

            return duration;
        }

        /// <summary>Subtracts the value of the specified secondary <see cref="Duration"/>
        /// from the specified primary <see cref="Duration"/>.</summary>
        /// <param name="other">The secondary <see cref="Duration"/>.</param>
        /// <returns>Returns a newly constructed <see cref="Duration"/> with summed values.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the value of primary or secondary is null.
        /// </exception>
        public Duration Subtract(Duration other)
        {
            Ensure.IsNotNull(other, (ArgumentName)nameof(other));

            int workingMinutes = Minutes - other.Minutes;
            int workingHours = Hours - other.Hours;

            if (workingMinutes < 0)
            {
                workingMinutes = workingMinutes + Minutes.UpperBoundary;
                workingHours = workingHours - 1;
            }

            if (workingHours < 0)
            {
                throw new ArgumentOutOfRangeException((ArgumentName)nameof(other), "message");
            }

            return new Duration(new Hours(workingHours), new MinutesPastAnHour(workingMinutes));
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{nameof(Hours)}: {Hours.Value}, {nameof(Minutes)}: {Minutes.Value}";
        }

        /// <summary>
        /// Calculates the total number of minutes.
        /// </summary>
        /// <returns>The total number of minutes as a <see cref="PositiveInteger"/></returns>
        public Minutes TotalNumberOfMinutes() => new Minutes(GetTotalNumberOfMinutes().Value);

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
        /// <returns>Returns a <see cref="T:System.Int32"/> representation of the hash code</returns>
        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Hours.GetHashCode();
                hashCode = (hashCode * 397) ^ Minutes.GetHashCode();

                return hashCode;
            }
        }

        /// <summary>Gets the total number of minutes.</summary>
        /// <returns>Returns a <see cref="PositiveInteger"/> representing the total number of minutes.</returns>
        private PositiveInteger GetTotalNumberOfMinutes()
        {
            return Hours.TotalNumberOfMinutes().Add(Minutes);
        }

        /// <summary>Gets a value indicating if minutes can be added, or not.</summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// Returns <c>true</c> if the minutes can be added; otherwise <c>false</c>.
        /// </returns>
        private bool MinutesCanBeAdded(Duration other)
        {
            return Minutes.CanAdd(other.Minutes);
        }
    }
}