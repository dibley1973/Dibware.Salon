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
    }
}