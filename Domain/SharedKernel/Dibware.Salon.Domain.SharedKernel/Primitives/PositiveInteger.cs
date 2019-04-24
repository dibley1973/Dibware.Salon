//-----------------------------------------------------------------------
// <copyright file="PositiveInteger.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Guards;

namespace Dibware.Salon.Domain.SharedKernel.Primitives
{
    /// <summary>
    /// Represents a zero or positive integer
    /// </summary>
    public class PositiveInteger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveInteger"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the specified value is negative
        /// </exception>
        public PositiveInteger(int value)
        {
            Ensure.IsNotNegative(value, (ArgumentName)nameof(value));

            Value = value;
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        private int Value { get; }
    }
}