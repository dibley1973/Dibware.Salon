﻿//-----------------------------------------------------------------------
// <copyright file="MaybeTests.cs" company="Chesil Media">
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
            var expectedToStringText = $"An empty maybe of type { product.GetType().Name}";

            // ACT
            var actual = maybe.ToString();

            // ASSERT
            actual.Should().Be(
                expectedToStringText,
                "the wrapped ToString() text should match the wrapper's ToString() text");
        }

        /// <summary>
        /// Givens the to string method when maybe is populated then returns same as wrapped object.
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
    }
}