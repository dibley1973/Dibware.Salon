//-----------------------------------------------------------------------
// <copyright file="BasicDurationSubtractionStrategy.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Guards;

namespace Dibware.Salon.Domain.SharedKernel.Measures.Strategies
{
    /// <summary>
    /// Defines the strategy for subtraction of two <see cref="Duration"/> objects
    /// without carry-over for minutes. <seealso cref="CarryOverMinuteDurationSubtractionStrategy"/>.
    /// </summary>
    /// <seealso cref="IDurationSubtractionStrategy" />
    public class BasicDurationSubtractionStrategy : IDurationSubtractionStrategy
    {
        /// <summary>
        /// Gets a value indicating whether this instance can subtract.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance can subtract; otherwise, <c>false</c>.
        /// </value>
        public bool CanSubtract => true;

        /// <summary>
        /// Subtracts the value of the specified secondary <see cref="Duration"/>
        /// from the specified primary <see cref="Duration"/>. Does not cater for
        /// carrying over minutes. Please use <see cref="CarryOverMinuteDurationSubtractionStrategy"/>
        /// for those operations.
        /// </summary>
        /// <param name="primary">The primary <see cref="Duration"/>.</param>
        /// <param name="secondary">The secondary <see cref="Duration"/>.</param>
        /// <returns>Returns a newly constructed <see cref="Duration"/> with summed values.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the value of primary or secondary is null.
        /// </exception>
        public Duration Subtract(Duration primary, Duration secondary)
        {
            Ensure.IsNotNull(primary, (ArgumentName)nameof(primary));
            Ensure.IsNotNull(secondary, (ArgumentName)nameof(secondary));
            Ensure.IsTrue(
                () => primary.Minutes.CanSubtract(secondary.Minutes),
                $"Cannot subtract secondary minutes to primary minutes. Consider using {nameof(CarryOverMinuteDurationSubtractionStrategy)}");

            var subtractedMinutes = primary.Minutes
                .Subtract(secondary.Minutes);

            var workingHours = primary.Hours
                .Subtract(secondary.Hours);

            var subtractedHours = new Hours(workingHours.Value);

            return new Duration(subtractedHours, subtractedMinutes);
        }
    }
}