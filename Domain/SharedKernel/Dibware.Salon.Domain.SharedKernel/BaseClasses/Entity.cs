// <copyright file="Entity.cs" company="Dibware">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>

using Dibware.Salon.Domain.SharedKernel.Helpers;

namespace Dibware.Salon.Domain.SharedKernel.BaseClasses
{
    /// <summary>The shared base class which all entities should inherit from</summary>
    public abstract class Entity
    {
        /// <summary>Gets or sets the entity identifier.</summary>
        /// <value>The identifier.</value>
        public long Id { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether this instance is persistent. TrPersistentansient
        /// indicates this instance can be persisted to a data store. This state is the opposite of
        /// <see cref="IsTransient"/>
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is persistent; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsPersistent => !IsTransient;

        /// <summary>
        /// Gets a value indicating whether this instance is transient.ransient indicates this
        /// instance cannot be persisted to a data store. This state is the opposite of <see cref="IsPersistent"/>
        /// </summary>
        /// <value><c>true</c> if this instance is transient; otherwise, <c>false</c>.</value>
        public virtual bool IsTransient => Id.Equals(default(long));

        /// <summary>Gets a value representing this instance cast as an <see cref="object"/>.</summary>
        /// <value>The cast instance.</value>
        protected object Actual => this;

#pragma warning disable S3875
        /// <summary>Implementation of the the == comparison operator for the <see cref="Entity"/>.</summary>
        /// <remarks>
        /// Disable S3975 ("operator==" should not be overloaded on reference types) warning
        /// from SonarQube as for this class equality os to based entirely upon ID an not 
        /// reference equality.
        /// </remarks>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator ==(Entity primary, Entity secondary)
        {
            if (ReferenceHelper.BothReferencesAreNull(primary, secondary))
                return true;

            if (ReferenceHelper.OneOrTheOtherReferenceIsNull(primary, secondary))
                return false;

            // ReSharper disable once PossibleNullReferenceException
            // Because primary has already been checked for null
            return primary.Equals(secondary);
        }
#pragma warning restore S3875

        /// <summary>Implementation of the the != comparison operator for the <see cref="Entity"/>.</summary>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator !=(Entity primary, Entity secondary)
        {
            return !(primary == secondary);
        }

        /// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (other is null)
                return false;

            if (BothReferencesMatch(other))
                return true;

            if (EntityTypesDiffer(other))
                return false;

            if (BothIdsAreZero(other))
                return false;

            return BothIdsMatch(other);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }

        /// <summary>Gets a value indicating if both of the entity Ids match.</summary>
        /// <param name="other">The other <see cref="Entity"/>.</param>
        /// <returns>Returns <c>true</c> if both entity Ids match; otherwise <c>false</c>.</returns>
        private bool BothIdsMatch(Entity other)
        {
            return Id == other.Id;
        }

        /// <summary>
        /// <para>
        ///  Returns primary value indicating if either of the identifier are zero.
        /// </para>
        /// </summary>
        /// <param name="other">The other <see cref="Entity"/> to compare to this.</param>
        /// <returns>Returns <c>true</c>"/> if the Ids of both <see cref="Entity"/> objects match, otherwise <c>false</c>.</returns>
        private bool BothIdsAreZero(Entity other)
        {
            return Id == 0 || other.Id == 0;
        }

        /// <summary>Gets a value indicating if both of the <see cref="Entity"/> references match.</summary>
        /// <param name="other">The other.</param>
        /// <returns>Returns <c>true</c> if both of the <see cref="Entity"/> references match; otherwise <c>false</c>.</returns>
        private bool BothReferencesMatch(Entity other)
        {
            return ReferenceEquals(this, other);
        }

        /// <summary>Returns a value indicating if the types of both entities differ.</summary>
        /// <param name="other">The other.</param>
        /// <returns>Returns <c>true</c> if both types differ; otherwise <c>false</c>.</returns>
        private bool EntityTypesDiffer(Entity other)
        {
            return Actual.GetType() != other.Actual.GetType();
        }
    }
}