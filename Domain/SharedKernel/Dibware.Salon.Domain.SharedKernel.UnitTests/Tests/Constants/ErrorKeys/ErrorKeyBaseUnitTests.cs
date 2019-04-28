// <copyright file="ErrorKeyBaseUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Constants.ErrorKeys
{
    /// <summary>
    /// Provides unit tests for the <see cref="ErrorKeyBase"/> class.
    /// </summary>
    [TestFixture]
    public class ErrorKeyBaseUnitTests
    {
        /// <summary>
        /// Given the try parse formatted key when invalid format supplied returns fail result.
        /// </summary>
        [Test]
        public void GivenTryParseFormattedKey_WhenInvalidFormatSupplied_ReturnsFailResult()
        {
            // ARRANGE
            var formattedValue1 = "SpongyOodleBoodle";
            var formattedValue2 = "SpongyOodle;Boodle";
            var formattedValue3 = "Spongy:Oodle:Boodle";

            // ACT
            var actual1 = ErrorKeyBase.TryParseFormattedKey(formattedValue1);
            var actual2 = ErrorKeyBase.TryParseFormattedKey(formattedValue2);
            var actual3 = ErrorKeyBase.TryParseFormattedKey(formattedValue3);

            // ASSERT
            actual1.IsFailure.Should().BeTrue("because a bad format should fail parsing");
            actual2.IsFailure.Should().BeTrue("because a bad format should fail parsing");
            actual3.IsFailure.Should().BeTrue("because a bad format should fail parsing");
        }

        /// <summary>
        /// Given the try parse formatted key when valid format supplied returns success result.
        /// </summary>
        [Test]
        public void GivenTryParseFormattedKey_WhenValidFormatSupplied_ReturnsSuccessResult()
        {
            // ARRANGE
            const string expectedKey = "name";
            const string expectedValue = "FrankieKnuckles";
            var formattedValue1 = $"{expectedKey}:{expectedValue}";

            // ACT
            var actual1 = ErrorKeyBase.TryParseFormattedKey(formattedValue1);

            // ASSERT
            actual1.IsSuccess.Should().BeTrue("because a valid format should succeed in parsing");
        }
    }
}