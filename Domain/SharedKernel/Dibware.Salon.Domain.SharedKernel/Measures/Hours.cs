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

        /// <summary>Gets the number of minutes in an hour.</summary>
        /// <value>The minutes in hour.</value>
        public static PositiveInteger NumberOfMinutesInAnHour => new PositiveInteger(60);

        /// <summary>
        /// Gets the maximum number of hours upper boundary for the limit.
        /// </summary>
        /// <value>The upper boundary.</value>
        public override int UpperBoundary => 24;

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }

        /// <summary>
        /// Totals the number of minutes.
        /// </summary>
        /// <returns>The total number of minutes as a <see cref="Minutes"/></returns>
        public Minutes TotalNumberOfMinutes()
        {
            return new Minutes(Value * NumberOfMinutesInAnHour.Value);
        }
    }
}