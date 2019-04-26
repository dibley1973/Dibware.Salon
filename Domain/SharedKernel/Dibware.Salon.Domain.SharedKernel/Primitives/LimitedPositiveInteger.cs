//-----------------------------------------------------------------------
// <copyright file="LimitedPositiveInteger.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace Dibware.Salon.Domain.SharedKernel.Primitives
{
    /// <summary>
    /// Represents a zero or positive integer with upper limit
    /// </summary>
    public abstract class LimitedPositiveInteger : PositiveInteger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimitedPositiveInteger"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        protected LimitedPositiveInteger(int value)
            : base(value)
        {
        }

        /// <summary>Gets the upper boundary for the limit.</summary>
        /// <value>The upper boundary.</value>
        protected abstract int UpperBoundary { get; }

        /// <summary>Gets a value indicating whether the value exceeds the upper boundary.</summary>
        /// <value>
        ///   <c>true</c> if the value exceeds upper the boundary; otherwise, <c>false</c>.</value>
        protected bool ValueExceedsUpperBoundary => Value > UpperBoundary;
    }
}