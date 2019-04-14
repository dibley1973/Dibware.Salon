//-----------------------------------------------------------------------
// <copyright file="SuccessfulResultTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using Dibware.Salon.Domain.SharedKernel.UnitTests.TestData;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable UnusedVariable
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    /// <summary>
    /// Tests the <see cref="Result"/>class Ok results.
    /// </summary>
    internal class SuccessfulResultTests
    {
        /// <summary>
        /// Given a non generic result when ok then failure should be false.
        /// </summary>
        [Test]
        public void GivenANonGenericResult_WhenOk_ThenFailureShouldBeFalse()
        {
            // ARRANGE
            Result result = Result.Ok();

            // ASSERT
            result.IsFailure.Should().Be(false);
        }

        /// <summary>
        /// Given a non generic result when ok then success should be true.
        /// </summary>
        [Test]
        public void GivenANonGenericResult_WhenOk_ThenSuccessShouldBeTrue()
        {
            // ARRANGE
            Result result = Result.Ok();

            // ASSERT
            result.IsSuccess.Should().Be(true);
        }

        /// <summary>
        /// Given a generic result when ok then failure should be false.
        /// </summary>
        [Test]
        public void GivenAGenericResult_WhenOk_ThenFailureShouldBeFalse()
        {
            // ARRANGE
            var emptyProduct = FakeEntityData.CreateEmptyProduct();

            // ACT
            Result<FakeEntity> result = Result.Ok(emptyProduct);

            // ASSERT
            result.IsFailure.Should().Be(false);
        }

        /// <summary>
        /// Given a generic result when ok then success should be true.
        /// </summary>
        [Test]
        public void GivenAGenericResult_WhenOk_ThenSuccessShouldBeTrue()
        {
            // ARRANGE
            var emptyProduct = FakeEntityData.CreateEmptyProduct();

            // ACT
            Result<FakeEntity> result = Result.Ok(emptyProduct);

            // ASSERT
            result.IsSuccess.Should().Be(true);
        }

        /// <summary>
        /// Given a generic result when ok then value should be supplied value.
        /// </summary>
        [Test]
        public void GivenAGenericResult_WhenOk_ThenValueShouldBeSuppliedValue()
        {
            // ARRANGE
            var emptyProduct = FakeEntityData.CreateEmptyProduct();

            // ACT
            Result<FakeEntity> result = Result.Ok(emptyProduct);

            // ASSERT
            result.Value.Should().Be(emptyProduct);
        }

        /// <summary>
        /// Given a generic result when ok with null then exception is thrown.
        /// </summary>
        [Test]
        public void GivenAGenericResult_WhenOkWithNull_ThenExceptionIsThrown()
        {
            // ARRANGE
            Action action = () => { Result.Ok((FakeEntity)null); };

            // ASSERT
            action.Should().Throw<ArgumentNullException>();
        }

        /// <summary>
        /// Given a non generic result when accessing error then an exception is thrown.
        /// </summary>
        [Test]
        public void GivenANonGenericResult_WhenAccessingError_ThenAnExceptionIsThrown()
        {
            // ARRANGE
            Result result = Result.Ok();

            // ACT
            Action action = () =>
            {
                var error = result.Error;
            };

            // ASSERT
            action.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Given a generic result when accessing error then an exception is thrown.
        /// </summary>
        [Test]
        public void GivenAGenericResult_WhenAccessingError_ThenAnExceptionIsThrown()
        {
            // ARRANGE
            Result<FakeEntity> result = Result.Ok(FakeEntityData.CreateEmptyProduct());

            // ACT
            Action action = () =>
            {
                var error = result.Error;
            };

            // ASSERT
            action.Should().Throw<InvalidOperationException>();
        }
    }
}