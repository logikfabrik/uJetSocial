// <copyright file="GroupAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Models;

    /// <summary>
    /// The <see cref="GroupAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class GroupAPIController : DataTransferObjectAPIController<Group.Group>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="Group.Group" />.</returns>
        [HttpPost]
        public QueryResult<Group.Group> Query(GroupQuery query)
        {
            var q = GetQuery(query);

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                q.Criterias.Add(obj => obj.Name.StartsWith(query.Name, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(query.Description))
            {
                q.Criterias.Add(obj => obj.Description.StartsWith(query.Description, StringComparison.InvariantCultureIgnoreCase));
            }

            var result = Provider.Query(q);

            return new QueryResult<Group.Group>
            {
                Total = result.Total,
                Objects = result.Objects
            };
        }
    }
}
