using System;

namespace Dibware.Salon.Domain.SharedKernel.Guards
{
    /// <summary>
    /// Encapsulates guard clause extensions
    /// </summary>
    public static class GuardExtensions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if instance is null.
        /// </summary>
        /// <param name="instance">The instance which should not be null.</param>
        /// <param name="argumentName">Name of the argument.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the value of instance is null.
        /// </exception>
        public static void ThrowExceptionIfNull(this object instance, ArgumentName argumentName)
        {
            if (instance == null) throw new ArgumentNullException(argumentName);
        }
    }
}