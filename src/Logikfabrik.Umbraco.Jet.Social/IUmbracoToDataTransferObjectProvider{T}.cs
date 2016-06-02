// <copyright file="IUmbracoToDataTransferObjectProvider{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    /// <summary>
    /// The <see cref="IUmbracoToDataTransferObjectProvider{T}" /> interface.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    public interface IUmbracoToDataTransferObjectProvider<T> : IDataTransferObjectProvider<T>
        where T : DataTransferObject
    {
        /// <summary>
        /// Gets the data transfer object with the specified Umbraco identifier.
        /// </summary>
        /// <param name="id">The Umbraco identifier.</param>
        /// <returns>The data transfer object with the specified Umbraco identifier.</returns>
        T GetByUmbracoId(int id);
    }
}
