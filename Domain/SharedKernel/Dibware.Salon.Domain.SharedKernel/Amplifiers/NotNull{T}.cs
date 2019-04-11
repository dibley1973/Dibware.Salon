using System;
using System.Collections.Generic;
using System.Text;
using Dibware.Salon.Domain.SharedKernel.Helpers;

namespace Dibware.Salon.Domain.SharedKernel.Amplifiers
{
    /// <summary>
    /// Non-nullable wrapper.
    /// </summary>
    /// <typeparam name="T">The type of the object which must be not null</typeparam>
    public struct NotNull<T>
    {
        public NotNull(T val)
        {
            if (((object) val) != null)
                Value = val;
            else
                throw new ArgumentNullException("Required value cannot be null");
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public T Value { get; }

        public static implicit operator NotNull<T>(T val)
        {
            return new NotNull<T>(val);
        }

        public static implicit operator T(NotNull<T> val)
        {
            return val.Value;
        }

        public static bool operator ==(NotNull<T> primary, NotNull<T> secondary)
        {
            if (ReferenceHelper.BothReferencesAreNull(primary.Value, secondary.Value))
                return true;

            if (ReferenceHelper.OneOrTheOtherReferenceIsNull(primary.Value, secondary.Value))
                return false;

            return primary.Value.Equals(secondary.Value);
        }

        public static bool operator !=(NotNull<T> a, NotNull<T> b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            try
            {
                T val = (T) obj;
                return Value.Equals(val);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Equals(T obj)
        {
            // Return true if the fields match:
            return Value.Equals(obj);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}