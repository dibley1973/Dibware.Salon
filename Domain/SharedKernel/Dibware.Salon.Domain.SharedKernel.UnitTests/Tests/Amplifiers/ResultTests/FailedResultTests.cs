﻿//-----------------------------------------------------------------------
// <copyright file="FailedResultTests.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.UnitTests.Fakes;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    /// <summary>
    /// Tests the <see cref="Result"/>class.
    /// </summary>
    internal class FailedResultTests
    {
        /// <summary>
        /// Given the Error property when a non generic result fail then message should match supplied message.
        /// </summary>
        [Test]
        public void GivenError_WhenANonGenericResultFail_ThenMessageShouldMatchSuppliedMessage()
        {
            // ARRANGE
            var result = Result.Fail("Error message");

            // ASSERT
            result.Error.Should().Be("Error message");
        }

        /// <summary>
        /// Given the isFailure property when a non generic result fail then should be true.
        /// </summary>
        [Test]
        public void GivenIsFailure_WhenANonGenericResultFail_ThenShouldBeTrue()
        {
            // ARRANGE
            var result = Result.Fail("Error message");

            // ASSERT
            result.IsFailure.Should().Be(true);
        }

        /// <summary>
        /// Given the IsSuccess property when a non generic fail result then should be false.
        /// </summary>
        [Test]
        public void GivenIsSuccess_WhenANonGenericFailResult_ThenShouldBeFalse()
        {
            // ARRANGE
            var result = Result.Fail("Error message");

            // ASSERT
            result.IsSuccess.Should().Be(false);
        }

        /// <summary>
        /// Given the Error property when a generic result fail then message should match supplied message.
        /// </summary>
        [Test]
        public void GivenError_WhenAGenericResultFail_ThenMessageShouldMatchSuppliedMessage()
        {
            // ARRANGE
            var result = Result.Fail<FakeEntity>("Error message");

            // ASSERT
            result.Error.Should().Be("Error message");
        }

        /// <summary>
        /// Given the isFailure property when a generic result fail then should be true.
        /// </summary>
        [Test]
        public void GivenIsFailure_WhenAGenericResultFail_ThenShouldBeTrue()
        {
            // ARRANGE
            var result = Result.Fail<FakeEntity>("Error message");

            // ASSERT
            result.IsFailure.Should().Be(true);
        }

        /// <summary>
        /// Given the IsSuccess property when a generic fail result then should be false.
        /// </summary>
        [Test]
        public void GivenIsSuccess_WhenAGenericFailResult_ThenShouldBeFalse()
        {
            // ARRANGE
            var result = Result.Fail<FakeEntity>("Error message");

            // ASSERT
            result.IsSuccess.Should().Be(false);
        }

        /// <summary>
        /// Given the value property when a generic fail result then throws exception.
        /// </summary>
        [Test]
        public void GivenValueProperty_WhenAGenericfailResult_ThenThrowsException()
        {
            // ARRANGE
            var result = Result.Fail<FakeEntity>("Error message");

            // ACT
            Action action = () => { FakeEntity dummy = result.Value; };

            // ASSERT
            action.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Given a non generic fail creation when null message throws exception.
        /// </summary>
        [Test]
        public void GivenANonGenericFailCreation_WhenNullMessage_ThrowsException()
        {
            // ARRANGE
            Action action1 = () => { Result.Fail(null); };

            // ASSERT
            action1.Should().Throw<ArgumentNullException>();
        }

        /// <summary>
        /// Given a non generic fail creation when empty string message throws exception.
        /// </summary>
        [Test]
        public void GivenANonGenericFailCreation_WhenEmptyStringMessage_ThrowsException()
        {
            // ARRANGE
            Action action2 = () => { Result.Fail(string.Empty); };

            // ASSERT
            action2.Should().Throw<ArgumentNullException>();
        }

        /// <summary>
        /// Given a generic fail creation when null message throws exception.
        /// </summary>
        [Test]
        public void GivenAGenericFailCreation_WhenNullMessage_ThrowsException()
        {
            // ARRANGE
            Action action3 = () => { Result.Fail<FakeEntity>(null); };

            // ASSERT
            action3.Should().Throw<ArgumentNullException>();
        }

        /// <summary>
        /// Given a generic fail creation when empty string message throws exception.
        /// </summary>
        [Test]
        public void GivenAGenericFailCreation_WhenEmptyStringMessage_ThrowsException()
        {
            // ARRANGE
            Action action4 = () => { Result.Fail<FakeEntity>(string.Empty); };

            // ASSERT
            action4.Should().Throw<ArgumentNullException>();
        }
    }
}