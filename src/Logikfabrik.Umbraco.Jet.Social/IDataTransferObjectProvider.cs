// <copyright file="IDataTransferObjectProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    /// <summary>
    /// The <see cref="IDataTransferObjectProvider" /> interface.
    /// </summary>
    public interface IDataTransferObjectProvider
    {
        /// <summary>
        /// Updates the specified <see cref="DataTransferObject" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" />.</param>
        void Update(DataTransferObject dto);

        /// <summary>
        /// Gets the <see cref="DataTransferObject" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="DataTransferObject" /> identifier.</param>
        /// <returns>The <see cref="DataTransferObject" />.</returns>
        DataTransferObject Get(int id);

        /// <summary>
        /// Adds the specified <see cref="DataTransferObject" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" />.</param>
        /// <returns>The <see cref="DataTransferObject" /> identifier.</returns>
        int Add(DataTransferObject dto);

        /// <summary>
        /// Removes the <see cref="DataTransferObject" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="DataTransferObject" /> identifier.</param>
        void Remove(int id);
    }
}
