//-----------------------------------------------------------------------
// <copyright file="CarryOverMinuteDurationSubtractionStrategy.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Guards;
using Dibware.Salon.Domain.SharedKernel.Primitives;

namespace Dibware.Salon.Domain.SharedKernel.Measures.Strategies
{
    /// <summary>
    /// Defines the strategy for subtraction of two <see cref="Duration"/> objects
    /// with carry-over for minutes. <seealso cref="BasicDurationSubtractionStrategy"/>.
    /// </summary>
    /// <seealso cref="IDurationAdditionStrategy" />
    public class CarryOverMinuteDurationSubtractionStrategy : IDurationSubtractionStrategy
    {
        /// <summary>
        /// Gets a value indicating whether this instance can subtract.
        /// </summary>
        /// <value>
        /// Always returns <c>true</c>.
        /// </value>
        public bool CanSubtract => true;

        /// <summary>
        /// Subtracts the value of the specified secondary <see cref="Duration"/>
        /// from the specified primary <see cref="Duration"/>. USe specifically for when
        /// carrying over minutes is required. Otherwise, please use
        /// <see cref="CarryOverMinuteDurationSubtractionStrategy"/> for those operations.
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
            Ensure.IsFalse(
                () => primary.Minutes.CanSubtract(secondary.Minutes),
                $"This strategy should not be used when subtracting secondary minutes to primary minutes is possible. Consider using {nameof(BasicDurationSubtractionStrategy)}");

            PositiveInteger workingMinutes = primary.Minutes;
            PositiveInteger otherMinutes = secondary.Minutes;

            var working = workingMinutes.Value
                - otherMinutes.Value
                + primary.Minutes.UpperBoundary + 1;

            var summedMinutes = new MinutesPastAnHour(working);

            PositiveInteger otherHours = secondary.Hours;

            var workingHours = primary.Hours
                .Subtract(otherHours)
                .Subtract(new PositiveInteger(1));

            var summedHours = new Hours(workingHours.Value);

            return new Duration(summedHours, summedMinutes);
        }
    }
}