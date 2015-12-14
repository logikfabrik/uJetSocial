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
        /// Updates the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object to update.</param>
        /// <returns>The updated data transfer object object.</returns>
        DataTransferObject Update(DataTransferObject dto);

        /// <summary>
        /// Gets the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        /// <returns>The data transfer object with the specified identifier.</returns>
        DataTransferObject Get(int id);

        /// <summary>
        /// Adds the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object to add.</param>
        /// <returns>The added data transfer object.</returns>
        DataTransferObject Add(DataTransferObject dto);

        /// <summary>
        /// Removes the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        void Remove(int id);
    }
}
