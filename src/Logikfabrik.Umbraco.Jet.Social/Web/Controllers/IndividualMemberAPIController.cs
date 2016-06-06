// <copyright file="IndividualMemberAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Individual;
    using Models.Querying;

    /// <summary>
    /// The <see cref="IndividualMemberAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class IndividualMemberAPIController : DataTransferObjectAPIController<IndividualMember>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="IndividualMemberQuery" />.</returns>
        [HttpPost]
        public QueryResult<IndividualMember> Query(IndividualMemberQuery query)
        {
            var q = GetQuery(query);

            if (query.MemberId.HasValue)
            {
                q.Criterias.Add(obj => obj.MemberId == query.MemberId.Value);
            }

            var result = Provider.Query(q);

            return new QueryResult<IndividualMember>
            {
                Total = result.Total,
                Objects = result.Objects
            };
        }

        /// <summary>
        /// Gets the member with the specified Umbraco identifier, or create one if one does not exist.
        /// </summary>
        /// <param name="id">The Umbraco member identifier.</param>
        /// <returns>The member.</returns>
        [HttpGet]
        public IndividualMember GetByMemberId(int id)
        {
            var provider = (IIndividualMemberProvider)Provider;

            var member = provider.GetByUmbracoId(id);

            return member ?? provider.Add(new IndividualMember { MemberId = id });
        }
    }
}
