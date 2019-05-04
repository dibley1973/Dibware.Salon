// <copyright file="ReferenceHelper.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

namespace Dibware.Salon.Domain.SharedKernel.Helpers
{
    /// <summary>Helps with referenced based checks and operations</summary>
    internal static class ReferenceHelper
    {
        /// <summary>Gets a value indicating if both of the <see cref="object"/> are null.</summary>
        /// <param name="primary">The primary object.</param>
        /// <param name="secondary">The secondary object.</param>
        /// <returns>Returns <c>true</c> if both objects are null; otherwise <c>false</c>.</returns>
        public static bool BothReferencesAreNull(object primary, object secondary)
        {
            return primary is null && secondary is null;
        }

        /// <summary>Returns primary value indicating if either the primary or secondary <see cref="object"/> is null.</summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>Returns <c>true</c> if the primary of the secondary is null; otherwise <c>false</c>.</returns>
        public static bool OneOrTheOtherReferenceIsNull(object primary, object secondary)
        {
            return primary is null || secondary is null;
        }
    }
}