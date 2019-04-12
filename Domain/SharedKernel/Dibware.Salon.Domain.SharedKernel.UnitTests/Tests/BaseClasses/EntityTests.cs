﻿
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using Dibware.Salon.Domain.SharedKernel.UnitTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.BaseClasses
{
    /// <summary>
    /// Provides unit tests for the <see cref="Entity"/> class.
    /// </summary>
    [TestFixture]
    public class EntityTests
    {
        /// <summary>
        /// Tests Equals when other is same type but null returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsObjectButNull_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();
            var other = (object)null;

            // ACT
            // ReSharper disable once ExpressionIsAlwaysNull
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Tests Equals when other is same type but null returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsSameTypeButNull_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();
            var other = FakeEntityData.CreateNullProduct();

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Tests Equals when other is different type returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsDifferentType_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();
            object other = new string('W', 5);

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when other is same reference returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsSameReference_ReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();
            object other = product;

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test Equals when other is same type but default identifier returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsSameTypeButDefaultId_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            var other = FakeEntityData.CreateEmptyProduct();

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when other is same type but different ids returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsSameTypeButDifferentIds_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();
            var other = FakeEntityData.CreateProductNo3();

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when other is same type with same IDs returns tru.
        /// </summary>
        [Test]
        public void GivenEquals_WhenOtherIsSameTypeWithSameIds_ReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();
            var other = FakeEntityData.CreateProductNo2();

            // ACT
            var actual = product.Equals(other);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Tests the Identifier after construction with no identifier returns default value of identifier.
        /// </summary>
        [Test]
        public void GivenId_AfterConstructionWithNoId_ReturnsDefaultValueOfId()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();

            // ACT
            var actual = product.Id;

            // ASSERT
            actual.Should().Be(default(int));
        }

        /// <summary>
        /// Tests the Identifier after construction with identifier returns value of identifier.
        /// </summary>
        [Test]
        public void GivenId_AfterConstructionWithId_ReturnsValueOfId()
        {
            // ARRANGE
            var id = 187;
            var product = FakeEntityData.CreateProduct(id);

            // ACT
            var actual = product.Id;

            // ASSERT
            actual.Should().Be(id);
        }

        /// <summary>
        /// Test Equals when both instances are null returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenBothInstancesAreNull_ReturnsTrue()
        {
            // ARRANGE
            FakeEntity entity = FakeEntityData.CreateNullProduct();
            FakeEntity other = FakeEntityData.CreateNullProduct();

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = entity == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test Equals when one instance is instantiated and the other is null returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenOneInstanceIsInstantiatedAndTheOtherIsNull_ReturnsFalse()
        {
            // ARRANGE
            FakeEntity entity = FakeEntityData.CreateProductNo2();
            FakeEntity other = FakeEntityData.CreateNullProduct();

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = entity == other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when both instance are instantiated with different ids returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenBothInstanceAreInstantiatedWithDifferentIds_ReturnsFalse()
        {
            // ARRANGE
            FakeEntity entity = new FakeEntity(7);
            FakeEntity other = new FakeEntity(77);

            // ACT
            var actual = entity == other;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test Equals when both instance are instantiated with same ids returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenBothInstanceAreInstantiatedWithSameIds_ReturnsTrue()
        {
            // ARRANGE
            FakeEntity entity = new FakeEntity(7);
            FakeEntity other = new FakeEntity(7);

            // ACT
            var actual = entity == other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test not equal to when both instances are null returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenBothInstancesAreNull_ReturnsFalse()
        {
            // ARRANGE
            FakeEntity entity = null;
            FakeEntity other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = entity != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Test not equal to when one instance is instantiated and the other is null returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenOneInstanceIsInstantiatedAndTheOtherIsNull_ReturnsTrue()
        {
            // ARRANGE
            FakeEntity entity = new FakeEntity(7);
            FakeEntity other = null;

            // ACT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var actual = entity != other;

            // ASSERT
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test not equal to when both instance are instantiated with different ids returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenBothInstanceAreInstantiatedWithDifferentIds_ReturnsTrue()
        {
            // ARRANGE
            FakeEntity entity = FakeEntityData.CreateProductNo2();
            FakeEntity other = FakeEntityData.CreateProductNo3();

            // ACT
            var actual = entity != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Test not equal to when both instance are instantiated with same ids return false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenBothInstanceAreInstantiatedWithSameIds_ReturnTrue()
        {
            // ARRANGE
            FakeEntity entity = FakeEntityData.CreateProductNo2();
            FakeEntity other = FakeEntityData.CreateProductNo3();

            // ACT
            var actual = entity != other;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Determines whether is persistent after construction with no identifier returns false.
        /// </summary>
        [Test]
        public void GivenIsPersistent_AfterConstructionWithNoId_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();

            // ACT
            var actual = product.IsPersistent;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Determines whether is persistent after construction with identifier returns true.
        /// </summary>
        [Test]
        public void GivenIsPersistent_AfterConstructionWithId_ReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();

            // ACT
            var actual = product.IsPersistent;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Determines whether is transient after construction with no identifier returns true.
        /// </summary>
        [Test]
        public void GivenIsTransient_AfterConstructionWithNoId_ReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();

            // ACT
            var actual = product.IsTransient;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Determines whether is transient after construction with identifier returns false.
        /// </summary>
        [Test]
        public void GivenIsTransient_AfterConstructionWithId_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateProductNo2();

            // ACT
            var actual = product.IsTransient;

            // ASSERT
            actual.Should().BeFalse();
        }
    }
}