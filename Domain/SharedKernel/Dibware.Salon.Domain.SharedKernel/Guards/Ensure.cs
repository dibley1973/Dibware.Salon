//-----------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using Dibware.Salon.Domain.SharedKernel.CommonValueObjects;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;

namespace Dibware.Salon.Domain.SharedKernel.Guards
{
    /// <summary>
    /// Contains guard-clause implementation
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Ensures that the specified value does not equal the default for the type, and throws an
        /// exception if it is..
        /// </summary>
        /// <typeparam name="T">Indicates the type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the value equals it's default type.
        /// </exception>
        public static void IsNotDefault<T>(T value, ArgumentName argumentName)
        {
            if (value.Equals(default(T)))
                throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsDefault);
        }

        /// <summary>
        /// Ensures the specified value is not null, and throws an exception if it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNull(object value, ArgumentName argumentName)
        {
            if (value == null)
                throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsNull);
        }

        /// <summary>
        /// Ensures the specified value is not null or empty, and throws an exception if it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNullOrEmpty(string value, ArgumentName argumentName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsNotNullOrEmpty);
        }

        /// <summary>
        /// Ensures the specified value is not null, empty or white space and throws an exception if
        /// it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="errorMessage">The error message to display</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNullEmptyOrWhiteSpace(string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(errorMessage);
        }

        /// <summary>
        /// Ensures the specified value is not null, empty or white space and throws an exception if
        /// it is.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <exception cref="ArgumentNullException">thrown if value is null.</exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNullEmptyOrWhiteSpace(string value, ArgumentName argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(argumentName, EnsureErrorKeys.ArgumentIsNullEmptyOrWhiteSpace);
        }

        /// <summary>
        /// Determines whether the specified valid condition is <c>false and if it is, throws an <see
        /// cref="InvalidOperationException"/> with the specified message</c>.
        /// </summary>
        /// <param name="validCondition">
        /// Set to <c>true</c> to indicate an valid condition; otherwise <c>false</c>.
        /// </param>
        /// <param name="message">The message.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the specified validCondition argument evaluates to false
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotInvalidOperation(bool validCondition, string message)
        {
            if (!validCondition)
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Determines whether the specified valid condition is <c>false and if it is, throws an <see
        /// cref="InvalidOperationException"/> with the specified message</c>.
        /// </summary>
        /// <param name="validConditionCallBackPredicate">
        /// A callback function which when the result is evaluated should be the <c>true</c> to
        /// indicate an valid condition; otherwise <c>false</c>.
        /// </param>
        /// <param name="message">The message.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if when the specified validConditionCallBackPredicate argument is evaluated the
        /// result is <c>false</c>.
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotInvalidOperation(Func<bool> validConditionCallBackPredicate, string message)
        {
            if (!validConditionCallBackPredicate())
                throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Determines whether the specified valid condition is <c>false and if it is, throws an <see
        /// cref="InvalidCastException"/> with the specified message</c>.
        /// </summary>
        /// <param name="validCondition">
        /// Set to <c>true</c> to indicate an valid condition; otherwise <c>false</c>.
        /// </param>
        /// <param name="message">The message.</param>
        /// <exception cref="InvalidCastException">
        /// Thrown if the specified validCondition argument evaluates to false
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotInvalidCast(bool validCondition, string message)
        {
            if (!validCondition)
                throw new InvalidCastException(message);
        }

        /// <summary>
        /// Determines whether the specified valid condition is <c>false and if it is, throws an <see
        /// cref="InvalidCastException"/> with the specified message</c>.
        /// </summary>
        /// <param name="validCondition">
        /// Set to <c>true</c> to indicate an valid condition; otherwise <c>false</c>.
        /// </param>
        /// <param name="errorMessageCallback">
        /// A callback function which when executed returns the error message.
        /// </param>
        /// <exception cref="InvalidCastException">
        /// Thrown if the specified validCondition argument evaluates to false
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotInvalidCast(bool validCondition, Func<string> errorMessageCallback)
        {
            if (!validCondition)
                throw new InvalidCastException(errorMessageCallback());
        }

        /// <summary>
        /// Determines whether the specified valid condition is <c>false and if it is, throws an <see
        /// cref="InvalidCastException"/> with the specified message</c>.
        /// </summary>
        /// <param name="validConditionCallBackPredicate">
        /// A callback function which when the result is evaluated should be the <c>true</c> to
        /// indicate an valid condition; otherwise <c>false</c>.
        /// </param>
        /// <param name="message">The message.</param>
        /// <exception cref="InvalidCastException">
        /// Thrown if when the specified validConditionCallBackPredicate argument is evaluated the
        /// result is <c>false</c>.
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotInvalidCast(Func<bool> validConditionCallBackPredicate, string message)
        {
            if (!validConditionCallBackPredicate())
                throw new InvalidCastException(message);
        }

        /// <summary>
        /// Determines whether the specified valid condition is <c>false and if it is, throws an <see
        /// cref="InvalidCastException"/> with the specified message</c>.
        /// </summary>
        /// <param name="validConditionCallBackPredicate">
        /// A callback function which when the result is evaluated should be the <c>true</c> to
        /// indicate an valid condition; otherwise <c>false</c>.
        /// </param>
        /// <param name="errorMessageCallback">
        /// A callback function which when executed returns the error message.
        /// </param>
        /// <exception cref="InvalidCastException">
        /// Thrown if when the specified validConditionCallBackPredicate argument is evaluated the
        /// result is <c>false</c>.
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotInvalidCast(Func<bool> validConditionCallBackPredicate, Func<string> errorMessageCallback)
        {
            if (!validConditionCallBackPredicate())
                throw new InvalidCastException(errorMessageCallback());
        }

        /// <summary>
        /// Determines whether [is not greater than int maximum value] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the value is greater than <see cref="int.MaxValue"/>
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotGreaterThanIntMaxValue(long value, ArgumentName argumentName, ShortDescription message)
        {
            if (IsValueGreaterThanMaximumIntValue(value))
                throw new ArgumentOutOfRangeException(argumentName, value, message);
        }

        /// <summary> Ensures that the specified value is not negative.</summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the specified value is negative
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNegative(int value, ArgumentName argumentName)
        {
            if (IsNegative(value))
                throw new ArgumentOutOfRangeException(argumentName, value, EnsureErrorKeys.ArgumentIsNotInRange);
        }

        /// <summary> Ensures that the specified value is not negative.</summary>
        /// <param name="value">The value.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <param name="message">The message which describes the reason.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the specified value is negative
        /// </exception>
        [DebuggerHidden]
        [DebuggerStepThrough]
        public static void IsNotNegative(int value, ArgumentName argumentName, ShortDescription message)
        {
            if (IsNegative(value))
                throw new ArgumentOutOfRangeException(argumentName, value, message);
        }

        /// <summary>Determines whether the specified value is negative, or not.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c>true</c> if the specified value is negative; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsNegative(int value)
        {
            return value < 0;
        }

        /// <summary>
        /// Determines whether the specified value is greater than the maximum int value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c>true</c> if the specified value is greater than the maximum int value; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsValueGreaterThanMaximumIntValue(long value)
        {
            return value > int.MaxValue;
        }
    }
}