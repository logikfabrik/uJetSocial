// <copyright file="Group.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Group" /> class.
    /// </summary>
    [TableName("uJetSocialGroup")]
    public class Group : DataTransferObject, IOwnable
    {
        private string _name;
        private string _description;
        private int _ownerId;
        private Type _ownerType;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Column("Name")]
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                AssertIsWritableClone();
                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column("Description")]
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                AssertIsWritableClone();
                _description = value;
            }
        }

        /// <summary>
        /// Gets or sets the identifier of the owner.
        /// </summary>
        /// <value>
        /// The identifier of the owner.
        /// </value>
        [ForeignKey(typeof(Entity), Name = "FK_uJetSocialGroup_uJetSocialEntity_Id_As_OwnerId")]
        [Column("OwnerId")]
        public int OwnerId
        {
            get
            {
                return _ownerId;
            }

            set
            {
                AssertIsWritableClone();
                _ownerId = value;
            }
        }

        /// <summary>
        /// Gets or sets the owner type.
        /// </summary>
        /// <value>
        /// The owner type.
        /// </value>
        [Ignore]
        public Type OwnerType
        {
            get
            {
                return _ownerType;
            }

            set
            {
                AssertIsWritableClone();
                _ownerType = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Group CreateWritableClone()
        {
            return CreateWritableClone<Group>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Group
            {
                Name = _name,
                Description = _description,
                OwnerId = _ownerId
            };

            return clone;
        }
    }
}