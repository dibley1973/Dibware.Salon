using System;
using System.Collections.Generic;
using Dibware.Salon.Domain.SharedKernel.Guards;
using Dibware.Salon.Domain.SharedKernel.Helpers;

namespace Dibware.Salon.Domain.SharedKernel.Amplifiers
{
    /// <summary>
    /// Non-nullable wrapper.
    /// </summary>
    /// <typeparam name="TNotNullable">The type of the object which must be not null</typeparam>
    public struct NotNull<TNotNullable> 
        : IEquatable<NotNull<TNotNullable>> 
        where TNotNullable : class
    {
        /// <summary>Initializes a new instance of the <see cref="NotNull{TNotNullable}"/> struct.</summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">Required value cannot be null</exception>
        public NotNull(TNotNullable value)
        {
            value.ThrowExceptionIfNull((ArgumentName)nameof(value));

            Value = value;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(NotNull<TNotNullable> other)
        {
            return EqualityComparer<TNotNullable>.Default.Equals(Value, other.Value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is TNotNullable)
            {
                var value = (TNotNullable) obj;

                return Equals(value);
            }

            if (obj is NotNull<TNotNullable>)
            {
                var notNullable = (NotNull<TNotNullable>) obj;

                return Equals(notNullable.Value);
            }

            return false;
        }

        /// <summary>
        /// Returns a value indicating if the specified value equals this.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public bool Equals(TNotNullable value)
        {
            return Value.Equals(value);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return EqualityComparer<TNotNullable>.Default.GetHashCode(Value);
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public TNotNullable Value { get; }

        /// <summary>
        /// Implementation of the implicit widening operator to <see cref="NotNull{TNotNullable}"/>
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        public static implicit operator NotNull<TNotNullable>(TNotNullable value)
        {
            return new NotNull<TNotNullable>(value);
        }

        /// <summary>
        /// Implementation of the implicit narrowing operator to <see cref="TNotNullable"/>
        /// </summary>
        /// <param name="value">The value to unwrap.</param>
        public static implicit operator TNotNullable(NotNull<TNotNullable> value)
        {
            return value.Value;
        }

        /// <summary>
        /// Custom implementation of the operator ==.
        /// </summary>
        /// <param name="primary">The primary to check</param>
        /// <param name="secondary">The secondary to check.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(NotNull<TNotNullable> primary, NotNull<TNotNullable> secondary)
        {
            if (ReferenceHelper.BothReferencesAreNull(primary.Value, secondary.Value))
                return true;

            if (ReferenceHelper.OneOrTheOtherReferenceIsNull(primary.Value, secondary.Value))
                return false;

            return primary.Value == secondary.Value;
        }

        /// <summary>
        /// Custom implementation of the operator !=.
        /// </summary>
        /// <param name="primary">The primary to check</param>
        /// <param name="secondary">The secondary to check.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(NotNull<TNotNullable> primary, NotNull<TNotNullable> secondary)
        {
            return !(primary == secondary);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}