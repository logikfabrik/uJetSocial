// <copyright file="Document.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Document" /> class.
    /// </summary>
    [TableName("uJetSocialDocument")]
    public class Document : DataTransferObject, ICloneable<Document>
    {
        private int _documentId;

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        [ForeignKey("Umbraco.Core.Models.Rdbms.NodeDto, Umbraco.Core")]
        [ForeignKey("Umbraco.Core.Models.Rdbms.ContentDto, Umbraco.Core", Column = "nodeId")]
        [Column("DocumentId")]
        public int DocumentId
        {
            get
            {
                return _documentId;
            }

            set
            {
                AssertIsWritableClone();
                _documentId = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Document CreateWritableClone()
        {
            return CreateWritableClone<Document>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Document
            {
                DocumentId = _documentId
            };

            return clone;
        }
    }
}
