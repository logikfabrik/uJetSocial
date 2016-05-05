// <copyright file="CommentQuery.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Models.Querying
{
    /// <summary>
    /// The <see cref="CommentQuery" /> class.
    /// </summary>
    public class CommentQuery : Query
    {
        /// <summary>
        /// Gets or sets the text to query by.
        /// </summary>
        /// <value>
        /// The text to query by.
        /// </value>
        public string Text { get; set; }
    }
}
