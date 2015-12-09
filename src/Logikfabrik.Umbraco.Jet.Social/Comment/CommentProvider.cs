// <copyright file="CommentProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    /// <summary>
    /// The <see cref="CommentProvider" /> class.
    /// </summary>
    public class CommentProvider : DataTransferObjectProvider<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public CommentProvider(IDatabaseWrapper database)
            : base(database)
        {
        }

        /// <summary>
        /// Gets the <see cref="Comment" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="Comment" /> identifier.</param>
        /// <returns>The <see cref="Comment" />.</returns>
        public override Comment Get(int id)
        {
            var comment = base.Get(id);

            if (comment == null)
            {
                return null;
            }

            comment.IsReadOnly = false;

            comment.EntityType = GetType(comment.EntityId);
            comment.AuthorType = GetType(comment.AuthorId);

            comment.IsReadOnly = true;

            return comment;
        }
    }
}
