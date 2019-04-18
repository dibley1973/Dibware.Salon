// <copyright file="GuardExtensions.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;

namespace Dibware.Salon.Domain.SharedKernel.Guards
{
    /// <summary>
    /// Encapsulates guard clause extensions
    /// </summary>
    public static class GuardExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if instance is null.
        /// </summary>
        /// <param name="instance">The instance which should not be null.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the value of instance is null.
        /// </exception>
        public static void ThrowExceptionIfNull(this object instance, ArgumentName argumentName)
        {
            if (instance == null) throw new ArgumentNullException(argumentName);
        }
    }
}