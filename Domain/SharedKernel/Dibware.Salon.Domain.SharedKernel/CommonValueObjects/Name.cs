//-----------------------------------------------------------------------
// <copyright file="Name.cs" company="Dibware">
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
    /// Represents a name
    /// </summary>
    /// <seealso cref="ValueObject{T}"/>
    [DebuggerDisplay("Value:{" + nameof(Value) + "}")]
    public class Name : NameBase
    {
        /// <summary>
        /// The maximum number of characters this instance can be.
        /// </summary>
        public new const byte MaximumCharacterLength = 100;

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if value is null, empty or white space.
        /// </exception>
        private Name(string value)
            : base(value)
        {
        }

        /// <summary>
        /// Gets an empty special case <see cref="Name"/>.
        /// </summary>
        /// <value>The empty.</value>
        public static Name Empty => CreateInternal(string.Empty);

        /// <summary>
        /// Performs an explicit conversion from <see cref="string"/> to <see cref="Name"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Name(string value)
        {
            var nameResult = Create(value);
            Func<string> errorMessageCallback = () => nameResult.Error;

            Ensure.IsNotInvalidCast(nameResult.IsSuccess, errorMessageCallback);

            return nameResult.Value;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Name"/> to <see cref="string"/> .
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        /// <summary>
        /// If the specified value is valid then creates and returns a new instance of the <see
        /// cref="Name"/> class using the value and wraps it in an Ok <see cref="Result{name}"/>;
        /// otherwise creates a fail <see cref="Result{Name}"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Result{Name}"/>.</returns>
        /// Thrown if value length exceeds
        /// <see cref="MaximumCharacterLength"/>
        /// .
        public static Result<Name> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return Result.Fail<Name>(NameErrorKeys.IsNullEmptyOrWhiteSpace);
            if (value.Length > MaximumCharacterLength) return Result.Fail<Name>(NameErrorKeys.IsTooLong);

            return Result.Ok(CreateInternal(value));
        }

        /// <summary>
        /// Internal method to create a <see cref="Name"/> object.
        /// Warning: This function bypasses argument validation.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Returns a newly constructed <see cref="Name"/>.</returns>
        private static Name CreateInternal(string value)
        {
            return new Name(value);
        }
    }
}