//-----------------------------------------------------------------------
// <copyright file="BasicDurationAdditionStrategy.cs" company="Dibware">
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
    /// Defines the strategy for addition of two <see cref="Duration"/> objects
    /// with no carry-over for minutes
    /// </summary>
    /// <seealso cref="IDurationAdditionStrategy" />
    public class BasicDurationAdditionStrategy : IDurationAdditionStrategy
    {
        /// <summary>
        /// Adds the value of the specified secondary <see cref="Duration" />
        /// to the specified primary <see cref="Duration" />.
        /// </summary>
        /// <param name="primary">The primary <see cref="Duration" />.</param>
        /// <param name="secondary">The secondary <see cref="Duration" />.</param>
        /// <returns>
        /// Returns a newly constructed <see cref="Duration" /> with summed values.
        /// </returns>
        public Duration Add(Duration primary, Duration secondary)
        {
            Ensure.IsNotNull(secondary, (ArgumentName)nameof(secondary));
            Ensure.IsTrue(
                () => primary.Minutes.CanAdd(secondary.Minutes),
                $"Cannot add secondary minutes to primary minutes. Consider using {nameof(CarryOverMinuteDurationAdditionStrategy)}");

            var summedMinutes = primary.Minutes
                .Add(secondary.Minutes);

            PositiveInteger otherHours = secondary.Hours;

            var workingHours = primary.Hours
                .Add(otherHours);

            var summedHours = new Hours(workingHours.Value);

            return new Duration(summedHours, summedMinutes);
        }
    }
}