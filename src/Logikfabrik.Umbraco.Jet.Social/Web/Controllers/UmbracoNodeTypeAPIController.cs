// <copyright file="UmbracoNodeTypeAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Xml.XPath;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Web.Mvc;
    using Models;

    /// <summary>
    /// The <see cref="UmbracoNodeTypeAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class UmbracoNodeTypeAPIController : APIController
    {
        private readonly IContentLookup _contentLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoNodeTypeAPIController" /> class.
        /// </summary>
        public UmbracoNodeTypeAPIController()
            : this(new ContentLookup())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoNodeTypeAPIController" /> class.
        /// </summary>
        /// <param name="contentLookup">The content lookup.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="contentLookup" /> is <c>null</c>.</exception>
        public UmbracoNodeTypeAPIController(IContentLookup contentLookup)
        {
            if (contentLookup == null)
            {
                throw new ArgumentNullException(nameof(contentLookup));
            }

            _contentLookup = contentLookup;
        }

        private delegate IEnumerable<IPublishedContent> Lookup(XPathExpression expression, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// Gets the type of the Umbraco node with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The type of the Umbraco node with the specified identifier.</returns>
        [HttpGet]
        public object GetType(int id)
        {
            var builder = new ContentLookupExpressionBuilder();

            var expression = builder.SelectByInexactAttribute("id", id.ToString());

            Func<Lookup, bool> isOfType = lookup =>
            {
                int total;

                var content = lookup(expression, 0, 1, out total);

                return content.SingleOrDefault() != null;
            };

            Type type = null;

            if (isOfType(_contentLookup.GetDocumentsByXPath))
            {
                type = typeof(UmbracoDocument);
            }
            else if (isOfType(_contentLookup.GetMediaByXPath))
            {
                type = typeof(UmbracoMedia);
            }
            else if (isOfType(_contentLookup.GetMembersByXPath))
            {
                type = typeof(UmbracoMember);
            }

            if (type != null)
            {
                return new
                {
                    type.Name,
                    type.FullName
                };
            }

            return null;
        }
    }
}
