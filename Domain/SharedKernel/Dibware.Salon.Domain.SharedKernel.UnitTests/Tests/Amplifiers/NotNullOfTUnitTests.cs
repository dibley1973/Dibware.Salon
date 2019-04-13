using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers
{
    /// <summary>
    /// Provides unit tests for the <see cref="NotNull{T}"/> class.
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

        /// <summary>
        /// Given the equals for object when passed null then returns false.
        /// </summary>
        [Test]
        public void GivenEqualsForObject_WhenPassedNull_ThenReturnsFalse()
        {
            // ARRANGE
            const object nullObject = null;
            var fakeEntity = new FakeEntity();
            var notNullFakeEntity = new NotNull<FakeEntity>(fakeEntity);

            // ACT
            var actual = notNullFakeEntity.Equals(nullObject);

            // ASSERT
            actual.Should().BeFalse("because the specified object is a null reference");
        }

        /// <summary>
        /// Given the equals for object when passed same instance then returns true.
        /// </summary>
        [Test]
        public void GivenEqualsForObject_WhenPassedValidInstance_ThenReturnsTrue()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var notNullFakeEntity = new NotNull<FakeEntity>(fakeEntity1);

            // ACT
            var actual = notNullFakeEntity.Equals(notNullFakeEntity);

            // ASSERT
            actual.Should().BeTrue("because the specified object has an instance reference");
        }

        /// <summary>
        /// Given the equals when supplied with same reference then returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedWithSameReference_ThenReturnsTrue()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntity2 = fakeEntity1;
            var notNullFakeEntity1 = new NotNull<FakeEntity>(fakeEntity1);
            var notNullFakeEntity2 = new NotNull<FakeEntity>(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1.Equals(notNullFakeEntity2);

            // ASSERT
            actual.Should().BeTrue("because both entities are the same reference");
        }

        /// <summary>
        /// Given the equals when supplied with different reference then returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedWithDifferentReference_ThenReturnsFalse()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntity2 = new FakeEntity();
            var notNullFakeEntity1 = new NotNull<FakeEntity>(fakeEntity1);
            var notNullFakeEntity2 = new NotNull<FakeEntity>(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1.Equals(notNullFakeEntity2);

            // ASSERT
            actual.Should().BeFalse("because both entities are the same reference");
        }

        /// <summary>
        /// Given the equals when supplied with different reference then returns result of wrapped objects equals.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSuppliedWithDifferentReference_ThenReturnsResultOfWrappedObjectsEquals()
        {
            // ARRANGE
            var fakeValueObject1 = new FakeValueObject("1", "11");
            var fakeValueObject2 = new FakeValueObject("2", "22");
            var fakeValueObject1B = new FakeValueObject("1", "11");
            var notNullFakeEntity1 = new NotNull<FakeValueObject>(fakeValueObject1);
            var notNullFakeEntity2 = new NotNull<FakeValueObject>(fakeValueObject2);
            var notNullFakeEntity1B = new NotNull<FakeValueObject>(fakeValueObject1B);

            // ACT
            var actual1 = notNullFakeEntity1.Equals(notNullFakeEntity2);
            var actual2 = notNullFakeEntity1.Equals(notNullFakeEntity1B);

            // ASSERT
            actual1.Should().BeFalse("because both entities have different values");
            actual2.Should().BeTrue("because both entities have the same values");
        }

        /// <summary>
        /// Given the get hash code when accessed then returns the same as wrapped class.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenAccessed_ThenReturnsTheSameAsWrappedClass()
        {
            // ARRANGE
            var fakeValueObject = new FakeValueObject("1", "11");
            var notNullFakeEntity = new NotNull<FakeValueObject>(fakeValueObject);
            var expectedHashCode = fakeValueObject.GetHashCode();

            // ACT
            var actual = notNullFakeEntity.GetHashCode();

            // ASSERT
            actual.Should().Be(expectedHashCode,
                "because the hash code and the wrapped object's hashcode should match");
        }

        /// <summary>
        /// Given the is equal to when supplied with same reference then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithSameReference_ThenReturnsTrue()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntity2 = fakeEntity1;
            var notNullFakeEntity1 = new NotNull<FakeEntity>(fakeEntity1);
            var notNullFakeEntity2 = new NotNull<FakeEntity>(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1 == notNullFakeEntity2;

            // ASSERT
            actual.Should().BeTrue("because both entities are the same reference");
        }

        /// <summary>
        /// Given the is equal to when supplied with different reference then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithDifferentReference_ThenReturnsFalse()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntity2 = new FakeEntity();
            var notNullFakeEntity1 = new NotNull<FakeEntity>(fakeEntity1);
            var notNullFakeEntity2 = new NotNull<FakeEntity>(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1 == notNullFakeEntity2;

            // ASSERT
            actual.Should().BeFalse("because both entities are the same reference");
        }


        /// <summary>
        /// Given the is not equal to when supplied with same reference then returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenSuppliedWithSameReference_ThenReturnsFalse()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntity2 = fakeEntity1;
            var notNullFakeEntity1 = new NotNull<FakeEntity>(fakeEntity1);
            var notNullFakeEntity2 = new NotNull<FakeEntity>(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1 != notNullFakeEntity2;

            // ASSERT
            actual.Should().BeFalse("because both entities are the same reference");
        }

        /// <summary>
        /// Given the is not equal to when supplied with different reference then returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenSuppliedWithDifferentReference_ThenReturnsTrue()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntity2 = new FakeEntity();
            var notNullFakeEntity1 = new NotNull<FakeEntity>(fakeEntity1);
            var notNullFakeEntity2 = new NotNull<FakeEntity>(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1 != notNullFakeEntity2;

            // ASSERT
            actual.Should().BeTrue("because both entities are the same reference");
        }

        /// <summary>
        /// Given to string when accessed then returns same as wrapped object.
        /// </summary>
        [Test]
        public void GivenToString_WhenAccessed_ThenReturnsSameAsWrappedObject()
        {
            // ARRANGE
            var fakeEntity = new FakeEntity();
            var notNullFakeEntity = new NotNull<FakeEntity>(fakeEntity);
            var expectedToStringText = fakeEntity.ToString();

            // ACT
            var actual = notNullFakeEntity.ToString();

            // ASSERT
            actual.Should().Be(
                expectedToStringText,
                "the wrapped ToString() text should match the warpper's ToString() text");
        }

        /// <summary>
        /// Given the widening casting operator when provided with null then throws exception.
        /// </summary>
        [Test]
        public void GivenWideningCastingOperator_WhenProvidedWithNull_ThenThrowsException()
        {
            // ARRANGE
            const FakeEntity nullEntity = null;
            
            // ACT
            Action actual = () =>
            {
                // ReSharper disable once UnusedVariable
                var actualEntity = (NotNull<FakeEntity>) nullEntity;
            };

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a conversion from null is not permitted");
        }

        /// <summary>
        /// Given the widening casting operator when provided with instance then returns not null wrapped object.
        /// </summary>
        [Test]
        public void GivenWideningCastingOperator_WhenProvidedWithInstance_ThenReturnsNotNullWrappedObject()
        {
            // ARRANGE
            var fakeEntity = new FakeEntity();

            // ACT
            var actual = (NotNull<FakeEntity>)fakeEntity;
            
            // ASSERT
            actual.Value.Should().Be(fakeEntity,
                "because the value of wrapper should be the object which was cast from");
        }


        /// <summary>A dummy method for testing.</summary>
        /// <param name="notNullObject">The not null object.</param>
        // ReSharper disable once UnusedParameter.Local
        private static void DummyMethodForTesting(NotNull<FakeEntity> notNullObject)
        {
            // Do nothing here
        }
    }
}