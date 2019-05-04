//-----------------------------------------------------------------------
// <copyright file="ArgumentNameUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using Dibware.Salon.Domain.SharedKernel.Guards;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Guards
{
    /// <summary>
    /// Tests the <see cref="ArgumentName"/>
    /// </summary>
    [TestFixture]
    public class ArgumentNameUnitTests
    {
        /// <summary>
        /// Given the create when passed null value then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedNullValue_ThenReturnsFailResult()
        {
            // ARRANGE
            const string nullValue = null;

            // ACT
            var actual = ArgumentName.Create(nullValue);

            // ASSERT
            actual.IsFailure.Should().BeTrue("because a null value is not valid");
            actual.Error.Should().Be(NameErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the create when passed empty value then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedEmptyValue_ThenReturnsFailResult()
        {
            // ARRANGE
            const string emptyValue = "";

            // ACT
            var actual = ArgumentName.Create(emptyValue);

            // ASSERT
            actual.IsFailure.Should().BeTrue("because an empty value is not valid");
            actual.Error.Should().Be(NameErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the create when passed white space value then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedWhiteSpaceValue_ThenReturnsFailResult()
        {
            // ARRANGE
            const string whiteSpaceValue = "  ";

            // ACT
            var actual = ArgumentName.Create(whiteSpaceValue);

            // ASSERT
            actual.IsFailure.Should().BeTrue("because a whitespace value is not valid");
            actual.Error.Should().Be(NameErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given the create when passed value too long then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedValueTooLong_ThenReturnsFailResult()
        {
            // ARRANGE
            var tooLongValue = new string('A', 256);

            // ACT
            var actual = ArgumentName.Create(tooLongValue);

            // ASSERT
            actual.IsFailure.Should().BeTrue("because too long a value is not valid");
            actual.Error.Should().Be(NameErrorKeys.IsTooLong);
        }

        /// <summary>
        /// Given the create when passed value at maximum length then returns success result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedValueAtMaximumLength_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var toLongValue = new string('A', 255);

            // ACT
            var actual = ArgumentName.Create(toLongValue);

            // ASSERT
            actual.IsSuccess.Should().BeTrue("because a value at maximum length is valid");
        }

        /// <summary>
        /// Given the name of the explicit operator when cast from valid value then returns constructed argument.
        /// </summary>
        [Test]
        public void GivenExplicitOperator_WhenCastFromValidValue_ThenReturnsConstructedArgumentName()
        {
            // ARRANGE
            var validValue = "BillAndBenTheIrishMen";

            // ACT
            var actual = (ArgumentName)validValue;

            // ASSERT
            actual.Should().NotBeNull($"because a valid {nameof(ArgumentName)} should have been created.");
            actual.Value.Should().Be(validValue, "because the value should match the cast from value");
        }

        /// <summary>
        /// Given the explicit operator when cast from null value then throws exception.
        /// </summary>
        [Test]
        public void GivenExplicitOperator_WhenCastFromNullValue_ThenThrowsException()
        {
            // ARRANGE
            const string nullValue = null;
            ArgumentName argumentName = null;

            // ACT
            Action actual = () =>
            {
                argumentName = (ArgumentName)nullValue;
            };

            // ASSERT
            actual.Should().Throw<InvalidCastException>("because an empty string cannot be cast to an argument name");
            argumentName.Should().BeNull();
        }

        /// <summary>
        /// Given the explicit operator when cast from empty value then throws exception.
        /// </summary>
        [Test]
        public void GivenExplicitOperator_WhenCastFromEmptyValue_ThenThrowsException()
        {
            // ARRANGE
            const string emptyValue = "";
            ArgumentName argumentName = null;

            // ACT
            Action actual = () =>
            {
                argumentName = (ArgumentName)emptyValue;
            };

            // ASSERT
            actual.Should().Throw<InvalidCastException>("because an empty string cannot be cast to an argument name");
            argumentName.Should().BeNull();
        }

        /// <summary>
        /// Given the implicit operator when cast to string then returns value.
        /// </summary>
        [Test]
        public void GivenImplicitOperator_WhenCastToString_ThenReturnsValue()
        {
            // ARRANGE
            var validValue = "BillAndBenTheIrishMen";
            var argumentName = (ArgumentName)validValue;

            // ACT
            string actual = argumentName;

            // ASSERT
            actual.Should().Be(validValue, "because casting to string should match constructed value");
        }
    }
}