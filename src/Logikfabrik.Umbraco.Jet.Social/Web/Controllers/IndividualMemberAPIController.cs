// <copyright file="IndividualMemberAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using global::Umbraco.Web.PublishedCache;
    using Individual;
    using Jet.Web.Data;
    using Models;
    using Models.Querying;

    /// <summary>
    /// The <see cref="IndividualMemberAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class IndividualMemberAPIController : DataTransferObjectAPIController<IndividualMember>
    {
        private readonly IUmbracoHelperWrapper _umbracoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualMemberAPIController" /> class.
        /// </summary>
        public IndividualMemberAPIController()
            : this(new UmbracoHelperWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualMemberAPIController" /> class.
        /// </summary>
        /// <param name="umbracoHelper">The Umbraco helper.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="umbracoHelper" /> is <c>null</c>.</exception>
        public IndividualMemberAPIController(IUmbracoHelperWrapper umbracoHelper)
        {
            if (umbracoHelper == null)
            {
                throw new ArgumentNullException(nameof(umbracoHelper));
            }

            _umbracoHelper = umbracoHelper;
        }

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
                Objects = result.Objects.Select(GetModel)
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

            return GetModel(member ?? provider.Add(new IndividualMember { MemberId = id }));
        }

        /// <summary>
        /// Gets a model for the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object.</param>
        /// <returns>A model for the specified data transfer object.</returns>
        protected override IndividualMember GetModel(IndividualMember dto)
        {
            var model = base.GetModel(dto);

            if (model == null)
            {
                return null;
            }

            var content = (MemberPublishedContent)_umbracoHelper.TypedMember(model.MemberId);

            var meta = new MetaMember
            {
                Id = model.Id,
                Created = model.Created,
                Updated = model.Updated,
                Status = model.Status,
                MemberId = model.MemberId,
                Name = content.Name,
                Email = content.Email
            };

            return meta;
        }
    }
}
