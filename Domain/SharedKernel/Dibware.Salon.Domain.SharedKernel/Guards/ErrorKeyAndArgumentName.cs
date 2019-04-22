//-----------------------------------------------------------------------
// <copyright file="ErrorKeyAndArgumentName.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Dibware.Salon.Domain.SharedKernel.Constants.ErrorKeys;

namespace Dibware.Salon.Domain.SharedKernel.Guards
{
    /// <summary>
    /// Encapsulates and error key and argument name
    /// </summary>
    public class ErrorKeyAndArgumentName : ErrorKeyBase
    {
        private readonly string _errorKey;
        private readonly string _argumentName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorKeyAndArgumentName"/> class.
        /// </summary>
        /// <param name="errorKey">The error key.</param>
        /// <param name="argumentName">Name of the argument.</param>
        private ErrorKeyAndArgumentName(string errorKey, string argumentName)
        {
            Ensure.IsNotNullEmptyOrWhiteSpace(errorKey, (ArgumentName)nameof(errorKey));
            Ensure.IsNotNullEmptyOrWhiteSpace(argumentName, (ArgumentName)nameof(argumentName));

            _errorKey = errorKey;
            _argumentName = argumentName;
        }

        /// <summary>
        /// Gets the name of the argument.
        /// </summary>
        /// <value>The name of the argument.</value>
        public string ArgumentName => _argumentName;

        /// <summary>
        /// Gets the error key.
        /// </summary>
        /// <value>The error key.</value>
        public string ErrorKey => _errorKey;

        /// <summary>
        /// Creates an instance of a the specified error key.
        /// </summary>
        /// <param name="errorKey">The error key.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <returns>Returns a constructed <see cref="ErrorKeyAndArgumentName"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if errorKey or argumentName is null, empty or white space.
        /// </exception>
        public static ErrorKeyAndArgumentName Create(string errorKey, string argumentName)
        {
            Ensure.IsNotNullEmptyOrWhiteSpace(errorKey, (ArgumentName)nameof(errorKey));
            Ensure.IsNotNullEmptyOrWhiteSpace(argumentName, (ArgumentName)nameof(argumentName));

            return new ErrorKeyAndArgumentName(errorKey, argumentName);
        }
    }
}