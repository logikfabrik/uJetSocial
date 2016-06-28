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
        /// <param name="cache">The cache.</param>
        /// <param name="database">The database.</param>
        public DocumentProvider(
            Func<ICacheWrapper> cache,
            Func<IDatabaseWrapper> database)
            : base(cache, database)
        {
        }

        /// <summary>
        /// Gets the data transfer object with the specified Umbraco identifier.
        /// </summary>
        /// <param name="id">The Umbraco identifier.</param>
        /// <returns>The data transfer object with the specified Umbraco identifier.</returns>
        public Document GetByUmbracoId(int id)
        {
            var query = new Query<Document>(0, int.MaxValue);

            query.Criterias.Add(document => document.DocumentId == id);

            var objects = Query(query).Objects;

            return objects.SingleOrDefault();
        }
    }
}
