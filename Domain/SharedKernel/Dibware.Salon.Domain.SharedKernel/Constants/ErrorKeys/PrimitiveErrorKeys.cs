//-----------------------------------------------------------------------
// <copyright file="PrimitiveErrorKeys.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys
{
    /// <summary>
    /// Represents the keys strings for Primitives errors, which can be converted by the UI
    /// to meaningful messages;
    /// </summary>
    public static class PrimitiveErrorKeys
    {
        /// <summary>
        /// The key for when the calculated value is negative
        /// </summary>
        public const string CalculatedValueIsNegative = "CalculatedValueIsNegative";

        /// <summary>
        /// The key for when the calculated value is greater than <see cref="int.MaxValue"/>
        /// </summary>
        public const string CalculatedValueIsGreaterThanIntMax = "CalculatedValueIsGreaterThanIntMax";
    }
}
