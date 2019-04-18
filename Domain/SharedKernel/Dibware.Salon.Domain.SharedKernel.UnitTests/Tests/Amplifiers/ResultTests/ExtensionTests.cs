//-----------------------------------------------------------------------
// <copyright file="ExtensionTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    /// <summary>
    /// Tests the <see cref="Result"/> extensions.
    /// </summary>
    public class ExtensionTests
    {
        private static readonly string _errorMessage = "this failed";

        /// <summary>
        /// Given the on failure when non-generic result is fail then should execute action.
        /// </summary>
        [Test]
        public void GivenOnFailure_WhenNonGenericResultIsFail_ThenShouldExecuteAction()
        {
            // ARRANGE
            bool actual = false;
            var result = Result.Fail(_errorMessage);

            // ACT
            result.OnFailure(() => actual = true);

            // ASSERT
            actual.Should().Be(true);
        }

        /// <summary>
        /// Given the on failure when generic result is fail then should execute action.
        /// </summary>
        [Test]
        public void GivenOnFailure_WhenGenericResultIsFail_ThenShouldExecuteAction()
        {
            // ARRANGE
            var actual = false;
            var result = Result.Fail<FakeEntity>(_errorMessage);

            // ACT
            result.OnFailure(() => actual = true);

            // ASSERT
            actual.Should().Be(true);
        }

        /// <summary>
        /// Given the on failure when generic result is fail then should execute action withresult.
        /// </summary>
        [Test]
        public void GivenOnFailure_WhenGenericResultIsFail_ThenShouldExecuteActionWithresult()
        {
            // ARRANGE
            var actual = string.Empty;
            var result = Result.Fail<FakeEntity>(_errorMessage);

            // ACT
            result.OnFailure(error => actual = error);

            // ASSERT
            actual.Should().Be(_errorMessage);
        }
    }
}