﻿// <copyright file="ValueObject.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using Dibware.Salon.Domain.SharedKernel.Helpers;

namespace Dibware.Salon.Domain.SharedKernel.BaseClasses
{
    /// <summary>Represents the base class which a descriptive aspect of the domain with no conceptual identity should inherit from.</summary>
    /// <typeparam name="T">The type which this object wraps</typeparam>
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        /// <summary>Implementation of the the != comparison operator for the <see cref="Entity"/>.</summary>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator !=(ValueObject<T> primary, ValueObject<T> secondary)
        {
            return !(primary == secondary);
        }

        /// <summary>Implementation of the the == comparison operator for the <see cref="Entity"/>.</summary>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator ==(ValueObject<T> primary, ValueObject<T> secondary)
        {
            if (ReferenceHelper.BothReferencesAreNull(primary, secondary))
                return true;

            if (ReferenceHelper.OneOrTheOtherReferenceIsNull(primary, secondary))
                return false;

            // ReSharper disable once PossibleNullReferenceException
            // Because primary has already been checked for null
            return primary.Equals(secondary);
        }

        /// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        /// <summary>Override this method with the derived implementation of `Equals`.</summary>
        /// <param name="other">The other.</param>
        /// <returns>Returns <c>true</c> if it equals; otherwise <c>false</c>.</returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// Override this method with the derived implementation of `GetsHashCode`.
        /// </summary>
        /// <returns>Returns a <see cref="int"/> representaion of the has code</returns>
        protected abstract int GetHashCodeCore();
    }
}