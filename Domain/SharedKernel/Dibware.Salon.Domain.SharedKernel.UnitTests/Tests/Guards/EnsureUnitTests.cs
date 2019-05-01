//-----------------------------------------------------------------------
// <copyright file="EnsureUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Text;
using Dibware.Salon.Domain.SharedKernel.CommonValueObjects;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using Dibware.Salon.Domain.SharedKernel.Guards;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Guards
{
    /// <summary>
    /// Tests the guard clauses
    /// </summary>
    [TestFixture]
    public class EnsureUnitTests
    {
        private const string ParameterNameSuffix = "\r\nParameter name: arg1";

        /// <summary>
        /// Given the is not default when passed default value then throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotDefault_WhenPassedDefaultValue_ThenThrowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var argumentValue = default(Guid);

            // ACT
            Action action = () => Ensure.IsNotDefault(argumentValue, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsDefault + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the is not default when passed non default value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotDefault_WhenPassedNonDefaultValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var argumentValue = Guid.NewGuid();

            // ACT
            Action action = () => Ensure.IsNotDefault(argumentValue, (ArgumentName)argumentName);

            // ASSERT
            action.Should().NotThrow();
        }

        /// <summary>
        /// Given the ensure is not null when passed a null object then throws an exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNull_WhenPassedANullObject_ThenThrowsException()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            Action action = () => Ensure.IsNotNull(null, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNull + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null when passed a not-null object then does not throw and exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNull_WhenPassedANotNullObject_ThenDoesNotThrowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var argumentValue = new StringBuilder();

            // ACT
            Action action = () => Ensure.IsNotNull(argumentValue, (ArgumentName)argumentName);

            // ASSERT
            action.Should().NotThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed null string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedNullString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            Action action = () => Ensure.IsNotNullOrEmpty(null, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullOrEmpty + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed empty string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedEmptyString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = string.Empty;

            // ACT
            Action action = () => Ensure.IsNotNullOrEmpty(value, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNotNullOrEmpty + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null or empty when passed populated string then does not throw exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullOrEmpty_WhenPassedPopulatedString_ThenDoesNotThrowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string('A', 5);

            // ACT
            Action action = () => Ensure.IsNotNullOrEmpty(value, (ArgumentName)argumentName);

            // ASSERT
            action.Should().NotThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed null string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedNullString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(null, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNullEmptyOrWhiteSpace + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed empty string then thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedEmptyString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = string.Empty;

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(value, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNullEmptyOrWhiteSpace + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed white space string then
        /// thows exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedWhiteSpaceString_ThenThowsException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string(' ', 5);

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(value, (ArgumentName)argumentName);

            // ASSERT
            action.Should().Throw<ArgumentNullException>().WithMessage(EnsureErrorKeys.ArgumentIsNullEmptyOrWhiteSpace + ParameterNameSuffix);
        }

        /// <summary>
        /// Given the ensure is not null empty or white space when passed populated string then does
        /// not thow exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNullEmptyOrWhiteSpace_WhenPassedPopulatedString_ThenDoesNotThowException()
        {
            // ARRANGE
            var argumentName = "arg1";
            var value = new string('A', 5);

            // ACT
            Action action = () => Ensure.IsNotNullEmptyOrWhiteSpace(value, (ArgumentName)argumentName);

            // ASSERT
            action.Should().NotThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the is not invalid operation when passed true value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidOperation_WhenPassedTrueValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const bool condition = true;
            var errorMessage = "IsInvalidOperation";

            // ACT
            Action action = () => Ensure.IsNotInvalidOperation(condition, errorMessage);

            // ASSERT
            action.Should().NotThrow<InvalidOperationException>();
        }

        /// <summary>
        /// Given the is not invalid operation when passed false value then throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidOperation_WhenPassedFalseValue_ThenThrowsException()
        {
            // ARRANGE
            const bool condition = false;
            var errorMessage = "IsInvalidOperation";

            // ACT
            Action action = () => Ensure.IsNotInvalidOperation(condition, errorMessage);

            // ASSERT
            action.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Given the is not invalid operation when passed function which returns true value then
        /// does not throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidOperation_WhenPassedFunctionWhichReturnsTrueValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            var errorMessage = "IsInvalidOperation";
            bool ConditionCallback()
            {
                return true;
            }

            // ACT
            Action action = () => Ensure.IsNotInvalidOperation(ConditionCallback, errorMessage);

            // ASSERT
            action.Should().NotThrow<InvalidOperationException>();
        }

        /// <summary>
        /// Given the is not invalid operation when passed function which returns false value then
        /// throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidOperation_WhenPassedFunctionWhichReturnsFalseValue_ThenThrowsException()
        {
            // ARRANGE
            var errorMessage = "IsInvalidOperation";
            bool ConditionCallback()
            {
                return false;
            }

            // ACT
            Action action = () => Ensure.IsNotInvalidOperation(ConditionCallback, errorMessage);

            // ASSERT
            action.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed true value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedTrueValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const bool condition = true;
            var errorMessage = "IsInvalidCast";

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(condition, errorMessage);

            // ASSERT
            action.Should().NotThrow<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed false value then throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedFalseValue_ThenThrowsException()
        {
            // ARRANGE
            const bool condition = false;
            var errorMessage = "IsInvalidCast";

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(condition, errorMessage);

            // ASSERT
            action.Should().Throw<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed true and a function which returns the error
        /// message value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenTrueAndFunctionWhichReturnsMessageValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const bool condition = true;
            string ErrorMessageCallback() => "IsInvalidCast";

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(condition, ErrorMessageCallback);

            // ASSERT
            action.Should().NotThrow<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed false and a function which returns the error
        /// message value then throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedFalseAndFunctionWhichReturnsMessageValue_ThenThrowsException()
        {
            // ARRANGE
            const bool condition = false;
            string ErrorMessageCallback() => "IsInvalidCast";

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(condition, ErrorMessageCallback);

            // ASSERT
            action.Should().Throw<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed function which returns true value then does not
        /// throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedFunctionWhichReturnsTrueValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            var errorMessage = "IsInvalidCast";
            bool ConditionCallback()
            {
                return true;
            }

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(ConditionCallback, errorMessage);

            // ASSERT
            action.Should().NotThrow<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed function which returns false value then throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedFunctionWhichReturnsFalseValue_ThenThrowsException()
        {
            // ARRANGE
            var errorMessage = "IsInvalidCast";
            bool ConditionCallback()
            {
                return false;
            }

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(ConditionCallback, errorMessage);

            // ASSERT
            action.Should().Throw<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed function which returns true and a function
        /// which returns the error message value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedFunctionWhichReturnsTrueAndFunctionWhichReturnsMessageValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            string ErrorMessageCallback() => "IsInvalidCast";
            bool ConditionCallback()
            {
                return true;
            }

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(ConditionCallback, ErrorMessageCallback);

            // ASSERT
            action.Should().NotThrow<InvalidCastException>();
        }

        /// <summary>
        /// Given the is not invalid cast when passed function which returns false and a function
        /// which returns the error message value then throws exception.
        /// </summary>
        [Test]
        public void GivenIsNotInvalidCast_WhenPassedFunctionWhichReturnsFalseAndFunctionWhichReturnsMessageValue_ThenThrowsException()
        {
            // ARRANGE
            string ErrorMessageCallback() => "IsInvalidCast";
            bool ConditionCallback()
            {
                return false;
            }

            // ACT
            Action action = () => Ensure.IsNotInvalidCast(ConditionCallback, ErrorMessageCallback);

            // ASSERT
            action.Should().Throw<InvalidCastException>();
        }

        /// <summary>
        /// Given the ensure is not negative when passed a negative value then throws exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNegative_WhenPassedANegativeValue_ThenThrowsException()
        {
            // ARRANGE
            const string argumentName = "arg1";
            const int argumentNegativeValue = -1;
            var expectedMessage =
                $"{EnsureErrorKeys.ArgumentIsNotInRange}\r\nParameter name: {argumentName}\r\nActual value was {argumentNegativeValue}.";

            // ACT
            Action action = () => Ensure.IsNotNegative(argumentNegativeValue, (ArgumentName)argumentName);

            // ASSERT
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage);
        }

        /// <summary>
        /// Given the ensure is not negative when passed a non negative value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNegative_WhenPassedANonNegativeValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const string argumentName = "arg1";
            const int argumentValue1 = 0;
            const int argumentValue2 = 1;

            // ACT
            Action action1 = () => Ensure.IsNotNegative(argumentValue1, (ArgumentName)argumentName);
            Action action2 = () => Ensure.IsNotNegative(argumentValue2, (ArgumentName)argumentName);

            // ASSERT
            action1.Should().NotThrow<ArgumentNullException>();
            action2.Should().NotThrow<ArgumentNullException>();
        }

        /// <summary>
        /// Given the ensure is not negative with message when passed a negative value then throws exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNegativeWithMessage_WhenPassedANegativeValue_ThenThrowsException()
        {
            // ARRANGE
            const string argumentName = "arg1";
            const string message = "Its wrong";
            const int argumentNegativeValue = -1;
            var expectedMessage =
                $"Its wrong\r\nParameter name: {argumentName}\r\nActual value was {argumentNegativeValue}.";

            // ACT
            Action action = () => Ensure.IsNotNegative(argumentNegativeValue, (ArgumentName)argumentName, (ShortDescription)message);

            // ASSERT
            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage(expectedMessage);
        }

        /// <summary>
        /// Given the ensure is not negative with message when passed a non negative value then does not throw exception.
        /// </summary>
        [Test]
        public void GivenEnsureIsNotNegativeWithMessage_WhenPassedANonNegativeValue_ThenDoesNotThrowException()
        {
            // ARRANGE
            const string argumentName = "arg1";
            const string message1 = "Its wrong";
            const string message2 = "Its wrong too";
            const int argumentValue1 = 0;
            const int argumentValue2 = 1;

            // ACT
            Action action1 = () => Ensure.IsNotNegative(argumentValue1, (ArgumentName)argumentName, (ShortDescription)message1);
            Action action2 = () => Ensure.IsNotNegative(argumentValue2, (ArgumentName)argumentName, (ShortDescription)message2);

            // ASSERT
            action1.Should().NotThrow<ArgumentNullException>();
            action2.Should().NotThrow<ArgumentNullException>();
        }

        /// <summary>Given the ensure is true callback when result is true then does not throw exception.</summary>
        [Test]
        public void GivenEnsureIsTrueCallback_WhenResultIsTrue_ThenDoesNotThrowException()
        {
            // ARRANGE
            var errorMessage = "NotTrue";
            bool IsTrueCallback()
            {
                return true;
            }

            // ACT
            Action actual = () => Ensure.IsTrue(IsTrueCallback, errorMessage);

            // ASSERT
            actual.Should().NotThrow("because callback result was true");
        }

        /// <summary>Given the ensure is true callback when result is false then throws exception.</summary>
        [Test]
        public void GivenEnsureIsTrueCallback_WhenResultIsFalse_ThenThrowsException()
        {
            // ARRANGE
            var errorMessage = "NotTrue";
            bool IsTrueCallback()
            {
                return false;
            }

            // ACT
            Action actual = () => Ensure.IsTrue(IsTrueCallback, errorMessage);

            // ASSERT
            actual.Should().Throw<InvalidOperationException>("because callback result was false")
                .WithMessage(errorMessage);
        }

        /// <summary>Given the ensure is false callback when result is false then does not throw exception.</summary>
        [Test]
        public void GivenEnsureIsFalseCallback_WhenResultIsFalse_ThenDoesNotThrowException()
        {
            // ARRANGE
            var errorMessage = "NotFalse";
            bool IsFalseCallback()
            {
                return false;
            }

            // ACT
            Action actual = () => Ensure.IsFalse(IsFalseCallback, errorMessage);

            // ASSERT
            actual.Should().NotThrow("because callback result was false");
        }

        /// <summary>Given the ensure is false callback when result is true then throws exception.</summary>
        [Test]
        public void GivenEnsureIsFalseCallback_WhenResultIsTrue_ThenThrowsException()
        {
            // ARRANGE
            var errorMessage = "NotFalse";
            bool IsFalseCallback()
            {
                return true;
            }

            // ACT
            Action actual = () => Ensure.IsFalse(IsFalseCallback, errorMessage);

            // ASSERT
            actual.Should().Throw<InvalidOperationException>("because callback result was true")
                .WithMessage(errorMessage);
        }
    }
}