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
        /// <param name="databaseWrapper">The database wrapper.</param>
        public CommentProvider(IDatabaseWrapper databaseWrapper)
            : base(databaseWrapper)
        {
        }
    }
}
