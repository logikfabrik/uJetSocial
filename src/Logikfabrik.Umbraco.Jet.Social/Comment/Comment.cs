// <copyright file="Comment.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    using System;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Comment" /> class.
    /// </summary>
    [TableName("uJetSocialComment")]
    public class Comment : DataTransferObject, IAuthorable
    {
        private int _entityId;
        private Type _entityType;
        private int _authorId;
        private Type _authorType;
        private string _text;

        /// <summary>
        /// Gets or sets the identifier of the commented entity.
        /// </summary>
        /// <value>
        /// The identifier of the commented entity.
        /// </value>
        [ForeignKey(typeof(Entity), Name = "FK_uJetSocialComment_uJetSocialEntity_Id_As_EntityId")]
        [Column("EntityId")]
        public int EntityId
        {
            get
            {
                return _entityId;
            }

            set
            {
                AssertIsWritableClone();
                _entityId = value;
            }
        }

        /// <summary>
        /// Gets or sets the identifier of the author.
        /// </summary>
        /// <value>
        /// The identifier of the author.
        /// </value>
        [ForeignKey(typeof(Entity), Name = "FK_uJetSocialComment_uJetSocialEntity_Id_As_AuthorId")]
        [Column("AuthorId")]
        public int AuthorId
        {
            get
            {
                return _authorId;
            }

            set
            {
                AssertIsWritableClone();
                _authorId = value;

                Updated = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>
        /// The comment.
        /// </value>
        [Column("Text")]
        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                AssertIsWritableClone();
                _text = value;

                Updated = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the entity type.
        /// </summary>
        /// <value>
        /// The entity type.
        /// </value>
        [Ignore]
        public Type EntityType
        {
            get
            {
                return _entityType;
            }

            set
            {
                AssertIsWritableClone();
                _entityType = value;
            }
        }

        /// <summary>
        /// Gets or sets the author type.
        /// </summary>
        /// <value>
        /// The author type.
        /// </value>
        [Ignore]
        public Type AuthorType
        {
            get
            {
                return _authorType;
            }

            set
            {
                AssertIsWritableClone();
                _authorType = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Comment CreateWritableClone()
        {
            return CreateWritableClone<Comment>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Comment
            {
                EntityId = _entityId,
                AuthorId = _authorId,
                Text = _text
            };

            return clone;
        }
    }
}