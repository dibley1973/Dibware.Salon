using System;
using System.Collections.Generic;
using System.Text;
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

        public static implicit operator NotNull<TNotNullable>(TNotNullable val)
        {
            return new NotNull<TNotNullable>(val);
        }

        public static implicit operator TNotNullable(NotNull<TNotNullable> val)
        {
            return val.Value;
        }

        public static bool operator ==(NotNull<TNotNullable> primary, NotNull<TNotNullable> secondary)
        {
            if (ReferenceHelper.BothReferencesAreNull(primary.Value, secondary.Value))
                return true;

            if (ReferenceHelper.OneOrTheOtherReferenceIsNull(primary.Value, secondary.Value))
                return false;

            return primary.Value == secondary.Value;
        }

        public static bool operator !=(NotNull<TNotNullable> a, NotNull<TNotNullable> b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            TNotNullable value = obj as TNotNullable;

            if (value == null) return false;

            return Equals(value);
        }

        public bool Equals(TNotNullable value)
        {
            return Value.Equals(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}