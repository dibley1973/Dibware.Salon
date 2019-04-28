//-----------------------------------------------------------------------
// <copyright file="Minutes.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Primitives;

namespace Dibware.Salon.Domain.SharedKernel.Measures
{
    /// <summary>
    /// Represents a measure of minutes
    /// </summary>
    public class Minutes : PositiveInteger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Minutes"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Minutes(int value)
            : base(value)
        {
        }
    }
}