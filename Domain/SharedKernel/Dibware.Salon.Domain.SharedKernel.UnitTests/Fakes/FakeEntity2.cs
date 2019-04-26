//-----------------------------------------------------------------------
// <copyright file="FakeEntity2.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.BaseClasses;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes
{
    /// <summary>
    /// Represents a fake entity #2 for testing purposes only
    /// </summary>
    internal sealed class FakeEntity2 : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeEntity2"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public FakeEntity2(long id)
        {
            Id = id;
        }
    }
}