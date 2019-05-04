//-----------------------------------------------------------------------
// <copyright file="IDurationSubtractionStrategy.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Measures.Strategies
{
    /// <summary>
    /// Defines the expected members of a subtraction strategy for a <see cref="Duration"/>
    /// </summary>
    public interface IDurationSubtractionStrategy
    {
        /// <summary>
        /// Gets a value indicating whether this instance can subtract.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can subtract; otherwise, <c>false</c>.
        /// </value>
        bool CanSubtract { get; }

        /// <summary>Subtracts the value of the specified secondary <see cref="Duration"/>
        /// from the specified primary <see cref="Duration"/>.</summary>
        /// <param name="primary">The primary <see cref="Duration"/>.</param>
        /// <param name="secondary">The secondary <see cref="Duration"/>.</param>
        /// <returns>Returns a newly constructed <see cref="Duration"/> with summed values.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the value of primary or secondary is null.
        /// </exception>
        Duration Subtract(Duration primary, Duration secondary);
    }
}
