// <copyright file="UmbracoMemberAPIController.cs" company="Logikfabrik">
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
    /// The <see cref="UmbracoMemberAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class UmbracoMemberAPIController : APIController
    {
        private readonly IContentLookup _contentLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoMemberAPIController" /> class.
        /// </summary>
        public UmbracoMemberAPIController()
            : this(new ContentLookup())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoMemberAPIController" /> class.
        /// </summary>
        /// <param name="contentLookup">The content lookup.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="contentLookup" /> is <c>null</c>.</exception>
        public UmbracoMemberAPIController(IContentLookup contentLookup)
        {
            if (contentLookup == null)
            {
                throw new ArgumentNullException(nameof(contentLookup));
            }

            _contentLookup = contentLookup;
        }

        /// <summary>
        /// Queries Umbraco for members.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching Umbraco members.</returns>
        [HttpPost]
        public QueryResult<UmbracoMember> Query(UmbracoQuery query)
        {
            // TODO: Update XPath expression.
            const string xPath = "xPath";

            var documents = _contentLookup.GetMembersByXPath(xPath);

            var items = documents
                .Skip(query.PageIndex * query.PageSize)
                .Take(query.PageSize)
                .Select(member => new UmbracoMember())
                .ToArray();

            return new QueryResult<UmbracoMember>
            {
                Objects = items,
                Total = items.Length
            };
        }
    }
}
