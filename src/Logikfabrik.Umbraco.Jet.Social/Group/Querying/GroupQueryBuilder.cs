// <copyright file="GroupQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// Represents a group query builder.
    /// </summary>
    public class GroupQueryBuilder : EntityQueryBuilder<IGroupCriteria, IGroupSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupQueryBuilder" /> class.
        /// </summary>
        public GroupQueryBuilder()
            : base(GetColumns(), "uJetCommunityGroup")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetCommunityGroup.OwnerId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CG ON CG.TypeId = CET.Id WHERE CG.Id = uJetCommunityGroup.OwnerId) AS OwnerType",
                "uJetCommunityGroup.Name",
                "uJetCommunityGroup.Description"
            };
        }
    }
}
