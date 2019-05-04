//-----------------------------------------------------------------------
// <copyright file="ZeroDurationSubtractionStrategy.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Measures.Strategies
{
    /// <summary>
    /// Defines the strategy for subtraction of two <see cref="Duration"/> objects
    /// where the result is always zero.
    /// </summary>
    /// <seealso cref="IDurationSubtractionStrategy" />
    public class ZeroDurationSubtractionStrategy : IDurationSubtractionStrategy
    {
        /// <summary>
        /// Gets a value indicating whether this instance can subtract.
        /// </summary>
        /// <value>
        /// Always returns <c>false</c>.
        /// </value>
        public bool CanSubtract => false;

        /// <summary>
        /// Subtracts the value of the specified secondary <see cref="T:Dibware.Salon.Domain.SharedKernel.Measures.Duration"/>
        /// from the specified primary <see cref="T:Dibware.Salon.Domain.SharedKernel.Measures.Duration"/>.
        /// </summary>
        /// <param name="primary">The primary <see cref="T:Dibware.Salon.Domain.SharedKernel.Measures.Duration"/>.</param>
        /// <param name="secondary">The secondary <see cref="T:Dibware.Salon.Domain.SharedKernel.Measures.Duration"/>.</param>
        /// <returns>Returns a newly constructed <see cref="T:Dibware.Salon.Domain.SharedKernel.Measures.Duration"/> with summed values.</returns>
        public Duration Subtract(Duration primary, Duration secondary)
        {
            return Duration.Zero;
        }
    }
}