// <copyright file="GroupOwnerIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GroupOwnerIdCriteria" /> class.
    /// </summary>
    public class GroupOwnerIdCriteria : Criteria, IGroupCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupOwnerIdCriteria" /> class.
        /// </summary>
        public GroupOwnerIdCriteria()
            : base("uJetCommunityGroup.OwnerId")
        {
        }
    }
}
