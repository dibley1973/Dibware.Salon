// <copyright file="PositiveIntegerUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;
using Dibware.Salon.Domain.SharedKernel.Primitives;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Primitives
{
    /// <summary>
    /// Provides unit tests for the <see cref="PositiveInteger"/> class.
    /// </summary>
    [TestFixture]
    public class PositiveIntegerUnitTests
    {
        /// <summary>Given the constructor when passed negative value throws exception.</summary>
        [Test]
        public void GivenConstructor_WhenPassedNegativeValue_ThenThrowsException()
        {
            // ARRANGE
            const int negativeNumber = -1;

            // ACT
            Action actual = () => new PositiveInteger(negativeNumber);

            // ASSERT
            actual.Should().Throw<ArgumentOutOfRangeException>("because a null object is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed a non negative value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedANonNegativeValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const int argumentValue1 = 0;
            const int argumentValue2 = 1;

            // ACT
            Action actual1 = () => new PositiveInteger(argumentValue1);
            Action actual2 = () => new PositiveInteger(argumentValue2);

            // ASSERT
            actual2.Should().NotThrow<ArgumentNullException>("because no exception should be thrown for a valid value");
            actual1.Should().NotThrow<ArgumentNullException>("because no exception should be thrown for a valid value");
        }

        /// <summary>
        /// Given the addition operator when supplied with first argument null then throws exception.
        /// </summary>
        [Test]
        public void GivenAdditionOperator_WhenSuppliedWithFirstArgumentNull_ThenThrowsException()
        {
            // ARRANGE
            const PositiveInteger nullPositiveInteger = null;
            var positiveInteger = new PositiveInteger(3);
            PositiveInteger result = null;

            // ACT
            Action actual = () =>
            {
                result = nullPositiveInteger + positiveInteger;
            };

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null first argument is not permitted");
            result.Should().BeNull("because it should never have been set");
        }

        /// <summary>
        /// Given the addition operator when supplied with second argument null then throws exception.
        /// </summary>
        [Test]
        public void GivenAdditionOperator_WhenSuppliedWithSecondArgumentNull_ThenThrowsException()
        {
            // ARRANGE
            const PositiveInteger nullPositiveInteger = null;
            var positiveInteger = new PositiveInteger(3);
            PositiveInteger result = null;

            // ACT
            Action actual = () =>
            {
                result = positiveInteger + nullPositiveInteger;
            };

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null second argument is not permitted");
            result.Should().BeNull("because it should never have been set");
        }

        /// <summary>
        /// Given the addition operator when supplied with two values exceeding maximum int value then throws exception.
        /// </summary>
        [Test]
        public void GivenAdditionOperator_WhenSuppliedWithTwoValuesExceedingMaximumIntValue_ThenThrowsException()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(int.MaxValue);
            var positiveInteger2 = new PositiveInteger(1);
            PositiveInteger result = null;

            // ACT
            Action actual = () =>
            {
                result = positiveInteger1 + positiveInteger2;
            };

            // ASSERT
            actual.Should()
                .Throw<ArgumentOutOfRangeException>("because two values summing more than maximum int value cannot be summed");
            result.Should().BeNull("because it should never have been set");
        }

        /// <summary>
        /// Given the addition operator when supplied with two values not exceeding maximum int value then returns new instance.
        /// </summary>
        [Test]
        public void GivenAdditionOperator_WhenSuppliedWithTwoValuesNotExceedingMaximumIntValue_ThenReturnsNewInstance()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(int.MaxValue - 1);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1 + positiveInteger2;

            // ASSERT
            actual.Value.Should().Be(int.MaxValue, "because the sum should be correct");
            actual.Should().NotBeSameAs(positiveInteger1, "because the reference must not be the same as the first");
            actual.Should().NotBeSameAs(positiveInteger2, "because the reference must not be the same as the second");
        }

        /// <summary>
        /// Given the add when supplied with null value then throws exception.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedWithNullValue_ThenThrowsException()
        {
            // ARRANGE
            var positiveInteger = new PositiveInteger(3);
            const PositiveInteger nullPositiveInteger = null;

            // ACT
            Action actual = () => positiveInteger.Add(nullPositiveInteger);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null value cannot be added");
        }

        /// <summary>
        /// Given the add when supplied with two values exceeding maximum int value then throws exception.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedWithTwoValuesExceedingMaximumIntValue_ThenThrowsException()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(int.MaxValue);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            Action actual = () => positiveInteger1.Add(positiveInteger2);

            // ASSERT
            actual.Should()
                .Throw<ArgumentOutOfRangeException>("because two values summing more than maximum int value cannot be summed");
        }

        /// <summary>
        /// Given the add when supplied with two values not exceeding maximum int value then returns new instance.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedWithTwoValuesNotExceedingMaximumIntValue_ThenReturnsNewInstance()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(int.MaxValue - 1);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1.Add(positiveInteger2);

            // ASSERT
            actual.Value.Should().Be(int.MaxValue, "because the sum should be correct");
            actual.Should().NotBeSameAs(positiveInteger1, "because the reference must not be the same as the first");
            actual.Should().NotBeSameAs(positiveInteger2, "because the reference must not be the same as the second");
        }

        /// <summary>
        /// Given can add when supplied with two values exceeding maximum int value then returns false.
        /// </summary>
        [Test]
        public void GivenCanAdd_WhenSuppliedWithTwoValuesExceedingMaximumIntValue_ThenReturnsFalse()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(int.MaxValue);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1.CanAdd(positiveInteger2);

            // ASSERT
            actual.Should().BeFalse("because two values summing more than maximum int value cannot be summed");
        }

        /// <summary>
        /// Given can add when supplied with two values not exceeding maximum int value then returns true.
        /// </summary>
        [Test]
        public void GivenCanAdd_WhenSuppliedWithTwoValuesNotExceedingMaximumIntValue_ThenReturnsTrue()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(int.MaxValue - 1);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1.CanAdd(positiveInteger2);

            // ASSERT
            actual.Should().BeTrue("because two values summing less than or equal to maximum int value can be summed");
        }

        /// <summary>
        /// Given can subtract when supplied with two values subtracting to below zero value then returns false.
        /// </summary>
        [Test]
        public void GivenCanSubtract_WhenSuppliedWithTwoValuesBelowMinimumIntValue_ThenReturnsFalse()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(0);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1.CanSubtract(positiveInteger2);

            // ASSERT
            actual.Should().BeFalse("because two values subtracting to below minimum int value cannot be subtracted");
        }

        /// <summary>
        /// Given can subtract when supplied with two values subtracting above or equal to zero value then returns true.
        /// </summary>
        [Test]
        public void GivenCanSubtract_WhenSuppliedWithTwoValuesNotBelowMaximumIntValue_ThenReturnsTrue()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(1);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1.CanSubtract(positiveInteger2);

            // ASSERT
            actual.Should().BeTrue("because two values subtracting above or equal to minimum value can be subtracted");
        }

        /// <summary>
        /// Given the maximum value when accessed then returns maximum int value.
        /// </summary>
        [Test]
        public void GivenMaximumValue_WhenAccessed_ThenReturnsMaximumIntValue()
        {
            // ASSERT
            PositiveInteger.MaximumValue.Should().Be(int.MaxValue);
        }

        /// <summary>
        /// Given the minimum value when accessed then returns zero.
        /// </summary>
        [Test]
        public void GivenMaximumValue_WhenAccessed_ThenReturnsZero()
        {
            // ASSERT
            PositiveInteger.MinimumValue.Should().Be(0);
        }

        /// <summary>
        /// Given the subtract when supplied with null value then throws exception.
        /// </summary>
        [Test]
        public void GivenSubtract_WhenSuppliedWithNullValue_ThenThrowsException()
        {
            // ARRANGE
            var positiveInteger = new PositiveInteger(3);
            const PositiveInteger nullPositiveInteger = null;

            // ACT
            Action actual = () => positiveInteger.Subtract(nullPositiveInteger);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null value cannot be subtracted");
        }

        /// <summary>
        /// Given the subtract when supplied with two values below minimum int value then throws exception.
        /// </summary>
        [Test]
        public void GivenSubtract_WhenSuppliedWithTwoValuesBelowMinimumIntValue_ThenThrowsException()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(0);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            Action actual = () => positiveInteger1.Subtract(positiveInteger2);

            // ASSERT
            actual.Should()
                .Throw<ArgumentOutOfRangeException>("because two values subtracting more than minimum int value cannot be summed");
        }

        /// <summary>
        /// Given the subtract when supplied with two values not below minimum int value then returns new instance.
        /// </summary>
        [Test]
        public void GivenSubtract_WhenSuppliedWithTwoValuesNotBelowMinimumIntValue_ThenReturnsNewInstance()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(1);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1.Subtract(positiveInteger2);

            // ASSERT
            actual.Value.Should().Be(0, "because the subtraction should be correct");
            actual.Should().NotBeSameAs(positiveInteger1, "because the reference must not be the same as the first");
            actual.Should().NotBeSameAs(positiveInteger2, "because the reference must not be the same as the second");
        }

        /// <summary>
        /// Given the subtraction operator when supplied with first argument null then throws exception.
        /// </summary>
        [Test]
        public void GivenSubtractionOperator_WhenSuppliedWithFirstArgumentNull_ThenThrowsException()
        {
            // ARRANGE
            const PositiveInteger nullPositiveInteger = null;
            var positiveInteger = new PositiveInteger(3);
            PositiveInteger result = null;

            // ACT
            Action actual = () =>
            {
                result = nullPositiveInteger - positiveInteger;
            };

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null first argument is not permitted");
            result.Should().BeNull("because it should never have been set");
        }

        /// <summary>
        /// Given the subtraction operator when supplied with second argument null then throws exception.
        /// </summary>
        [Test]
        public void GivenSubtractionOperator_WhenSuppliedWithSecondArgumentNull_ThenThrowsException()
        {
            // ARRANGE
            const PositiveInteger nullPositiveInteger = null;
            var positiveInteger = new PositiveInteger(3);
            PositiveInteger result = null;

            // ACT
            Action actual = () =>
            {
                result = positiveInteger - nullPositiveInteger;
            };

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null second argument is not permitted");
            result.Should().BeNull("because it should never have been set");
        }

        /// <summary>
        /// Given the subtraction operator when supplied with two values not below minimum int value then returns new instance.
        /// </summary>
        [Test]
        public void GivenSubtractionOperator_WhenSuppliedWithTwoValuesNotBelowMinimumIntValue_ThenReturnsNewInstance()
        {
            // ARRANGE
            var positiveInteger1 = new PositiveInteger(1);
            var positiveInteger2 = new PositiveInteger(1);

            // ACT
            var actual = positiveInteger1 - positiveInteger2;

            // ASSERT
            actual.Value.Should().Be(0, "because the subtraction operation should be correct");
            actual.Should().NotBeSameAs(positiveInteger1, "because the reference must not be the same as the first");
            actual.Should().NotBeSameAs(positiveInteger2, "because the reference must not be the same as the second");
        }

        /// <summary>
        /// Given the implicit conversion to int when supplied with null then returns zero.
        /// </summary>
        [Test]
        public void GivenImplicitConversionToInt_WhenSuppliedWithNull_ThenReturnsZero()
        {
            // ARRANGE
            const PositiveInteger nullPositiveInteger = null;

            // ACT
            int actual = nullPositiveInteger;

            // ASSERT
            actual.Should().Be(0, "because a null PositiveInteger casts to a null int");
        }

        /// <summary>
        /// Given the implicit conversion to int when supplied with valid positive integer then returns positive integer value.
        /// </summary>
        [Test]
        public void GivenImplicitConversionToInt_WhenSuppliedWithValidPositiveInteger_ThenReturnsPositiveIntegerValue()
        {
            // ARRANGE
            var expected = 7;
            PositiveInteger positiveInteger = new PositiveInteger(expected);

            // ACT
            int actual = positiveInteger;

            // ASSERT
            actual.Should().Be(expected, "because the cast value should match the constructed value");
        }

        /// <summary>
        /// Given the value when accessed after construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenAccessedAfterConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            const int argumentValue1 = 11;
            var positiveInteger = new PositiveInteger(argumentValue1);

            // ACT
            var actual = positiveInteger.Value;

            // ASSERT
            actual.Should().Be(argumentValue1, "because the value should match the constructed value");
        }
    }
}