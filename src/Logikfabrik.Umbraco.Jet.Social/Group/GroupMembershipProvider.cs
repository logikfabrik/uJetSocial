// <copyright file="GroupMembershipProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;

    /// <summary>
    /// The <see cref="GroupMembershipProvider" /> class.
    /// </summary>
    public class GroupMembershipProvider : DataTransferObjectProvider<GroupMembership>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembershipProvider" /> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="database">The database.</param>
        public GroupMembershipProvider(
            Func<ICacheWrapper> cache,
            Func<IDatabaseWrapper> database)
            : base(cache, database)
        {
        }
    }
}
