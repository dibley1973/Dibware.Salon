﻿// <copyright file="DurationUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;
using Dibware.Salon.Domain.SharedKernel.Measures;
using Dibware.Salon.Domain.SharedKernel.Primitives;
using FluentAssertions;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Measures
{
    /// <summary>
    /// Provides unit tests for the <see cref="Duration"/> class.
    /// </summary>
    [TestFixture]
    public class DurationUnitTests
    {
        private static readonly PositiveInteger ValidHours = new PositiveInteger(4);
        private static readonly PositiveInteger ValidMinutes = new PositiveInteger(16);

        /// <summary>Given the constructor when passed null hours then throws exception.</summary>
        [Test]
        public void GivenConstructor_WhenPassedNullHours_ThenThrowsException()
        {
            // ARRANGE
            const PositiveInteger nullHours = null;

            // ACT
            Action actual = () => new Duration(nullHours, ValidMinutes);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null hours is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed null minutes then throws exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedNullMinutes_ThenThrowsException()
        {
            // ARRANGE
            const PositiveInteger nullMinutes = null;

            // ACT
            Action actual = () => new Duration(ValidHours, nullMinutes);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null minutes is not permitted");
        }

        /// <summary>
        /// Given the constructor when passed valid values then does not throw exception.
        /// </summary>
        [Test]
        public void GivenConstructor_WhenPassedValidValues_ThenDoesNotThrowException()
        {
            // ARRANGE

            // ACT
            Action actual = () => new Duration(ValidHours, ValidMinutes);

            // ASSERT
            actual.Should().NotThrow<ArgumentNullException>("because no exception should be thrown for a valid values");
        }

        /// <summary>
        /// Given the hours when called after construction then returns constructed hours.
        /// </summary>
        [Test]
        public void GivenHours_WhenCalledAfterConstruction_ThenReturnsConstructedHours()
        {
            // ARRANGE
            var duration = new Duration(ValidHours, ValidMinutes);

            // ACT
            var actual = duration.Hours;

            // ASSERT
            actual.Should().Be(ValidHours, "because the value should match the constructed value");
        }

        /// <summary>
        /// Given the minutes when called after construction then returns constructed hours.
        /// </summary>
        [Test]
        public void GivenMinutes_WhenCalledAfterConstruction_ThenReturnsConstructedMinutes()
        {
            // ARRANGE
            var duration = new Duration(ValidHours, ValidMinutes);

            // ACT
            var actual = duration.Minutes;

            // ASSERT
            actual.Should().Be(ValidMinutes, "because the value should match the constructed value");
        }

        /// <summary>
        /// Given the number of minutes in an hour when accessed then should be sixty.
        /// </summary>
        [Test]
        public void GivenNumberOfMinutesInAnHour_WhenAccessed_ThenShouldBeSixty()
        {
            // ARRANGE
            var duration = Duration.NumberOfMinutesInAnHour;

            // ACT
            var actual = duration.Value;

            // ASSERT
            actual.Should().Be(60, "because there are sixty minutes in an hour");
        }

        ///// <summary>
        ///// Given the total minutes when called after construction then returns a the result of a calculation based
        ///// upon the constructed hours.
        ///// </summary>
        //[Test]
        //public void GivenTotalMinutes_WhenCalledAfterConstruction_ThenReturnsConstructedHours()
        //{
        //    // ARRANGE
        //    var duration = new Duration(ValidHours, ValidMinutes);

        //    // ACT
        //    var actual = duration.TotalMinutes();

        //    // ASSERT
        //    actual.Should().Be(ValidMinutes, "because the value should match the constructed value");
        //}

        /// <summary>
        /// Given the is equal to when supplied same reference then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedSameReference_ThenReturnsTrue()
        {
            // ARRANGE
            var duration1 = new Duration(ValidHours, ValidMinutes);
            var duration2 = duration1;

            // ACT
            var actual = duration1 == duration2;

            // ASSERT
            actual.Should().BeTrue("because the values are the same");
        }

        /// <summary>
        /// Given the is equal to when supplied equal values then returns true.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedEqualValues_ThenReturnsTrue()
        {
            // ARRANGE
            var duration1 = new Duration(ValidHours, ValidMinutes);
            var duration2 = new Duration(ValidHours, ValidMinutes);

            // ACT
            var actual = duration1 == duration2;

            // ASSERT
            actual.Should().BeTrue("because the values are the same");
        }

        /// <summary>
        /// Given the is equal to when supplied different hours then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedDifferentHours_ThenReturnsFalse()
        {
            // ARRANGE
            var differentHours = new PositiveInteger(5);
            var duration1 = new Duration(ValidHours, ValidMinutes);
            var duration2 = new Duration(differentHours, ValidMinutes);

            // ACT
            var actual = duration1 == duration2;

            // ASSERT
            actual.Should().BeFalse("because the hours differ");
        }

        /// <summary>
        /// Given the is equal to when supplied different minutes then returns false.
        /// </summary>
        [Test]
        public void GivenIsEqualTo_WhenSuppliedDifferentMinutes_ThenReturnsFalse()
        {
            // ARRANGE
            var differentMinutes = new PositiveInteger(15);
            var duration1 = new Duration(ValidHours, ValidMinutes);
            var duration2 = new Duration(ValidHours, differentMinutes);

            // ACT
            var actual = duration1 == duration2;

            // ASSERT
            actual.Should().BeFalse("because the minutes differ");
        }
    }
}