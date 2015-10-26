// <copyright file="GroupMembership.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;

    /// <summary>
    /// Represents a group membership.
    /// </summary>
    public class GroupMembership : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembership" /> class.
        /// </summary>
        /// <param name="group">A group.</param>
        /// <param name="member">A member.</param>
        public GroupMembership(Group group, Member.Member member)
        {
            if (group == null)
            {
                throw new ArgumentException("group");
            }

            if (!EntityValidator.EntityHasId(group))
            {
                throw new ArgumentException("Group must have a valid ID.", nameof(@group));
            }

            if (!group.IsReadOnly)
            {
                throw new ArgumentException("Group must be read-only.", nameof(@group));
            }

            if (member == null)
            {
                throw new ArgumentException("member");
            }

            if (!EntityValidator.EntityHasId(member))
            {
                throw new ArgumentException("Member must be have a valid ID.", nameof(member));
            }

            if (!member.IsReadOnly)
            {
                throw new ArgumentException("Member must be read-only.", nameof(member));
            }

            Group = group;
            Member = member;
        }

        /// <summary>
        /// Gets the group.
        /// </summary>
        public Group Group { get; }

        /// <summary>
        /// Gets the member.
        /// </summary>
        public Member.Member Member { get; }

        /// <summary>
        /// Gets the default cache key for a group membership.
        /// </summary>
        /// <param name="id">The group membership ID.</param>
        /// <returns>The default group membership cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(GroupMembership), id);
        }

        /// <summary>
        /// Gets cache keys for the current group membership.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }

        /// <summary>
        /// Gets a clone of the current entity.
        /// </summary>
        /// <returns>A clone of the current entity.</returns>
        protected override Entity Clone()
        {
            var clone = new GroupMembership(Group, Member);

            return clone;
        }
    }
}
