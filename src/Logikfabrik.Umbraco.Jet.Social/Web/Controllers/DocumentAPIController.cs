// <copyright file="DocumentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Document;
    using global::Umbraco.Web.Mvc;
    using Jet.Web.Data;
    using Models;
    using Models.Querying;
    using Utilities;

    /// <summary>
    /// The <see cref="DocumentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class DocumentAPIController : DataTransferObjectAPIController<Document>
    {
        private readonly IUmbracoHelperWrapper _umbracoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAPIController" /> class.
        /// </summary>
        public DocumentAPIController()
            : this(new UmbracoHelperWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentAPIController" /> class.
        /// </summary>
        /// <param name="umbracoHelper">The Umbraco helper.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="umbracoHelper" /> is <c>null</c>.</exception>
        public DocumentAPIController(IUmbracoHelperWrapper umbracoHelper)
        {
            if (umbracoHelper == null)
            {
                throw new ArgumentNullException(nameof(umbracoHelper));
            }

            _umbracoHelper = umbracoHelper;
        }

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
                Objects = result.Objects.Select(GetModel)
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

            return GetModel(document ?? provider.Add(new Document { DocumentId = id }));
        }

        /// <summary>
        /// Gets a model for the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object.</param>
        /// <returns>A model for the specified data transfer object.</returns>
        protected override Document GetModel(Document dto)
        {
            var model = base.GetModel(dto);

            if (model == null)
            {
                return null;
            }

            var content = _umbracoHelper.TypedDocument(model.DocumentId);

            var meta = new MetaDocument
            {
                Id = model.Id,
                Created = model.Created,
                Updated = model.Updated,
                Status = model.Status,
                DocumentId = model.DocumentId,
                Name = content.Name,
                Url = PublishedContentUtilities.GetUrl(content)
            };

            return meta;
        }
    }
}
