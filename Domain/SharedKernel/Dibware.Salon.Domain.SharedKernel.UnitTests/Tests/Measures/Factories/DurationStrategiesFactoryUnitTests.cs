//-----------------------------------------------------------------------
// <copyright file="DurationStrategiesFactoryUnitTests.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

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
        /// Given the get duration subtraction strategy when passed true then returns basic duration subtraction strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationSubTractionStrategy_WhenPassedTrue_ThenReturnsBasicDurationSubTractionStrategy()
        {
            // ACT
            var actual = DurationStrategiesFactory.GetDurationSubtractionStrategy(true);

            // ASSERT
            actual.Should()
                .BeOfType<BasicDurationSubtractionStrategy>($"because a {nameof(BasicDurationSubtractionStrategy)} is expected");
        }

        /// <summary>
        /// Given the get duration subtraction strategy when passed false then returns duration subtraction with minute carry over strategy.
        /// </summary>
        [Test]
        public void GivenGetDurationSubTractionStrategy_WhenPassedFalse_ThenReturnsDurationSubTractionWithMinuteCarryOverStrategy()
        {
            // ACT
            var actual = DurationStrategiesFactory.GetDurationSubtractionStrategy(false);

            // ASSERT
            actual.Should()
                .BeOfType<CarryOverMinuteDurationSubtractionStrategy>($"because a {nameof(CarryOverMinuteDurationSubtractionStrategy)} is expected");
        }
    }
}