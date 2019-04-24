//-----------------------------------------------------------------------
// <copyright file="MaybeTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using Dibware.Salon.Domain.SharedKernel.UnitTests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers
{
    /// <summary>
    /// Test for Maybe structure
    /// </summary>
    [TestFixture]
    public class MaybeTests
    {
        /// <summary>
        /// Given the equals for object when passed null then returns false.
        /// </summary>
        [Test]
        public void GivenEqualsForObject_WhenPassedNull_ThenReturnsFalse()
        {
            // ARRANGE
            const object nullObject = null;
            var fakeEntity = new FakeEntity();
            var fakeEntityOrNothing = Maybe<FakeEntity>.Wrap(fakeEntity);

            // ACT
            var actual = fakeEntityOrNothing.Equals(nullObject);

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
            var fakeEntityOrNothing1 = Maybe<FakeEntity>.Wrap(fakeEntity1);
            var fakeEntityOrNothing2 = (object)Maybe<FakeEntity>.Wrap(fakeEntity1);

            // ACT
            var actual = fakeEntityOrNothing1.Equals(fakeEntityOrNothing2);

            // ASSERT
            actual.Should().BeTrue("because the specified object has the same instance reference");
        }

        /// <summary>
        /// Given the equals for object when passed valid instance of same wrapped object then returns true.
        /// </summary>
        [Test]
        public void GivenEqualsForObject_WhenPassedValidInstanceOfSameWrappedObject_ThenReturnsTrue()
        {
            // ARRANGE
            var fakeEntity1 = new FakeEntity();
            var fakeEntityOrNothing1 = Maybe<FakeEntity>.Wrap(fakeEntity1);
            var fakeEntity2 = (object)fakeEntity1;

            // ACT
            var actual = fakeEntityOrNothing1.Equals(fakeEntity2);

            // ASSERT
            actual.Should().BeTrue("because the specified object has the same wrapped instance reference");
        }

        /// <summary>
        /// Given the equals for maybe when both maybes being empty then returns true.
        /// </summary>
        [Test]
        public void GivenEqualsForMaybe_WhenBothMaybesBeingEmpty_ThenReturnsTrue()
        {
            // ARRANGE
            var emptyMaybe1 = Maybe<FakeEntity>.Empty;
            var emptyMaybe2 = Maybe<FakeEntity>.Empty;

            // ACT
            var actual = emptyMaybe1.Equals(emptyMaybe2);

            // ASSERT
            actual.Should().BeTrue("because both maybes are empty");
        }

        /// <summary>
        /// Given the equals for maybe when one maybe is empty ans other is not then returns false.
        /// </summary>
        [Test]
        public void GivenEqualsForMaybe_WhenOneMaybeIsEmptyAnsOtherIsNot_ThenReturnsFalse()
        {
            // ARRANGE
            var emptyMaybe1 = Maybe<FakeEntity>.Empty;
            var fakeEntity1 = new FakeEntity();
            var fakeEntityOrNothing1 = Maybe<FakeEntity>.Wrap(fakeEntity1);

            // ACT
            var actual = emptyMaybe1.Equals(fakeEntityOrNothing1);

            // ASSERT
            actual.Should().BeFalse("because one maybe is empty and the other is not");
        }

        /// <summary>
        /// Given value for a default <see cref="Maybe{T}"/> throws exception.
        /// </summary>
        [Test]
        public void GivenValue_ForADefaultMaybe_ThrowsException()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeEntity>);

            // ACT
            FakeEntity ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Given the value after wrapping with null argument throws exception.
        /// </summary>
        [Test]
        public void GivenValue_AfterWrappingWithNullArgument_ThrowsException()
        {
            // ARRANGE
            var maybe = Maybe<FakeEntity>.Wrap(null);

            // ACT
            FakeEntity ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Given the value after wrapping with an instantiated object returns same object.
        /// </summary>
        [Test]
        public void GivenValue_AfterWrappingWithAnInstantiatedObject_ReturnsSameObject()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            var maybe = Maybe<FakeEntity>.Wrap(product);

            // ACT
            var actual = maybe.Value;

            // ASSERT
            actual.Should().Be(product);
        }

        /// <summary>
        /// Given the Value after assigning null to implicit operator returns true.
        /// </summary>
        [Test]
        public void GivenValue_AfterAssigningNullToImplicitOperator_ReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeEntity> maybe = null;

            // ACT
            FakeEntity ActualValueDelegate() => maybe.Value;

            // ASSERT
            Assert.That(ActualValueDelegate, Throws.InvalidOperationException);
        }

        /// <summary>
        /// Given the to string when maybe is empty then returns empty maybe text.
        /// </summary>
        [Test]
        public void GivenTheToStringMethod_WhenMaybeIsEmpty_ThenReturnsEmptyMaybeText()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            var maybe = Maybe<FakeEntity>.Empty;
            var expectedToStringText = $"An empty maybe of type {product.GetType().Name}";

            // ACT
            var actual = maybe.ToString();

            // ASSERT
            actual.Should().Be(
                expectedToStringText,
                "the wrapped ToString() text should match the wrapper's ToString() text");
        }

        /// <summary>
        /// Given the to string method when maybe is populated then returns same as wrapped object.
        /// </summary>
        [Test]
        public void GivenTheToStringMethod_WhenMaybeIsPopulated_ThenReturnsSameAsWrappedObject()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe = product;
            var expectedToStringText = $"A maybe of type {product.GetType().Name} with a value of: {product.ToString()}";

            // ACT
            var actual = maybe.ToString();

            // ASSERT
            actual.Should().Be(
                expectedToStringText,
                "the wrapped ToString() text should match the wrapper's ToString() text");
        }

        /// <summary>
        /// Given the Value after assigning instantiated object to implicit operator returns instantiated object.
        /// </summary>
        [Test]
        public void GivenValue_AfterAssigningInstantiatedObjectToImplicitOperator_ReturnsInstantiatedObject()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe = product;

            // ACT
            var actual = maybe.Value;

            // ASSERT
            actual.Should().BeSameAs(product);
        }

        /// <summary>
        /// Given the HasValue for a default maybe returns false.
        /// </summary>
        [Test]
        public void GivenHasValue_ForADefaultMaybe_ReturnsFalse()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeEntity>);

            // ACT
            var actual = maybe.HasValue;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the HasValue after wrapping with null argument throws exception.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterWrappingWithNullArgument_ReturnsFalse()
        {
            // ARRANGE
            var maybe = Maybe<FakeEntity>.Wrap(null);

            // ACT
            var actual = maybe.HasValue;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the has value after wrapping with an instantiated object returns true.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterWrappingWithAnInstantiatedObject_ReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            var maybe = Maybe<FakeEntity>.Wrap(product);

            // ACT
            var actual = maybe.HasValue;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasValue after assigning null to implicit operator returns false.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterAssigningNullToImplicitOperator_ReturnsFalse()
        {
            // ARRANGE
            Maybe<FakeEntity> maybe = null;

            // ACT

            // ASSERT
            maybe.HasValue.Should().BeFalse();
        }

        /// <summary>
        /// Given the HasValue after assigning instantiated object to implicit operator returns true.
        /// </summary>
        [Test]
        public void GivenHasValue_AfterAssigningInstantiatedObjectToImplicitOperator_ReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe = product;

            // ACT

            // ASSERT
            maybe.HasValue.Should().BeTrue();
        }

        /// <summary>Given the is equal to when both are different references then returns false.</summary>
        [Test]
        public void GivenIsEqualTo_WhenBothAreDifferentReferences_ThenReturnsFalse()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateEmptyProduct();
            var product2 = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe1 = product1;
            Maybe<FakeEntity> maybe2 = product2;

            // ACT
            var actual = maybe1 == maybe2;

            // ASSERT
            actual.Should().BeFalse("because they are different references");
        }

        /// <summary>Given the is equal to when both are same reference then returns true.</summary>
        [Test]
        public void GivenIsEqualTo_WhenBothAreSameReference_ThenReturnsTrue()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe1 = product;
            Maybe<FakeEntity> maybe2 = maybe1;

            // ACT
            var actual = maybe1 == maybe2;

            // ASSERT
            actual.Should().BeTrue("because they are the same references");
        }

        /// <summary>Given the is equal to when both are null reference then returns true.</summary>
        [Test]
        public void GivenIsEqualTo_WhenBothAreNullReference_ThenReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeEntity> maybe1 = default(Maybe<FakeEntity>);
            Maybe<FakeEntity> maybe2 = default(Maybe<FakeEntity>);

            // ACT
            var actual = maybe1 == maybe2;

            // ASSERT
            actual.Should().BeTrue("because they are the same references");
        }

        /// <summary>Given the is equal to when one has value and the other does not then returns false.</summary>
        [Test]
        public void GivenIsEqualTo_WhenOneHasValueAndTheOtherDoesNot_ThenReturnsFalse()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe1 = product1;
            Maybe<FakeEntity> maybe2 = Maybe<FakeEntity>.Empty;
            Maybe<FakeEntity> maybe3 = product1;

            // ACT
            var actual1 = maybe1 == maybe2;
            var actual2 = maybe2 == maybe3;

            // ASSERT
            actual1.Should().BeFalse("because they first has a value and the other does not");
            actual2.Should().BeFalse("because they second has a value and the other does not");
        }

        /// <summary>
        /// Given the is equal to when comparing maybe to wrapped type and both are same then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenComparingMaybeToWrappedTypeAndBothAreSame_ThenReturnsTrue()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe1 = product1;

            // ACT
            var actual1 = maybe1 == product1;

            // ASSERT
            actual1.Should().BeTrue("because they maybe contains the same as the product");
        }

        /// <summary>
        /// Given the is equal to when comparing maybe to wrapped type to a different type then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenComparingMaybeToWrappedTypeToADifferentType_ThenReturnsFalse()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateProductNo2();
            var product2 = FakeEntityData.CreateProductNo3();
            Maybe<FakeEntity> maybe1 = product1;

            // ACT
            var actual1 = maybe1 == product2;

            // ASSERT
            actual1.Should().BeFalse("because they are different products");
        }

        /// <summary>
        /// Given the is equal to when comparing empty maybe to wrapped type to a different type then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenComparingEmptyMaybeToWrappedTypeToADifferentType_ThenReturnsFalse()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateProductNo2();
            var maybe1 = Maybe<FakeEntity>.Empty;

            // ACT
            var actual1 = maybe1 == product1;

            // ASSERT
            actual1.Should().BeFalse("because they are different products");
        }

        /// <summary>
        /// Given the is not equal to when comparing maybe to wrapped type and both are same then returns true.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenComparingMaybeToWrappedTypeAndBothAreSame_ThenReturnsTrue()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe1 = product1;

            // ACT
            var actual1 = maybe1 != product1;

            // ASSERT
            actual1.Should().BeFalse("because they maybe contains the same as the product");
        }

        /// <summary>
        /// Given the is not equal to when comparing maybe to wrapped type to a different type then returns false.
        /// </summary>
        [Test]
        public void GivenIsNotEqualTo_WhenComparingMaybeToWrappedTypeToADifferentType_ThenReturnsFalse()
        {
            // ARRANGE
            var product1 = FakeEntityData.CreateProductNo2();
            var product2 = FakeEntityData.CreateProductNo3();
            Maybe<FakeEntity> maybe1 = product1;

            // ACT
            var actual1 = maybe1 != product2;

            // ASSERT
            actual1.Should().BeTrue("because they are different products");
        }

        /// <summary>
        /// Given the is equal to when supplied with both null reference then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithBothNullReferences_ThenReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeEntity> nullMaybeFakeEntity1 = null;
            Maybe<FakeEntity> nullMaybeFakeEntity2 = null;

            // ACT
            var actual = nullMaybeFakeEntity1 == nullMaybeFakeEntity2;

            // ASSERT
            actual.Should().BeTrue("because both entities are the same reference");
        }

        /// <summary>
        /// Given the is equal to when supplied with both wrap null references then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedWithBothWrapNullReferences_ThenReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeEntity> maybeWithNullFakeEntity1 = Maybe<FakeEntity>.Wrap(null);
            Maybe<FakeEntity> maybeWithNullFakeEntity2 = Maybe<FakeEntity>.Wrap(null);

            // ACT
            var actual = maybeWithNullFakeEntity1 == maybeWithNullFakeEntity2;

            // ASSERT
            actual.Should().BeTrue("because both entities wrap a null reference");
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
            var notNullFakeEntity1 = Maybe<FakeEntity>.Wrap(fakeEntity1);
            var notNullFakeEntity2 = Maybe<FakeEntity>.Wrap(fakeEntity2);

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
            var notNullFakeEntity1 = Maybe<FakeEntity>.Wrap(fakeEntity1);
            var notNullFakeEntity2 = Maybe<FakeEntity>.Wrap(fakeEntity2);

            // ACT
            var actual = notNullFakeEntity1 != notNullFakeEntity2;

            // ASSERT
            actual.Should().BeTrue("because both entities are the same reference");
        }

        /// <summary>
        /// Given the get hash code when accessed for populated Maybe then returns the same as wrapped class.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenAccessedForPopulatedMaybe_ThenReturnsTheSameAsWrappedClass()
        {
            // ARRANGE
            var fakeValueObject = new FakeValueObject("1", "11");
            var notNullFakeEntity = Maybe<FakeValueObject>.Wrap(fakeValueObject);
            var expectedHashCode = fakeValueObject.GetHashCode();

            // ACT
            var actual = notNullFakeEntity.GetHashCode();

            // ASSERT
            actual.Should().Be(
                expectedHashCode,
                "because the hash code and the wrapped object's hashcode should match");
        }

        /// <summary>
        /// Given the get hash code when accessed for empty then returns hash code for type names.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenAccessedForEmptyMaybe_ThenReturnsHashcodeForTypeNames()
        {
            // ARRANGE
            var notNullFakeEntity = Maybe<FakeValueObject>.Empty;
            var expectedHashCode = GetHashCodeBasedUponTypeNames<Maybe<FakeValueObject>, FakeValueObject>();

            // ACT
            var actual = notNullFakeEntity.GetHashCode();

            // ASSERT
            actual.Should().Be(
                expectedHashCode,
                "because the hash code and the wrapped object's hashcode should match");
        }

        /// <summary>
        /// Given the HasNoValue for a default maybe returns true.
        /// </summary>
        [Test]
        public void GivenNoHasValue_ForADefaultMaybe_ReturnsTrue()
        {
            // ARRANGE
            var maybe = default(Maybe<FakeEntity>);

            // ACT
            var actual = maybe.HasNoValue;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue after wrapping with null argument returns true.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterWrappingWithNullArgument_ReturnsTrue()
        {
            // ARRANGE
            var maybe = Maybe<FakeEntity>.Wrap(null);

            // ACT
            var actual = maybe.HasNoValue;

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue after wrapping with an instantiated object returns false.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterWrappingWithAnInstantiatedObject_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            var maybe = Maybe<FakeEntity>.Wrap(product);

            // ACT
            var actual = maybe.HasNoValue;

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the HasNoValue after assigning null to implicit operator returns true.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterAssigningNullToImplicitOperator_ReturnsTrue()
        {
            // ARRANGE
            Maybe<FakeEntity> maybe = null;

            // ACT

            // ASSERT
            maybe.HasNoValue.Should().BeTrue();
        }

        /// <summary>
        /// Given the HasNoValue after assigning instantiated object to implicit operator returns false.
        /// </summary>
        [Test]
        public void GivenHasNoValue_AfterAssigningInstantiatedObjectToImplicitOperator_ReturnsFalse()
        {
            // ARRANGE
            var product = FakeEntityData.CreateEmptyProduct();
            Maybe<FakeEntity> maybe = product;

            // ACT

            // ASSERT
            maybe.HasNoValue.Should().BeFalse();
        }

        /// <summary>Gets the hash code based upon type names.</summary>
        /// <typeparam name="TWrapper">The type of the class which wraps the object</typeparam>
        /// <typeparam name="TWrapped">The type of the class which is wrapped</typeparam>
        /// <returns>Returns in <c>int</c> representation</returns>
        private int GetHashCodeBasedUponTypeNames<TWrapper, TWrapped>()
        {
            int initialPrimeNumber = 61;
            int multiplierPrimeNumber = 79;

            // Overflow is fine, just wrap
            unchecked
            {
                int hash = initialPrimeNumber;

                hash = (hash * multiplierPrimeNumber) + typeof(TWrapper).Name.GetHashCode();
                hash = (hash * multiplierPrimeNumber) + typeof(TWrapped).Name.GetHashCode();

                return hash;
            }
        }
    }
}