namespace Dibware.Salon.Domain.SharedKernel
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
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

        protected abstract bool EqualsCore(T other);

        protected abstract int GetHashCodeCore();

        /// <summary>Implementation of the the != comparison operator for the <see cref="Entity"/>.</summary>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator !=(ValueObject<T> primary, ValueObject<T> secondary)
        {
            return !(primary == secondary);
        }
    }
}