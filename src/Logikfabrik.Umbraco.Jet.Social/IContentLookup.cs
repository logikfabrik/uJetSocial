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
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="total">The total.</param>
        /// <returns>The documents matching the selection criteria.</returns>
        IEnumerable<IPublishedContent> GetDocumentsByXPath(XPathExpression expression, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// Gets media by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="total">The total.</param>
        /// <returns>The media matching the selection criteria.</returns>
        IEnumerable<IPublishedContent> GetMediaByXPath(XPathExpression expression, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// Gets members by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="total">The total.</param>
        /// <returns>The members matching the selection criteria.</returns>
        IEnumerable<IPublishedContent> GetMembersByXPath(XPathExpression expression, int pageIndex, int pageSize, out int total);
    }
}
