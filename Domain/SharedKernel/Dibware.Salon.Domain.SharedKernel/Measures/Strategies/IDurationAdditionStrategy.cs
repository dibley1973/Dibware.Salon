//-----------------------------------------------------------------------
// <copyright file="IDurationAdditionStrategy.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Measures.Strategies
{
    /// <summary>
    /// Defines the expected members of an addition strategy for an addition strategy for a <see cref="Duration"/>
    /// </summary>
    public interface IDurationAdditionStrategy
    {
        /// <summary>Adds the value of the specified secondary <see cref="Duration"/>
        /// to the specified primary <see cref="Duration"/>.</summary>
        /// <param name="primary">The primary <see cref="Duration"/>.</param>
        /// <param name="secondary">The secondary <see cref="Duration"/>.</param>
        /// <returns>Returns a newly constructed <see cref="Duration"/> with summed values.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if the value of primary or secondary is null.
        /// </exception>
        Duration Add(Duration primary, Duration secondary);
    }
}