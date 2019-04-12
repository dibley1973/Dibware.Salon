using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using Dibware.Salon.Domain.SharedKernel.UnitTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers
{
    /// <summary>
    /// Provides unit tests for the <see cref="Entity{TId}"/> class.
    /// </summary>
    [TestFixture]
    public class NotNullOfTUnitTests
    {
        /// <summary>Given the constructor when passed null then throws exception.</summary>
        [Test]
        public void GivenConstructor_WhenPassedNull_ThenThrowsException()
        {
            // ARRANGE
            const FakeEntity nullEntity = null;
            
            // ACT
            Action actual = () => new NotNull<FakeEntity>(nullEntity);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null object is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed not null then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedNotNull_ThenDoesNotThrowException()
        {
            // ARRANGE
            var notNullEntity = new FakeEntity();

            // ACT
            Action actual = () => new NotNull<FakeEntity>(notNullEntity);

            // ASSERT
            actual.Should().NotThrow("because a not null object is permitted");
        }

        /// <summary>
        /// Given the used as method parameter when passed null then throws exception.
        /// </summary>
        [Test]
        public void GivenUsedAsMethodParameter_WhenPassedNull_ThenThrowsException()
        {
            // ARRANGE
            const FakeEntity nullEntity = null;

            // ACT
            Action actual = () => DummyMethodForTesting(nullEntity);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null object is not permitted");
        }

        /// <summary>
        /// Given the used as method parameter when passed not null then does not throw exception.
        /// </summary>
        [Test]
        public void GivenUsedAsMethodParameter_WhenPassedNotNull_ThenDoesNotThrowException()
        {
            // ARRANGE
            var notNullEntity = new FakeEntity();

            // ACT
            Action actual = () => DummyMethodForTesting(notNullEntity);

            // ASSERT
            actual.Should().NotThrow("because a not null object is permitted");
        }

        /// <summary>A dummy method for testing.</summary>
        /// <param name="notNullObject">The not null object.</param>
        private static void DummyMethodForTesting(NotNull<FakeEntity> notNullObject)
        {
            // Do nothing here
        }
    }
}