// <copyright file="CommentProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    using System;

    /// <summary>
    /// The <see cref="CommentProvider" /> class.
    /// </summary>
    public class CommentProvider : DataTransferObjectProvider<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public CommentProvider(Func<IDatabaseWrapper> database)
            : base(database)
        {
        }

        /// <summary>
        /// Gets the comment with the specified identifier.
        /// </summary>
        /// <param name="id">The comment identifier.</param>
        /// <returns>The comment with the specified identifier.</returns>
        public override Comment Get(int id)
        {
            var comment = base.Get(id);

            if (comment == null)
            {
                return null;
            }

            comment.IsReadOnly = false;

            comment.EntityType = GetEntityType(comment.EntityId);
            comment.AuthorType = GetEntityType(comment.AuthorId);

            comment.IsReadOnly = true;

            return comment;
        }
    }
}
