// <copyright file="Report.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report
{
    using System;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Report" /> class.
    /// </summary>
    [TableName("uJetSocialReport")]
    public class Report : DataTransferObject, IAuthorable
    {
        private int _entityId;
        private Type _entityType;
        private int _authorId;
        private Type _authorType;
        private string _text;

        /// <summary>
        /// Gets or sets the identifier of the reported entity.
        /// </summary>
        /// <value>
        /// The identifier of the reported entity.
        /// </value>
        [ForeignKey(typeof(Entity), Name = "FK_uJetSocialReport_uJetSocialEntity_Id_As_EntityId")]
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

                Updated = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the identifier of the author.
        /// </summary>
        /// <value>
        /// The identifier of the author.
        /// </value>
        [ForeignKey(typeof(Entity), Name = "FK_uJetSocialReport_uJetSocialEntity_Id_As_AuthorId")]
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
        /// Gets or sets the report.
        /// </summary>
        /// <value>
        /// The report.
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
        public Report CreateWritableClone()
        {
            return CreateWritableClone<Report>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Report
            {
                EntityId = _entityId,
                AuthorId = _authorId,
                Text = _text
            };

            return clone;
        }
    }
}
