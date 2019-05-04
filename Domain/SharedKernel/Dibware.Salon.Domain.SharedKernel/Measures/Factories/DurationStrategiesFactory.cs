//-----------------------------------------------------------------------
// <copyright file="DurationStrategiesFactory.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using Dibware.Salon.Domain.SharedKernel.Measures.Strategies;

namespace Dibware.Salon.Domain.SharedKernel.Measures.Factories
{
    /// <summary>
    /// A factory for creating and returning strategies for
    /// the <see cref="Duration"/> object.
    /// </summary>
    public static class DurationStrategiesFactory
    {
        private static readonly Dictionary<bool, IDurationAdditionStrategy> DurationAdditionStrategies =
            new Dictionary<bool, IDurationAdditionStrategy>
            {
                { DurationMinuteAddingBehaviour.CanAddMinutes, new BasicDurationAdditionStrategy() },
                { DurationMinuteAddingBehaviour.CannotAddMinutes, new CarryOverMinuteDurationAdditionStrategy() }
            };

        /// <summary>
        /// Gets the duration addition strategy for the specified state.
        /// </summary>
        /// <param name="canAddMinutes">Set to <c>true</c> if minutes can be added; otherwise <c>false</c>.</param>
        /// <returns>
        /// Returns a correct <see cref="IDurationAdditionStrategy"/> for the specified state.
        /// </returns>
        public static IDurationAdditionStrategy GetDurationAdditionStrategy(bool canAddMinutes)
        {
            return DurationAdditionStrategies[canAddMinutes];
        }

        /// <summary>
        /// Gets the appropriate <see cref="IDurationSubtractionStrategy"/> for subtracting
        /// the specified secondary <see cref="Duration"/> from the specified primary
        /// <see cref="Duration"/>.
        /// </summary>
        /// <param name="primary">The primary <see cref="Duration"/>.</param>
        /// <param name="secondary">The secondary <see cref="Duration"/>.</param>
        /// <returns>
        /// Returns a duration strategy that implements <see cref="IDurationSubtractionStrategy"/>.
        /// </returns>
        public static IDurationSubtractionStrategy GetDurationSubtractionStrategy(Duration primary, Duration secondary)
        {
            if (MinutesCanBeSubtractedWithoutCarryingOverAnHour(primary, secondary))
            {
                return new BasicDurationSubtractionStrategy();
            }

            if (HoursWithOneHourCarryOverCanBeSubtracted(primary, secondary))
            {
                return new CarryOverMinuteDurationSubtractionStrategy();
            }

            return new ZeroDurationSubtractionStrategy();
        }

        /// <summary>
        /// Determines if the minutes from the specified secondary <see cref="Duration"/>
        /// can be subtracted from the minutes from the specified primary
        /// <see cref="Duration"/> without needing to carry-over an hour.
        /// </summary>
        /// <param name="primary">The primary <see cref="Duration"/>.</param>
        /// <param name="secondary">The secondary <see cref="Duration"/>.</param>
        /// <returns>
        /// Returns <c>true</c> if the minutes can be taken away without carrying
        /// the hour; otherwise <c>false</c>.
        /// </returns>
        private static bool MinutesCanBeSubtractedWithoutCarryingOverAnHour(Duration primary, Duration secondary)
        {
            return primary.Minutes.CanSubtract(secondary.Minutes);
        }

        /// <summary>
        /// Determines is the number of <see cref="Hours"/> from the specified
        /// secondary <see cref="Duration"/> can be subtracted from the hours of
        /// the specified primary Duration when combined with an extra hour for
        /// carry-over purposes.
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        /// Returns <c>true</c> if the hours can be taken away taking into consideration
        /// the extra hour for carry-over; otherwise <c>false</c>.
        /// </returns>
        private static bool HoursWithOneHourCarryOverCanBeSubtracted(Duration primary, Duration secondary)
        {
            return primary.Hours.CanSubtract(secondary.Hours) &&
                   primary.Hours.Subtract(secondary.Hours)
                       .CanSubtract(new Hours(1));
        }
    }
}