﻿//-----------------------------------------------------------------------
// <copyright file="Result{T}.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using Dibware.Salon.Domain.SharedKernel.Guards;

namespace Dibware.Salon.Domain.SharedKernel.Amplifiers
{
    /// <summary>
    /// Indicates the success of a request, and wraps the resultant object in the case of a
    /// successful call.
    /// </summary>
    /// <typeparam name="T">The type which the result wraps</typeparam>
    /// <remarks>If this class needs to implement `ISerializable` then refer to: https://github.com/vkhorikov/CSharpFunctionalExtensions/blob/master/CSharpFunctionalExtensions/Result.cs</remarks>
    public struct Result<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{T}"/> struct.
        /// </summary>
        /// <param name="isFailure">if set to <c>true</c> is the result is a failure.</param>
        /// <param name="value">The value.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="ArgumentNullException">value</exception>
        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, string error)
        {
#pragma warning disable S125
            // WARNING:
            //      Do not be tempted to replace the guard clause below this comment with the
            //      line below: if (!isFailure) Ensure.IsNotNull(value, (ArgumentName)nameof(value));
            //      If you do you will create a lovely StackOverflowException!
            if (!isFailure && value == null) throw new ArgumentNullException(nameof(value));

            _logic = new ResultCommonLogic(isFailure, error);
            _value = value;
        }
#pragma warning restore S125

        /// <summary>
        /// Gets a value indicating whether this instance is failure.
        /// </summary>
        /// <value><c>true</c> if this instance is failure; otherwise, <c>false</c>.</value>
        public bool IsFailure => _logic.IsFailure;

        /// <summary>
        /// Gets a value indicating whether this instance is success.
        /// </summary>
        /// <value><c>true</c> if this instance is success; otherwise, <c>false</c>.</value>
        public bool IsSuccess => _logic.IsSuccess;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>The error.</value>
        public string Error => _logic.Error;

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <exception cref="InvalidOperationException">There is no value for failure.</exception>
        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                Ensure.IsNotInvalidOperation(IsSuccess, "There is no value for failure.");

                return _value;
            }
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Result{T}"/> to <see cref="Result"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Result(Result<T> result)
        {
            return result.IsSuccess
                ? Result.Ok()
                : Result.Fail(result.Error);
        }
    }
}