// <copyright file="ICloneable{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    /// <summary>
    /// The <see cref="ICloneable{T}" /> interface.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    public interface ICloneable<out T>
        where T : DataTransferObject
    {
        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        T CreateWritableClone();
    }
}
