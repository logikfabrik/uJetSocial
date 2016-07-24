// <copyright file="UmbracoMediaAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.XPath;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Web.Mvc;
    using Models;
    using Utilities;

    /// <summary>
    /// The <see cref="UmbracoMediaAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class UmbracoMediaAPIController : UmbracoContentAPIController<UmbracoMedia>
    {
        private readonly IContentLookup _contentLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoMediaAPIController" /> class.
        /// </summary>
        public UmbracoMediaAPIController()
            : this(new ContentLookup())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoMediaAPIController" /> class.
        /// </summary>
        /// <param name="contentLookup">The content lookup.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="contentLookup" /> is <c>null</c>.</exception>
        public UmbracoMediaAPIController(IContentLookup contentLookup)
        {
            if (contentLookup == null)
            {
                throw new ArgumentNullException(nameof(contentLookup));
            }

            _contentLookup = contentLookup;
        }

        /// <summary>
        /// Gets content by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="total">The total.</param>
        /// <returns>The content matching the selection criteria.</returns>
        protected override IEnumerable<IPublishedContent> Lookup(XPathExpression expression, int pageIndex, int pageSize, out int total)
        {
            return _contentLookup.GetMediaByXPath(expression, pageIndex, pageSize, out total);
        }

        /// <summary>
        /// Gets content by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The content matching the selection criteria.</returns>
        protected override IPublishedContent Lookup(XPathExpression expression)
        {
            int total;

            return _contentLookup.GetMediaByXPath(expression, 0, 1, out total).SingleOrDefault();
        }

        /// <summary>
        /// Gets a model for the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>A model for the specified content.</returns>
        protected override UmbracoMedia GetModel(IPublishedContent content)
        {
            var model = base.GetModel(content);

            model.Url = PublishedContentUtilities.GetUrl(content);

            return model;
        }
    }
}
