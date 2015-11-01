// <copyright file="GroupMembership.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;

    /// <summary>
    /// The <see cref="GroupMembership" /> class.
    /// </summary>
    public class GroupMembership : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembership"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="group" /> or <paramref name="member" /> are <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="group" /> or <paramref name="member" /> have invalid identifiers, or are writable.</exception>
        public GroupMembership(Group group, Member.Member member)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(@group));
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
                throw new ArgumentNullException(nameof(member));
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
        /// <value>
        /// The group.
        /// </value>
        public Group Group { get; }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public Member.Member Member { get; }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(GroupMembership), id);
        }

        /// <summary>
        /// Gets the cache keys.
        /// </summary>
        /// <returns>
        /// The cache keys.
        /// </returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override Entity Clone()
        {
            var clone = new GroupMembership(Group, Member);

            return clone;
        }
    }
}
