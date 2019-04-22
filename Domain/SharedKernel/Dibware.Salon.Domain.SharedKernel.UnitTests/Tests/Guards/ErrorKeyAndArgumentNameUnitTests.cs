//-----------------------------------------------------------------------
// <copyright file="ErrorKeyAndArgumentNameUnitTests.cs" company="Dibware">
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
    /// Tests the <see cref="ErrorKeyAndArgumentName"/>
    /// </summary>
    [TestFixture]
    public class ErrorKeyAndArgumentNameUnitTests
    {
        private const string ValidErrorKey = "Key1";
        private const string ValidArgumentName = "Value1";

        /// <summary>
        /// Givens the create when passed null error key then throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedNullErrorKey_ThenThrowsException()
        {
            // ARRANGE
            const string nullKey = null;
            const string argumentName = "errorKey";

            // ACT
            Action actual = () => ErrorKeyAndArgumentName.Create(nullKey, ValidArgumentName);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null error key is not permitted")
                .WithMessage(GetExpectedMessage(argumentName), "because the exception message should match");
        }

        /// <summary>
        /// Givens the create when passed empty error key then throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedEmptyErrorKey_ThenThrowsException()
        {
            // ARRANGE
            const string emptyKey = "";
            const string argumentName = "errorKey";

            // ACT
            Action actual = () => ErrorKeyAndArgumentName.Create(emptyKey, ValidArgumentName);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because an empty error key is not permitted")
                .WithMessage(GetExpectedMessage(argumentName), "because the exception message should match");
        }

        /// <summary>
        /// Givens the create when passed white space error key then throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedWhiteSpaceErrorKey_ThenThrowsException()
        {
            // ARRANGE
            const string whiteSpaceKey = "    ";
            const string argumentName = "errorKey";

            // ACT
            Action actual = () => ErrorKeyAndArgumentName.Create(whiteSpaceKey, ValidArgumentName);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a white space error key is not permitted")
                .WithMessage(GetExpectedMessage(argumentName), "because the exception message should match");
        }

        /// <summary>
        /// Givens the create when passed null argument name then throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedNullArgumentName_ThenThrowsException()
        {
            // ARRANGE
            const string nullArgumentName = null;
            const string argumentName = "argumentName";

            // ACT
            Action actual = () => ErrorKeyAndArgumentName.Create(ValidErrorKey, nullArgumentName);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null argument name is not permitted")
                .WithMessage(GetExpectedMessage(argumentName), "because the exception message should match");
        }

        /// <summary>
        /// Givens the create when passed empty argument name then throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedEmptyArgumentName_ThenThrowsException()
        {
            // ARRANGE
            const string emptyArgumentName = "";
            const string argumentName = "argumentName";

            // ACT
            Action actual = () => ErrorKeyAndArgumentName.Create(ValidErrorKey, emptyArgumentName);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because an empty argument name is not permitted")
                .WithMessage(GetExpectedMessage(argumentName), "because the exception message should match");
        }

        /// <summary>
        /// Givens the create when passed white space argument name then throws exception.
        /// </summary>
        [Test]
        public void GivenCreate_WhenPassedWhiteSpaceArgumentName_ThenThrowsException()
        {
            // ARRANGE
            const string whiteSpaceArgumentName = "    ";
            const string argumentName = "argumentName";

            // ACT
            Action actual = () => ErrorKeyAndArgumentName.Create(ValidErrorKey, whiteSpaceArgumentName);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a white space argument name is not permitted")
                .WithMessage(GetExpectedMessage(argumentName), "because the exception message should match");
        }

        /// <summary>
        /// Givens the argument name when accessed after construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenArgumentName_WhenAccessedAfterConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var errorKeyAndArgumentName = ErrorKeyAndArgumentName.Create(ValidErrorKey, ValidArgumentName);

            // ACT
            var actual = errorKeyAndArgumentName.ArgumentName;

            // ASSERT
            actual.Should().Be(ValidArgumentName, "because the value of the property should match the constructed value");
        }

        /// <summary>
        /// Givens the key when accessed after construction then returns constructed value.
        /// </summary>
        [Test]
        public void GivenKey_WhenAccessedAfterConstruction_ThenReturnsConstructedValue()
        {
            // ARRANGE
            var errorKeyAndArgumentName = ErrorKeyAndArgumentName.Create(ValidErrorKey, ValidArgumentName);

            // ACT
            var actual = errorKeyAndArgumentName.ErrorKey;

            // ASSERT
            actual.Should().Be(ValidErrorKey, "because the value of the property should match the constructed value");
        }

        /// <summary>
        /// Gets the expected message.
        /// </summary>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>Returns a text representation of the expected message.</returns>
        private static string GetExpectedMessage(string argumentName)
        {
            return $"{EnsureErrorKeys.ArgumentIsNullEmptyOrWhiteSpace}\r\nParameter name: {argumentName}";
        }
    }
}