﻿// <copyright file="Document.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Document" /> class.
    /// </summary>
    [TableName("uJetSocialDocument")]
    public class Document : DataTransferObject
    {
        private int _documentId;

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        [ForeignKey("Umbraco.Core.Models.Rdbms.DocumentDto,Umbraco.Core", Name = "FK_uJetSocialDocument_cmsDocument_nodeId_As_DocumentId")]
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