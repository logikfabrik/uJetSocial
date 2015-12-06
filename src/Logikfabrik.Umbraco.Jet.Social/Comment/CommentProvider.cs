// <copyright file="CommentProvider.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    using Data;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="CommentProvider" /> class.
    /// </summary>
    public sealed class CommentProvider : DataTransferObjectProvider<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public CommentProvider(Database database)
            : base(database)
        {
        }
    }
}
