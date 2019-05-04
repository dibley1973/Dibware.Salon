//-----------------------------------------------------------------------
// <copyright file="DurationStrategiesFactoryUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using Dibware.Salon.Domain.SharedKernel.Measures;
using Dibware.Salon.Domain.SharedKernel.Measures.Factories;
using Dibware.Salon.Domain.SharedKernel.Measures.Strategies;
using FluentAssertions;
using NUnit.Framework;

namespace Dibware.Salon.Domain.SharedKernel.UnitTests.Tests.Measures.Factories
{
    /// <summary>
    /// Test for the <see cref="DurationStrategiesFactory"/> object
    /// </summary>
    public class DurationStrategiesFactoryUnitTests
    {
        /// <summary>
        /// Given the get duration addition strategy when passed true then returns basic duration addition strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationAdditionStrategy_WhenPassedTrue_ThenReturnsBasicDurationAdditionStrategy()
        {
            // ACT
            var actual = DurationStrategiesFactory.GetDurationAdditionStrategy(true);

            // ASSERT
            actual.Should()
                .BeOfType<BasicDurationAdditionStrategy>($"because a {nameof(BasicDurationAdditionStrategy)} is expected");
        }

        /// <summary>
        /// Given the get duration addition strategy when passed false then returns duration addition with minute carry over strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationAdditionStrategy_WhenPassedFalse_ThenReturnsDurationAdditionWithMinuteCarryOverStrategy()
        {
            // ACT
            var actual = DurationStrategiesFactory.GetDurationAdditionStrategy(false);

            // ASSERT
            actual.Should()
                .BeOfType<CarryOverMinuteDurationAdditionStrategy>($"because a {nameof(CarryOverMinuteDurationAdditionStrategy)} is expected");
        }

        /// <summary>
        /// Given the get duration sub traction strategy when passed durations requiring basic duration sub traction strategy then returns basic duration sub traction strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationSubTractionStrategy_WhenPassedDurationsRequiringBasicDurationSubTractionStrategy_ThenReturnsBasicDurationSubTractionStrategy()
        {
            // ARRANGE
            var duration1 = new Duration(new Hours(0), new MinutesPastAnHour(8));
            var duration2 = new Duration(new Hours(0), new MinutesPastAnHour(3));

            // ACT
            var actual = DurationStrategiesFactory.GetDurationSubtractionStrategy(duration1, duration2);

            // ASSERT
            actual.Should()
                .BeOfType<BasicDurationSubtractionStrategy>($"because a {nameof(BasicDurationSubtractionStrategy)} is expected");
        }

        /// <summary>
        /// Given the get duration sub traction strategy when passed durations requiring duration sub traction with minute carry over strategy then returns duration sub traction with minute carry over strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationSubTractionStrategy_WhenPassedDurationsRequiringDurationSubTractionWithMinuteCarryOverStrategy_ThenReturnsDurationSubTractionWithMinuteCarryOverStrategy()
        {
            // ARRANGE
            var duration1 = new Duration(new Hours(2), new MinutesPastAnHour(10));
            var duration2 = new Duration(new Hours(1), new MinutesPastAnHour(12));

            // ACT
            var actual = DurationStrategiesFactory.GetDurationSubtractionStrategy(duration1, duration2);

            // ASSERT
            actual.Should()
                .BeOfType<CarryOverMinuteDurationSubtractionStrategy>($"because a {nameof(CarryOverMinuteDurationSubtractionStrategy)} is expected");
        }

        /// <summary>
        /// Given the get duration sub traction strategy when passed durations requiring zero duration subtraction strategy then returns zero duration subtraction strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationSubTractionStrategy_WhenPassedDurationsRequiringZeroDurationSubtractionStrategy_ThenReturnsZeroDurationSubtractionStrategy()
        {
            // ARRANGE
            var duration1 = new Duration(new Hours(2), new MinutesPastAnHour(10));
            var duration2 = new Duration(new Hours(2), new MinutesPastAnHour(12));

            // ACT
            var actual = DurationStrategiesFactory.GetDurationSubtractionStrategy(duration1, duration2);

            // ASSERT
            actual.Should()
                .BeOfType<ZeroDurationSubtractionStrategy>($"because a {nameof(CarryOverMinuteDurationSubtractionStrategy)} is expected");
        }
    }
}