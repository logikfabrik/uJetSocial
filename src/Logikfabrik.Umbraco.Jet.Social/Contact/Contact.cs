// <copyright file="Contact.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact
{
    using System;

    /// <summary>
    /// The <see cref="Contact" /> class.
    /// </summary>
    public class Contact : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class.
        /// </summary>
        /// <param name="from">The member this instance is from.</param>
        /// <param name="to">The member this instance is to.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="from" /> or <paramref name="to" /> are <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="from" /> or <paramref name="to" /> have invalid identifiers, or are writable.</exception>
        public Contact(Member.Member from, Member.Member to)
        {
            if (from == null)
            {
                throw new ArgumentNullException(nameof(from));
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
                throw new ArgumentNullException(nameof(to));
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
        /// Gets the member this instance is from.
        /// </summary>
        /// <value>
        /// The member this instance is from.
        /// </value>
        public Member.Member From { get; }

        /// <summary>
        /// Gets the member this instance is to.
        /// </summary>
        /// <value>
        /// The member this instance is to.
        /// </value>
        public Member.Member To { get; }

        /// <summary>
        /// Gets the default cache key.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The default cache key.</returns>
        public static string GetDefaultCacheKey(int id)
        {
            return GetDefaultCacheKey(typeof(Contact), id);
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
            var clone = new Contact(From, To);

            return clone;
        }
    }
}
