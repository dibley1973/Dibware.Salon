//-----------------------------------------------------------------------
// <copyright file="ShortDescriptionErrorKeys.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys
{
    /// <summary>
    /// Represents the keys strings for <see cref="CommonValueObjects.ShortDescription"/> errors, which can be converted
    /// by the UI to meaningful messages;
    /// </summary>
    public static class ShortDescriptionErrorKeys
    {
        /// <summary>
        /// The key for when the value is null, empty or, white space
        /// </summary>
        public const string IsNullEmptyOrWhiteSpace = "CodeIsNullEmptyOrwhiteSpace";

        /// <summary>
        /// The key for when the value is too long
        /// </summary>
        public const string IsTooLong = "IsTooLong";
    }
}