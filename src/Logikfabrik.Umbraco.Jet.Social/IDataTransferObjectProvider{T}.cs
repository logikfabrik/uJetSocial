// <copyright file="IDataTransferObjectProvider{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IDataTransferObjectProvider{T}" /> interface.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    public interface IDataTransferObjectProvider<T> : IDataTransferObjectProvider
        where T : DataTransferObject
    {
        /// <summary>
        /// Updates the specified data transfer object of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The data transfer object of type <typeparamref name="T" /> to update.</param>
        /// <returns>The updated data transfer object of type <typeparamref name="T" />.</returns>
        T Update(T dto);

        /// <summary>
        /// Gets the data transfer object of type <typeparamref name="T" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        /// <returns>The data transfer object of type <typeparamref name="T" /> with the specified identifier.</returns>
        new T Get(int id);

        /// <summary>
        /// Adds the specified data transfer object of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The data transfer object of type <typeparamref name="T" /> to add.</param>
        /// <returns>The added data transfer object of type <typeparamref name="T" />.</returns>
        T Add(T dto);

        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <typeparamref name="T" />.</returns>
        IEnumerable<T> Query(Query<T> query);
    }
}
