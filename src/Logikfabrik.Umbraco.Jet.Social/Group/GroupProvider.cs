// <copyright file="GroupProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;

    /// <summary>
    /// The <see cref="GroupProvider" /> class.
    /// </summary>
    public class GroupProvider : DataTransferObjectProvider<Group>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupProvider" /> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="database">The database.</param>
        public GroupProvider(
            Func<ICacheWrapper> cache,
            Func<IDatabaseWrapper> database)
            : base(cache, database)
        {
        }

        /// <summary>
        /// Gets the group with the specified identifier.
        /// </summary>
        /// <param name="id">The group identifier.</param>
        /// <returns>The group with the specified identifier.</returns>
        public override Group Get(int id)
        {
            var group = base.Get(id);

            if (group == null)
            {
                return null;
            }

            group.IsReadOnly = false;

            group.OwnerType = GetEntityType(group.OwnerId);

            group.IsReadOnly = true;

            return group;
        }
    }
}
