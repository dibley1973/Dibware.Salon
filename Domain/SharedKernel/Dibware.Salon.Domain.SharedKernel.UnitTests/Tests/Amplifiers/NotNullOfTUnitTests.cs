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

    }
}