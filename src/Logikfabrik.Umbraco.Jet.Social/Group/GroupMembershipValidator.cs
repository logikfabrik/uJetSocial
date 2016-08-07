// <copyright file="GroupMembershipValidator.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="GroupMembershipValidator" /> class.
    /// </summary>
    public static class GroupMembershipValidator
    {
        /// <summary>
        /// Validates the specified <see cref="GroupMembership" />. Throws an exception if conflict.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="dto">The <see cref="GroupMembership" /> to validate.</param>
        public static void ThrowIfConflict(IDataTransferObjectProvider<GroupMembership> provider, GroupMembership dto)
        {
            var query = new Query<GroupMembership>(0, int.MaxValue);

            query.Criterias.Add(membership => membership.GroupId == dto.GroupId);
            query.Criterias.Add(membership => membership.MemberId == dto.MemberId);

            var objects = provider.Query(query).Objects;

            if (objects.Any())
            {
                throw new InvalidOperationException("Object must not conflict.");
            }
        }
    }
}
