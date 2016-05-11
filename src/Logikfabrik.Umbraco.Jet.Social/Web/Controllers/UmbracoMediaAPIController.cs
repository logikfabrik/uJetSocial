// <copyright file="UmbracoMediaAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Xml.XPath;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Web.Mvc;
    using Models;

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
        /// <returns>The content matching the selection criteria.</returns>
        protected override IEnumerable<IPublishedContent> Lookup(XPathExpression expression)
        {
            return _contentLookup.GetMediaByXPath(expression);
        }
    }
}
