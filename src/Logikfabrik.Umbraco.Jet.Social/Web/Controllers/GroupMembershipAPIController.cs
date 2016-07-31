// <copyright file="GroupMembershipAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Group;
    using Models.Querying;

    /// <summary>
    /// The <see cref="GroupMembershipAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class GroupMembershipAPIController : DataTransferObjectAPIController<GroupMembership>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="GroupMembership" />.</returns>
        [HttpPost]
        public QueryResult<GroupMembership> Query(GroupMembershipQuery query)
        {
            var q = GetQuery(query);

            if (query.GroupId.HasValue)
            {
                q.Criterias.Add(obj => obj.GroupId == query.GroupId.Value);
            }

            if (query.MemberId.HasValue)
            {
                q.Criterias.Add(obj => obj.MemberId == query.MemberId.Value);
            }

            var result = Provider.Query(q);

            return new QueryResult<GroupMembership>
            {
                Total = result.Total,
                Objects = result.Objects.Select(GetModel)
            };
        }
    }
}
