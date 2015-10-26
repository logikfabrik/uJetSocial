// <copyright file="MemberIndividual.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using System;

    /// <summary>
    /// Represents a member individual.
    /// </summary>
    public class MemberIndividual : Individual
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividual" /> class.
        /// </summary>
        /// <param name="member">A member.</param>
        public MemberIndividual(Member.Member member)
        {
            if (member == null)
            {
                throw new ArgumentException("member");
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
        public Member.Member Member { get; }

        /// <summary>
        /// Gets a clone of the current entity.
        /// </summary>
        /// <returns>A clone of the current entity.</returns>
        protected override Entity Clone()
        {
            var clone = new MemberIndividual(Member);

            return clone;
        }
    }
}
