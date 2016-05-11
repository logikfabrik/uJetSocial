// <copyright file="UmbracoContentAPIController{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Xml.XPath;
    using global::Umbraco.Core.Models;
    using Models;
    using Models.Querying;

    /// <summary>
    /// The <see cref="UmbracoContentAPIController{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The Umbraco content type.</typeparam>
    // ReSharper disable once InconsistentNaming
    public abstract class UmbracoContentAPIController<T> : APIController
        where T : UmbracoContent, new()
    {
        /// <summary>
        /// Queries Umbraco for content.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching Umbraco content.</returns>
        [HttpPost]
        public QueryResult<T> Query(UmbracoQuery query)
        {
            var builder = new ContentLookupExpressionBuilder();

            var expression = builder.SortByAttribute(builder.SelectByAttribute("nodeName", query.Name), "nodeName", XmlDataType.Text);

            var content = Lookup(expression);

            var items = content
                .Skip(query.PageIndex * query.PageSize)
                .Take(query.PageSize)
                .Select(GetModel)
                .ToArray();

            return new QueryResult<T>
            {
                Objects = items,
                Total = items.Length
            };
        }

        /// <summary>
        /// Gets content by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The content matching the selection criteria.</returns>
        protected abstract IEnumerable<IPublishedContent> Lookup(XPathExpression expression);

        private static T GetModel(IPublishedContent content)
        {
            return new T
            {
                Id = content.Id,
                Name = content.Name
            };
        }
    }
}
