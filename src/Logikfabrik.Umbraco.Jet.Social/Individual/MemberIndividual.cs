// <copyright file="MemberIndividual.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using System;

    /// <summary>
    /// The <see cref="MemberIndividual" /> class.
    /// </summary>
    public class MemberIndividual : Individual
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividual" /> class.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="member" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="member" /> has an invalid identifier, or is writable.</exception>
        public MemberIndividual(Member.Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            if (!member.IsReadOnly)
            {
                throw new ArgumentException("Member must be read-only.", nameof(member));
            }

            Member = member;
        }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <value>
        /// The member.
        /// </value>
        public Member.Member Member { get; }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override Entity Clone()
        {
            var clone = new MemberIndividual(Member);

            return clone;
        }
    }
}
