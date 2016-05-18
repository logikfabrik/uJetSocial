// <copyright file="IDocumentProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    /// <summary>
    /// The <see cref="IDocumentProvider" /> interface.
    /// </summary>
    public interface IDocumentProvider : IDataTransferObjectProvider<Document>
    {
        /// <summary>
        /// Gets the data transfer object with the specified document identifier.
        /// </summary>
        /// <param name="id">The document identifier.</param>
        /// <returns>The data transfer object with the specified document identifier.</returns>
        Document GetByDocumentId(int id);
    }
}
