﻿// <copyright file="GroupQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// The <see cref="GroupQueryBuilder" /> class.
    /// </summary>
    public class GroupQueryBuilder : EntityQueryBuilder<IGroupCriteria, IGroupSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupQueryBuilder" /> class.
        /// </summary>
        public GroupQueryBuilder()
            : base(GetColumns(), "uJetSocialGroup")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetSocialGroup.OwnerId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CG ON CG.TypeId = CET.Id WHERE CG.Id = uJetSocialGroup.OwnerId) AS OwnerType",
                "uJetSocialGroup.Name",
                "uJetSocialGroup.Description"
            };
        }
    }
}