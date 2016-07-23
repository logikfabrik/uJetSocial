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
            // TODO: Known issue; will only query published content.
            var builder = new ContentLookupExpressionBuilder();

            var expression = builder.SortByAttribute(builder.SelectByInexactAttribute("nodeName", query.Name), "nodeName", XmlDataType.Text);

            int total;

            var content = Lookup(expression, query.PageIndex, query.PageSize, out total).Select(GetModel);

            return new QueryResult<T>
            {
                Objects = content,
                Total = total
            };
        }

        /// <summary>
        /// Gets the Umbraco content object with the specified identifier.
        /// </summary>
        /// <param name="id">The Umbraco content object identifier.</param>
        /// <returns>The Umbraco content object with the specified identifier.</returns>
        [HttpGet]
        public T Get(int id)
        {
            // TODO: Known issue; will only query published content.
            var builder = new ContentLookupExpressionBuilder();

            var expression = builder.SelectByExactAttribute("id", id.ToString());

            var content = Lookup(expression);

            return content == null ? null : GetModel(content);
        }

        /// <summary>
        /// Gets content by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="total">The total.</param>
        /// <returns>The content matching the selection criteria.</returns>
        protected abstract IEnumerable<IPublishedContent> Lookup(XPathExpression expression, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// Gets content by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The content matching the selection criteria.</returns>
        protected abstract IPublishedContent Lookup(XPathExpression expression);

        /// <summary>
        /// Gets a model for the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>A model for the specified content.</returns>
        protected virtual T GetModel(IPublishedContent content)
        {
            return new T
            {
                Id = content.Id,
                Name = content.Name
            };
        }
    }
}
