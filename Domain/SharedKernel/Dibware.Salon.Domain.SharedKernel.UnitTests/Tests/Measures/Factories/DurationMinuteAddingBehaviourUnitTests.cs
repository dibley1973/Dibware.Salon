//-----------------------------------------------------------------------
// <copyright file="DurationMinuteAddingBehaviourUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Measures.Factories;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Measures.Factories
{
    /// <summary>
    /// Contains tests for the <see cref="DurationMinuteAddingBehaviour"/> object
    /// </summary>
    public class DurationMinuteAddingBehaviourUnitTests
    {
        /// <summary>
        /// Given the can add minutes when accessed then returns true.
        /// </summary>
        [Test]
        public void GivenCanAddMinutes_WhenAccessed_ThenReturnsTrue()
        {
            // ASSERT
            DurationMinuteAddingBehaviour.CanAddMinutes.Should().BeTrue("because the value for adding minutes should be true");
        }

        /// <summary>
        /// Given the cannot add minutes when accessed then returns false.
        /// </summary>
        [Test]
        public void GivenCannotAddMinutes_WhenAccessed_ThenReturnsFalse()
        {
            // ASSERT
            DurationMinuteAddingBehaviour.CannotAddMinutes.Should().BeFalse("because the value for not adding minutes should be false");
        }
    }
}