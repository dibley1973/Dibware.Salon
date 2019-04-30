// <copyright file="DurationUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using System;
using Dibware.Salon.Domain.SharedKernel.Measures;
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
        private static readonly Hours ValidHours = new Hours(4);
        private static readonly MinutesPastAnHour ValidMinutes = new MinutesPastAnHour(16);
        private static readonly object[] DurationAdditionData =
        {
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0)),
                new Duration(new Hours(0), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(1), new MinutesPastAnHour(0)),
                new Duration(new Hours(2), new MinutesPastAnHour(0)),
                new Duration(new Hours(3), new MinutesPastAnHour(0))
            },
            new object[]
            {
                new Duration(new Hours(0), new MinutesPastAnHour(4)),
                new Duration(new Hours(0), new MinutesPastAnHour(5)),
                new Duration(new Hours(0), new MinutesPastAnHour(9))
            },
            new object[]
            {
                new Duration(new Hours(1), new MinutesPastAnHour(4)),
                new Duration(new Hours(2), new MinutesPastAnHour(5)),
                new Duration(new Hours(3), new MinutesPastAnHour(9))
            },
            new object[]
            {
                new Duration(new Hours(1), new MinutesPastAnHour(59)),
                new Duration(new Hours(1), new MinutesPastAnHour(2)),
                new Duration(new Hours(3), new MinutesPastAnHour(1))
            }
        };

        /// <summary>Given the constructor when passed null hours then throws exception.</summary>
        [Test]
        public void GivenConstructor_WhenPassedNullHours_ThenThrowsException()
        {
            // ARRANGE
            const Hours nullHours = null;

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
            const MinutesPastAnHour nullMinutes = null;

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
        /// Given the add when supplied null other then throws exception.
        /// </summary>
        [Test]
        public void GivenAdd_WhenSuppliedNullOther_ThenThrowsException()
        {
            // ARRANGE
            var duration1 = new Duration(ValidHours, new MinutesPastAnHour(5));
            const Duration nullDuration = null;

            // ACT
            Action actual = () => duration1.Add(nullDuration);

            // ASSERT
            actual.Should().Throw<ArgumentNullException>("because a null other duration is not permitted");
        }

        /// <summary>
        /// Given the add when supplied valid other then returns constructed duration with correct value.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        /// <param name="expectedDuration">The expected duration.</param>
        [Test]
        [TestCaseSource(nameof(DurationAdditionData))]
        public void GivenAdd_WhenSuppliedValidOther_ThenReturnsConstructedDurationWithCorrectValue(
            Duration duration1,
            Duration duration2,
            Duration expectedDuration)
        {
            // ACT
            var actual = duration1.Add(duration2);

            // ASSERT
            actual.Should().Be(expectedDuration, "because the addition of the two durations should equal the result");
        }

        /// <summary>
        /// Given the addition operator when supplied valid other then returns constructed duration with correct value.
        /// </summary>
        /// <param name="duration1">The duration1.</param>
        /// <param name="duration2">The duration2.</param>
        /// <param name="expectedDuration">The expected duration.</param>
        [Test]
        [TestCaseSource(nameof(DurationAdditionData))]
        public void GivenAdditionOperator_WhenSuppliedValidOther_ThenReturnsConstructedDurationWithCorrectValue(
            Duration duration1,
            Duration duration2,
            Duration expectedDuration)
        {
            // ACT
            var actual = duration1 + duration2;

            // ASSERT
            actual.Should().Be(expectedDuration, "because the addition of the two durations should equal the result");
        }

        /// <summary>Given the get hash code when for two different values then they differ.</summary>
        [Test]
        public void GivenGetHashCode_WhenForTwoDifferentValues_ThenTheyDiffer()
        {
            // ARRANGE
            var duration1 = new Duration(ValidHours, new MinutesPastAnHour(5));
            var duration2 = new Duration(ValidHours, new MinutesPastAnHour(6));

            // ACT
            var actual1 = duration1.GetHashCode();
            var actual2 = duration2.GetHashCode();

            // ASSERT
            actual1.Should().NotBe(actual2, "because the hash codes should differ for different values");
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
            var duration = Hours.NumberOfMinutesInAnHour;

            // ACT
            var actual = duration.Value;

            // ASSERT
            actual.Should().Be(60, "because there are sixty minutes in an hour");
        }

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
            var differentHours = new Hours(5);
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
            var differentMinutes = new MinutesPastAnHour(15);
            var duration1 = new Duration(ValidHours, ValidMinutes);
            var duration2 = new Duration(ValidHours, differentMinutes);

            // ACT
            var actual = duration1 == duration2;

            // ASSERT
            actual.Should().BeFalse("because the minutes differ");
        }

        /// <summary>
        /// Given the total number of minutes when accessed after construction then correctly calculates minutes for all hours and minutes combined.
        /// </summary>
        [Test]
        public void GivenTotalNumberOfMinutes_WhenAccessedAfterConstruction_ThenCorrectlyCalculatesMinutesForAllHoursAndMinutesCombined()
        {
            // ARRANGE
            var tenMinuteDuration = new Duration(new Hours(0), new MinutesPastAnHour(10));
            var oneHourDuration = new Duration(new Hours(1), new MinutesPastAnHour(0));
            var oneHourTenMinuteDuration = new Duration(new Hours(1), new MinutesPastAnHour(10));
            var twoHoursFifteenMinutesDuration = new Duration(new Hours(2), new MinutesPastAnHour(15));

            const int tenMinuteDurationExpected = 10;
            const int oneHourDurationExpected = 60;
            const int oneHourTenMinuteDurationExpected = 70;
            var twoHoursFifteenMinutesDurationInMinutes = new Minutes(135);

            // ACT
            var actualForTenMinuteDuration = tenMinuteDuration.TotalNumberOfMinutes().Value;
            var actualForOneHourDuration = oneHourDuration.TotalNumberOfMinutes().Value;
            var actualForOneHourTenMinuteDuration = oneHourTenMinuteDuration.TotalNumberOfMinutes().Value;
            var actualForTwoHoursFifteenMinutesDuration = twoHoursFifteenMinutesDuration.TotalNumberOfMinutes();

            // ASSERT
            actualForTenMinuteDuration.Should().Be(tenMinuteDurationExpected);
            actualForOneHourDuration.Should().Be(oneHourDurationExpected);
            actualForOneHourTenMinuteDuration.Should().Be(oneHourTenMinuteDurationExpected);
            actualForTwoHoursFifteenMinutesDuration.Should().Be(twoHoursFifteenMinutesDurationInMinutes);
        }

        /// <summary>
        /// Given to string when accessed after construction then returns correct formatted text.
        /// </summary>
        [Test]
        public void GivenToString_WhenAccessedAfterConstruction_ThenReturnsCorrectFormattedText()
        {
            // ARRANGE
            var minutes = new MinutesPastAnHour(55);
            var hours = new Hours(7);
            var minutesPastAnHour = new Duration(hours, minutes);

            // ACT
            var actual = minutesPastAnHour.ToString();

            // ASSERT
            actual.Should().Be("Hours: 7, Minutes: 55");
        }
    }
}