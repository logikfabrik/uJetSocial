// <copyright file="GroupMembershipProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using System.Linq;

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

        /// <summary>
        /// Adds the specified data transfer object of type <see cref="GroupMembership" />.
        /// </summary>
        /// <param name="dto">The data transfer object of type <see cref="GroupMembership" /> to add.</param>
        /// <returns>
        /// The added data transfer object of type <see cref="GroupMembership" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public override GroupMembership Add(GroupMembership dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var query = new Query<GroupMembership>(0, int.MaxValue);

            query.Criterias.Add(membership => membership.GroupId == dto.GroupId);
            query.Criterias.Add(membership => membership.MemberId == dto.MemberId);

            var objects = Query(query).Objects;

            if (objects.Any())
            {
                throw new InvalidOperationException();
            }

            return base.Add(dto);
        }
    }
}
