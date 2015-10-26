// <copyright file="Contact.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact
{
    using System;

    /// <summary>
    /// Represents a contact.
    /// </summary>
    public class Contact : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="from">Member from.</param>
        /// <param name="to">Member to.</param>
        public Contact(Member.Member from, Member.Member to)
        {
            if (from == null)
            {
                throw new ArgumentException("from");
            }

            if (!EntityValidator.EntityHasId(from))
            {
                throw new ArgumentException("From must have a valid ID.", nameof(@from));
            }

            if (!from.IsReadOnly)
            {
                throw new ArgumentException("From must be read-only.", nameof(@from));
            }

            if (to == null)
            {
                throw new ArgumentException("to");
            }

            if (!EntityValidator.EntityHasId(to))
            {
                throw new ArgumentException("To must have a valid ID.", nameof(to));
            }

            if (!to.IsReadOnly)
            {
                throw new ArgumentException("To must be read-only.", nameof(to));
            }

            From = from;
            To = to;
        }

        /// <summary>
        /// Gets contact from member.
        /// </summary>
        public Member.Member From { get; }

        /// <summary>
        /// Gets contact to member.
        /// </summary>
        public Member.Member To { get; }

        /// <summary>
        /// Gets the default cache key for a contact.
        /// </summary>
        /// <param name="id">The contact ID.</param>
        /// <returns>The default contact cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Contact), id);
        }

        /// <summary>
        /// Gets cache keys for the current contact.
        /// </summary>
        /// <returns>Cache keys.</returns>
        public override string[] GetCacheKeys()
        {
            return new[] { GetDefaultCacheKey(Id) };
        }

        /// <summary>
        /// Gets a clone of the current contact.
        /// </summary>
        /// <returns>A clone of the current contact.</returns>
        protected override Entity Clone()
        {
            var clone = new Contact(From, To);

            return clone;
        }
    }
}
