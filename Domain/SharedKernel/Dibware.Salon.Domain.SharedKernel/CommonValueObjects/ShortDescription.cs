﻿//-----------------------------------------------------------------------
// <copyright file="ShortDescription.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using Dibware.Salon.Domain.SharedKernel.Amplifiers;
using Dibware.Salon.Domain.SharedKernel.BaseClasses;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;
using Dibware.Salon.Domain.SharedKernel.Guards;

namespace Dibware.Salon.Domain.SharedKernel.CommonValueObjects
{
    /// <summary>
    /// Represents a short description
    /// </summary>
    /// <seealso cref="ValueObject{T}"/>
    [DebuggerDisplay("Value:{" + nameof(Value) + "}")]
    public class ShortDescription : ValueObject<ShortDescription>
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public const byte MaximumCharacterLength = 255;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortDescription"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        private ShortDescription(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets an empty special case <see cref="ShortDescription"/>.
        /// </summary>
        /// <value>The empty.</value>
        public static ShortDescription Empty => CreateInternal(string.Empty);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="ShortDescription"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator ShortDescription(string value)
        {
            var descriptionResult = Create(value);
            Func<string> errorMessageCallback = () => descriptionResult.Error;

            Ensure.IsNotInvalidCast(descriptionResult.IsSuccess, errorMessageCallback);

            return descriptionResult.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="string"/> to <see cref="ShortDescription"/>.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(ShortDescription description)
        {
            return description.Value;
        }

        /// <summary>
        /// If the specified value is valid then creates and returns a new instance of the <see
        /// cref="ShortDescription"/> class using the value and wraps it in an Ok <see
        /// cref="Result{name}"/>; otherwise creates a fail <see cref="Result{ShortDescription}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Result{ShortDescription}"/>.</returns>
        /// Thrown if value length exceeds
        /// <see cref="MaximumCharacterLength"/>
        /// .
        public static Result<ShortDescription> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Result.Fail<ShortDescription>(ShortDescriptionErrorKeys.IsNullEmptyOrWhiteSpace);
            if (value.Length > MaximumCharacterLength) return Result.Fail<ShortDescription>(ShortDescriptionErrorKeys.IsTooLong);

            return Result.Ok(CreateInternal(value));
        }

        /// <summary>
        /// Determines whether the specified <see cref="ShortDescription"/>, is equal to this
        /// instance of <see cref="ShortDescription"/>.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="ShortDescription"/> is equal to this instance;
        /// otherwise, <c>false</c>.
        /// </returns>
        protected override bool EqualsCore(ShortDescription other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>Returns a hash code for this instance</returns>
        protected override int GetHashCodeCore()
        {
            int initialPrimeNumber = 149;
            int multiplierPrimeNumber = 53;

            // Overflow is fine, just wrap
            unchecked
            {
                int hash = initialPrimeNumber;

                hash = (hash * multiplierPrimeNumber) + Value.GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Internal method to create a <see cref="ShortDescription"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="ShortDescription"/>.</returns>
        private static ShortDescription CreateInternal(string value)
        {
            return new ShortDescription(value);
        }
    }
}