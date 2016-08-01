// <copyright file="GroupMembershipAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Group;
    using Jet.Web.Data;
    using Models;
    using Models.Querying;

    /// <summary>
    /// The <see cref="GroupMembershipAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class GroupMembershipAPIController : DataTransferObjectAPIController<GroupMembership>
    {
        private readonly IUmbracoHelperWrapper _umbracoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembershipAPIController" /> class.
        /// </summary>
        public GroupMembershipAPIController()
            : this(new UmbracoHelperWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembershipAPIController" /> class.
        /// </summary>
        /// <param name="umbracoHelper">The Umbraco helper.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="umbracoHelper" /> is <c>null</c>.</exception>
        public GroupMembershipAPIController(IUmbracoHelperWrapper umbracoHelper)
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

        /// <summary>
        /// Removes the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        [HttpPost]
        public void Remove([FromBody]int id)
        {
            Provider.Remove(id);
        }

        /// <summary>
        /// Gets a model for the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object.</param>
        /// <returns>A model for the specified data transfer object.</returns>
        protected override GroupMembership GetModel(GroupMembership dto)
        {
            var model = base.GetModel(dto);

            if (model == null)
            {
                return null;
            }

            var content = (MetaMember)new IndividualMemberAPIController(_umbracoHelper).Get(model.MemberId);

            var meta = new MetaGroupMembership
            {
                Id = model.Id,
                Created = model.Created,
                Updated = model.Updated,
                Status = model.Status,
                GroupId = model.GroupId,
                MemberId = model.MemberId,
                Name = content.Name,
                Email = content.Email
            };

            return meta;
        }
    }
}
