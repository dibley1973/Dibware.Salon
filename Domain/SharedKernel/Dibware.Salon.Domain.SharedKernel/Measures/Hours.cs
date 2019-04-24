//-----------------------------------------------------------------------
// <copyright file="Hours.cs" company="Dibware">
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
    /// Represents a measure of hours with a maximum limit of 24
    /// </summary>
    public sealed class Hours : LimitedPositiveInteger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hours"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Hours(int value)
            : base(value)
        {
            if (ValueExceedsUpperBoundary)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Value os {value} exceeds {UpperBoundary}");
            }
        }

        /// <summary>
        /// Gets the maximum number of hours upper boundary for the limit.
        /// </summary>
        /// <value>The upper boundary.</value>
        protected override int UpperBoundary => 24;
    }
}