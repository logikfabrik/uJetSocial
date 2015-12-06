// <copyright file="IDataTransferObjectProvider{T}.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="IDataTransferObjectProvider{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="DataTransferObject" /> type.</typeparam>
    public interface IDataTransferObjectProvider<T> : IDataTransferObjectProvider
        where T : DataTransferObject
    {
        /// <summary>
        /// Updates the specified <see cref="DataTransferObject" /> of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> of type <typeparamref name="T"/>.</param>
        void Update(T dto);

        /// <summary>
        /// Gets the <see cref="DataTransferObject" /> of type <typeparamref name="T"/> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="DataTransferObject" /> of type <typeparamref name="T"/> identifier.</param>
        /// <returns>The <see cref="DataTransferObject" /> of type <typeparamref name="T"/>.</returns>
        new T Get(int id);

        /// <summary>
        /// Adds the specified <see cref="DataTransferObject" /> of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> of type <typeparamref name="T"/>.</param>
        /// <returns>The <see cref="DataTransferObject" /> of type <typeparamref name="T"/> identifier.</returns>
        int Add(T dto);

        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching <see cref="DataTransferObject" /> instances of type <typeparamref name="T"/>.</returns>
        IEnumerable<T> Query(Query<T> query);
    }
}
