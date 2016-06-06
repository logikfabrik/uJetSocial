// <copyright file="DocumentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using Document;
    using global::Umbraco.Web.Mvc;
    using Models.Querying;

    /// <summary>
    /// The <see cref="DocumentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class DocumentAPIController : DataTransferObjectAPIController<Document>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="Document" />.</returns>
        [HttpPost]
        public QueryResult<Document> Query(DocumentQuery query)
        {
            var q = GetQuery(query);

            if (query.DocumentId.HasValue)
            {
                q.Criterias.Add(obj => obj.DocumentId == query.DocumentId.Value);
            }

            var result = Provider.Query(q);

            return new QueryResult<Document>
            {
                Total = result.Total,
                Objects = result.Objects
            };
        }

        /// <summary>
        /// Gets the document with the specified Umbraco identifier, or create one if one does not exist.
        /// </summary>
        /// <param name="id">The Umbraco document identifier.</param>
        /// <returns>The document.</returns>
        [HttpGet]
        public Document GetByDocumentId(int id)
        {
            var provider = (IDocumentProvider)Provider;

            var document = provider.GetByUmbracoId(id);

            return document ?? provider.Add(new Document { DocumentId = id });
        }
    }
}
