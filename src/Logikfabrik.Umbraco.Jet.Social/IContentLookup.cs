// <copyright file="IContentLookup.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System.Collections.Generic;
    using System.Xml.XPath;
    using global::Umbraco.Core.Models;

    /// <summary>
    /// The <see cref="IContentLookup" /> interface.
    /// </summary>
    public interface IContentLookup
    {
        /// <summary>
        /// Gets documents by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The documents matching the selection criteria.</returns>
        IEnumerable<IPublishedContent> GetDocumentsByXPath(XPathExpression expression);

        /// <summary>
        /// Gets media by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The media matching the selection criteria.</returns>
        IEnumerable<IPublishedContent> GetMediaByXPath(XPathExpression expression);

        /// <summary>
        /// Gets members by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The members matching the selection criteria.</returns>
        IEnumerable<IPublishedContent> GetMembersByXPath(XPathExpression expression);
    }
}
