// <copyright file="GroupNameCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a group name criteria.
    /// </summary>
    public class GroupNameCriteria : Criteria, IGroupCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupNameCriteria" /> class.
        /// </summary>
        public GroupNameCriteria()
            : base("uJetCommunityGroup.Name")
        {
        }
    }
}
