// <copyright file="DataTransferObjectValidator.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;

    /// <summary>
    /// The <see cref="DataTransferObjectValidator" /> class.
    /// </summary>
    public static class DataTransferObjectValidator
    {
        /// <summary>
        /// Validates the specified <see cref="DataTransferObject" />. Throws an exception if read-only.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> to validate.</param>
        public static void ThrowIfReadOnly(DataTransferObject dto)
        {
            ThrowIfReadOnly(dto.IsReadOnly);
        }

        /// <summary>
        /// Validates the specified <see cref="DataTransferObject" />. Throws an exception if not read-only.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" />.</param>
        public static void ThrowIfNotReadOnly(DataTransferObject dto)
        {
            ThrowIfNotReadOnly(dto.IsReadOnly);
        }

        /// <summary>
        /// Throws if read-only.
        /// </summary>
        /// <param name="isReadOnly">If read-only set to <c>true</c>; otherwise, <c>false</c>.</param>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="isReadOnly" /> is <c>true</c>.</exception>
        public static void ThrowIfReadOnly(bool isReadOnly)
        {
            if (!isReadOnly)
            {
                return;
            }

            throw new InvalidOperationException("Object must not be read-only.");
        }

        /// <summary>
        /// Throws if not read-only.
        /// </summary>
        /// <param name="isReadOnly">If read-only set to <c>true</c>; otherwise, <c>false</c>.</param>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="isReadOnly" /> is <c>false</c>.</exception>
        public static void ThrowIfNotReadOnly(bool isReadOnly)
        {
            if (isReadOnly)
            {
                return;
            }

            throw new InvalidOperationException("Object must be read-only.");
        }
    }
}
