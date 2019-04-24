//-----------------------------------------------------------------------
// <copyright file="Minutes.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Primitives;

namespace Dibware.Salon.Domain.SharedKernel.Measures
{
    /// <summary>
    /// Represents a measure of minutes with a maximum limit of 60
    /// </summary>
    public sealed class Minutes : LimitedPositiveInteger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Minutes"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Minutes(int value)
            : base(value)
        {
            if (ValueExceedsUpperBoundary)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Value os {value} exceeds {UpperBoundary}");
            }
        }

        /// <summary>
        /// Gets the maximum number of minutes upper boundary for the limit.
        /// </summary>
        /// <value>The upper boundary.</value>
        protected override int UpperBoundary => 59;
    }
}