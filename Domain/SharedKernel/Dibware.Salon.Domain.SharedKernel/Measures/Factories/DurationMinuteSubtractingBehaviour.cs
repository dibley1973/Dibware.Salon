//-----------------------------------------------------------------------
// <copyright file="DurationMinuteSubtractingBehaviour.cs" company="Dibware">
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
    /// minutes can be subtracted to a duration object.
    /// </summary>
    public static class DurationMinuteSubtractingBehaviour
    {
        /// <summary>
        /// Expresses that minutes can be subtracted
        /// </summary>
        public const bool CanSubtractMinutes = true;

        /// <summary>
        /// expresses that minutes cannot be subtracted
        /// </summary>
        public const bool CannotSubtractMinutes = false;
    }
}