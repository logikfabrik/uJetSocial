// <copyright file="DocumentProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    /// <summary>
    /// The <see cref="DocumentProvider" /> class.
    /// </summary>
    public class DocumentProvider : DataTransferObjectProvider<Document>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public DocumentProvider(IDatabaseWrapper database)
            : base(database)
        {
        }
    }
}
