//-----------------------------------------------------------------------
// <copyright file="DurationSubtractionStrategyIndicator.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Measures.Factories
{
    /// <summary>
    /// Defines the available subtraction strategies for the <see cref="Duration"/>
    /// </summary>
    public enum DurationSubtractionStrategyIndicator
    {
        /// <summary>
        /// Indicates the basic duration addition strategy
        /// </summary>
        BasicDurationAdditionStrategy,

        /// <summary>
        /// Indicates the carry over minute duration subtraction strategy
        /// </summary>
        CarryOverMinuteDurationSubtractionStrategy,

        /// <summary>
        /// Indicates the zero duration subtraction strategy
        /// </summary>
        ZeroDurationSubtractionStrategy
    }
}