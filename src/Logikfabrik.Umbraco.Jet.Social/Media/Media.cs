// <copyright file="Media.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Media
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Media" /> class.
    /// </summary>
    [TableName("uJetSocialMedia")]
    public class Media : DataTransferObject
    {
        private int _mediaId;

        /// <summary>
        /// Gets or sets the media identifier.
        /// </summary>
        /// <value>
        /// The media identifier.
        /// </value>
        [ForeignKey("Umbraco.Core.Models.Rdbms.NodeDto, Umbraco.Core")]
        [ForeignKey("Umbraco.Core.Models.Rdbms.ContentDto, Umbraco.Core", Column = "nodeId")]
        [Column("MediaId")]
        public int MediaId
        {
            get
            {
                return _mediaId;
            }

            set
            {
                AssertIsWritableClone();
                _mediaId = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Media CreateWritableClone()
        {
            return CreateWritableClone<Media>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>
        /// A writable clone of this instance.
        /// </returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Media
            {
                MediaId = _mediaId
            };

            return clone;
        }
    }
}
