// <copyright file="UmbracoDocumentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Models;
    using Models.Querying;

    /// <summary>
    /// The <see cref="UmbracoDocumentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class UmbracoDocumentAPIController : APIController
    {
        private readonly IContentLookup _contentLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoDocumentAPIController" /> class.
        /// </summary>
        public UmbracoDocumentAPIController()
            : this(new ContentLookup())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoDocumentAPIController" /> class.
        /// </summary>
        /// <param name="contentLookup">The content lookup.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="contentLookup" /> is <c>null</c>.</exception>
        public UmbracoDocumentAPIController(IContentLookup contentLookup)
        {
            if (contentLookup == null)
            {
                throw new ArgumentNullException(nameof(contentLookup));
            }

            _contentLookup = contentLookup;
        }

        /// <summary>
        /// Queries Umbraco for documents.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching Umbraco documents.</returns>
        [HttpPost]
        public QueryResult<UmbracoDocument> Query(UmbracoQuery query)
        {
            // TODO: Update XPath expression.
            // TODO: Figure out how to order, before skipping and taking.
            var xPath = $"*[@nodeName=\"{query.Name}\"]";

            var documents = _contentLookup.GetDocumentsByXPath(xPath).ToArray();

            var items = documents
                .Skip(query.PageIndex * query.PageSize)
                .Take(query.PageSize)
                .Select(document => new UmbracoDocument())
                .ToArray();

            return new QueryResult<UmbracoDocument>
            {
                Objects = items,
                Total = items.Length
            };
        }
    }
}
