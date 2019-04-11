namespace Dibware.Salon.Domain.SharedKernel.Helpers
{
    /// <summary>Helps with referenced based checks and operations</summary>
    internal static class ReferenceHelper
    {
        /// <summary>Gets a value indicating if both of the <see cref="object"/> are null.</summary>
        /// <param name="primary">The primary object.</param>
        /// <param name="secondary">The secondary object.</param>
        /// <returns>Returns <c>true</c> if both objects are null; otherwise <c>false</c>.</returns>
        public static bool BothReferencesAreNull(object primary, object secondary)
        {
            return ReferenceEquals(primary, null) && ReferenceEquals(secondary, null);
        }

        /// <summary>Returns primary value indicating if either the primary or secondary <see cref="object"/> is null.</summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>Returns <c>true</c> if the primary of the secondary is null; otherwise <c>false</c>.</returns>
        public static bool OneOrTheOtherReferenceIsNull(object primary, object secondary)
        {
            return ReferenceEquals(primary, null) || ReferenceEquals(secondary, null);
        }
    }
}