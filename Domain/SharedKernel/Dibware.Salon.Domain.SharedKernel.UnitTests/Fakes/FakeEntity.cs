//-----------------------------------------------------------------------
// <copyright file="FakeEntity.cs" company="Chesil Media">
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
    /// Represents a fake entity for testing purposes only
    /// </summary>
    internal sealed class FakeEntity : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeEntity"/> class.
        /// </summary>
        public FakeEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeEntity"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public FakeEntity(long id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}