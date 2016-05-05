// <copyright file="CommentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Models.Querying;

    /// <summary>
    /// The <see cref="CommentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class CommentAPIController : DataTransferObjectAPIController<Comment.Comment>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="Comment.Comment" />.</returns>
        [HttpPost]
        public QueryResult<Comment.Comment> Query(CommentQuery query)
        {
            var q = GetQuery(query);

            if (!string.IsNullOrWhiteSpace(query.Text))
            {
                q.Criterias.Add(obj => obj.Text.StartsWith(query.Text, StringComparison.InvariantCultureIgnoreCase));
            }

            var result = Provider.Query(q);

            return new QueryResult<Comment.Comment>
            {
                Total = result.Total,
                Objects = result.Objects
            };
        }
    }
}
