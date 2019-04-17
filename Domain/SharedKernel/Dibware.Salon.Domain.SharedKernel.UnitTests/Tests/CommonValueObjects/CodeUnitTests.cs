﻿//-----------------------------------------------------------------------
// <copyright file="CodeUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.CommonValueObjects;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.CommonValueObjects
{
    /// <summary>
    /// Test for <see cref="Code"/> structure
    /// </summary>
    [TestFixture]
    public class CodeUnitTests
    {
        /// <summary>
        /// Given Create method when called with null value then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithNullValue_ThenReturnsFailResult()
        {
            // ARRANGE

            // ACT
            var actual = Code.Create(null);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CodeErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given Create method when called with empty string then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithEmptyValue_ThenReturnsFailResult()
        {
            // ARRANGE

            // ACT
            var actual = Code.Create(string.Empty);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CodeErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given Create method when called with white space then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithWhiteSpace_ThenReturnsFailResult()
        {
            // ARRANGE

            // ACT
            var actual = Code.Create("  ");

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CodeErrorKeys.IsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Given Create method when called with value longer than maximum length then returns fail result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueLongerThanMaximumLength_ThenReturnsFailResult()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength + 1);

            // ACT
            var actual = Code.Create(value);

            // ASSERT
            actual.IsFailure.Should().BeTrue();
            actual.Error.Should().Be(CodeErrorKeys.IsTooLong);
        }

        /// <summary>
        /// Given Create method when called with value at maximum returns success result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueAtMaximumLength_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength);

            // ACT
            var actual = Code.Create(value);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given Create method when called with value less than maximum returns success result.
        /// </summary>
        [Test]
        public void GivenCreate_WhenCalledWithValueLessThanMaximumLength_ThenReturnsSuccessResult()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength - 1);

            // ACT
            var actual = Code.Create(value);

            // ASSERT
            actual.IsSuccess.Should().BeTrue();
        }

        /// <summary>
        /// Given the value when read after valid construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenValue_WhenReadAfterValidConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength - 1);
            var codeResult = Code.Create(value);
            var code = codeResult.Value;

            // ACT
            var actual = code.Value;

            // ASSERT
            actual.Should().Be(value);
        }

        /// <summary>
        /// Given the equals method, when same value strings then returns true.
        /// </summary>
        [Test]
        public void GivenEquals_WhenSameValueStrings_ThenReturnsTrue()
        {
            // ARRANGE
            var code1Result = Code.Create("Code");
            var code1 = code1Result.Value;
            var code2Result = Code.Create("Code");
            var code2 = code2Result.Value;

            // ACT
            var actual = code1.Equals(code2);

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>Given the empty code when accessed then has empty value.</summary>
        [Test]
        public void GivenEmpty_WhenAccessed_ThenHasEmptyValue()
        {
            // ARRANGE
            var emptyCode = Code.Empty;

            // ACT
            var actual = emptyCode.Value;

            // ASSERT
            actual.Should().BeEmpty("because the empty code does not contain a value");
        }

        /// <summary>
        /// Given the equals method, when different value strings then returns false.
        /// </summary>
        [Test]
        public void GivenEquals_WhenDifferentValueStrings_ThenReturnsFalse()
        {
            // ARRANGE
            var code1Result = Code.Create("Code1");
            var code1 = code1Result.Value;
            var code2Result = Code.Create("Code2");
            var code2 = code2Result.Value;

            // ACT
            var actual = code1.Equals(code2);

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the get hash code, when same value strings then returns true.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenSameValueStrings_ThenReturnsTrue()
        {
            // ARRANGE
            var code1Result = Code.Create("Code");
            var code1 = code1Result.Value;
            var code2Result = Code.Create("Code");
            var code2 = code2Result.Value;

            // ACT
            var actual = code1.GetHashCode().Equals(code2.GetHashCode());

            // ASSERT
            actual.Should().BeTrue();
        }

        /// <summary>
        /// Given the get hash code, when different value strings then returns false.
        /// </summary>
        [Test]
        public void GivenGetHashCode_WhenDifferentValueStrings_ThenReturnsFalse()
        {
            // ARRANGE
            var code1Result = Code.Create("Code1");
            var code1 = code1Result.Value;
            var code2Result = Code.Create("Code2");
            var code2 = code2Result.Value;

            // ACT
            var actual = code1.GetHashCode().Equals(code2.GetHashCode());

            // ASSERT
            actual.Should().BeFalse();
        }

        /// <summary>
        /// Given the explicit string operator when cast from string at maximum length then created
        /// code with same value.
        /// </summary>
        [Test]
        public void GivenExplicitStringOperator_WhenCastFromStringAtMaximumLength_ThenCreatedCodeWithSameValue()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength);

            // ACT
            var actual = (Code)value;

            // ASSERT
            actual.Value.Should().Be(value);
        }

        /// <summary>
        /// Given the explicit string operator when cast from string over maximum length then throws exception.
        /// </summary>
        [Test]
        public void GivenExplicitStringOperator_WhenCastFromStringOverMaximumLength_ThrowsException()
        {
            // ARRANGE
            var value = new string('A', Code.MaximumCharacterLength + 1);

            // ReSharper disable once NotAccessedVariable
            var code = default(Code);

            // ACT
            Action actual = () =>
            {
                code = (Code)value;
            };

            // ASSERT
            actual.Should().Throw<InvalidCastException>();
        }

        /// <summary>
        /// Given the implicit string operator when cast to string then created name with same value.
        /// </summary>
        [Test]
        public void GivenImplicitStringOperator_WhenCastToString_ThenCreatedCodeWithSameValue()
        {
            // ARRANGE
            var value = "Code";
            var nameResult = Code.Create(value);
            var name = nameResult.Value;

            // ACT
            string actual = name;

            // ASSERT
            actual.Should().Be(value);
        }
    }
}