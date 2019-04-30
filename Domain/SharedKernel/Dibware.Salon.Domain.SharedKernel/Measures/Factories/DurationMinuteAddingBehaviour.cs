//-----------------------------------------------------------------------
// <copyright file="DurationMinuteAddingBehaviour.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Measures.Factories
{
    /// <summary>
    /// Defines values which can be used to express behaviour about whether
    /// minutes can be added to a duration object.
    /// </summary>
    public static class DurationMinuteAddingBehaviour
    {
        /// <summary>
        /// Expresses that minutes can be added
        /// </summary>
        public const bool CanAddMinutes = true;

        /// <summary>
        /// expresses that minutes cannot be added
        /// </summary>
        public const bool CannotAddMinutes = false;
    }
}