// <copyright file="DocumentProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="DocumentProvider" /> class.
    /// </summary>
    public class DocumentProvider : DataTransferObjectProvider<Document>, IDocumentProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public DocumentProvider(Func<IDatabaseWrapper> database)
            : base(database)
        {
        }

        /// <summary>
        /// Gets the data transfer object with the specified document identifier.
        /// </summary>
        /// <param name="id">The document identifier.</param>
        /// <returns>The data transfer object with the specified document identifier.</returns>
        public Document GetByDocumentId(int id)
        {
            var query = new Query<Document>(0, int.MaxValue);

            query.Criterias.Add(document => document.DocumentId == id);

            var documents = Query(query).Objects;

            return documents.SingleOrDefault();
        }
    }
}
