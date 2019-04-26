//-----------------------------------------------------------------------
// <copyright file="ResultCommonLogicUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Amplifiers.ResultTests
{
    /// <summary>
    /// Unit tests for the <see cref="ResultCommonLogic"/> helper
    /// </summary>
    public class ResultCommonLogicUnitTests
    {
        /// <summary>
        /// Givens the constructor when not failed with error message then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenNotFailedWithErrorMessage_ThenThrowsException()
        {
            // ARRANGE
            const bool notFailed = false;
            const string errorMessage = "Error!";

            // ACT
            // ReSharper disable once ObjectCreationAsStatement
            Action actual = () => new ResultCommonLogic(notFailed, errorMessage);

            // ASSERT
            actual.Should()
                .Throw<ArgumentException>()
                .WithMessage("There should be no error message for success.\r\nParameter name: error");
        }
    }
}