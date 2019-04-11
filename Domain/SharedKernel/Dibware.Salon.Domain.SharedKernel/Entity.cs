﻿using System;

namespace Dibware.Salon.Domain.SharedKernel
{
    /// <summary>The shared base class which all entities should inherit from</summary>
    public abstract class Entity
    {
        /// <summary>Gets or sets the entity identifier.</summary>
        /// <value>The identifier.</value>
        public virtual long Id { get; protected set; }

        /// <summary>Returns this instance cast as an <see cref="object"/>.</summary>
        /// <value>The cast instance.</value>
        protected virtual object Actual => this;

        /// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
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

        /// <summary>Implementation of the the == comparison operator for the <see cref="Entity"/>.</summary>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator ==(Entity primary, Entity secondary)
        {
            if (BothEntitiesAreNull(primary, secondary))
                return true;

            if (OneOrTheOtherIsNull(primary, secondary))
                return false;

            // ReSharper disable once PossibleNullReferenceException
            // Because primary has already been checked for null
            return primary.Equals(secondary);
        }

        /// <summary>Implementation of the the != comparison operator for the <see cref="Entity"/>.</summary>
        /// <param name="primary">The primary <see cref="Entity"/> to check.</param>
        /// <param name="secondary">The secondary <see cref="Entity"/> to check.</param>
        /// <returns>The result of the comparison operator.</returns>
        public static bool operator !=(Entity primary, Entity secondary)
        {
            return !(primary == secondary);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }

        /// <summary>Gets a value indicating if both of the entities are null.</summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>Returns <c>true</c> if both entities are null; otherwise <c>false</c>.</returns>
        private static bool BothEntitiesAreNull(Entity primary, Entity secondary)
        {
            return primary is null && secondary is null;
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

        /// <summary>Returns primary value indicating if either the primary or secondary is null.</summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>Returns <c>true</c> if the primary of the secondary is null; otherwise <c>false</c>.</returns>
        private static bool OneOrTheOtherIsNull(Entity primary, Entity secondary)
        {
            return primary is null || secondary is null;
        }
    }
}