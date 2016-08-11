// <copyright file="Attribute.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Attribute
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="Attribute" /> class.
    /// </summary>
    [TableName("uJetSocialAttribute")]
    public class Attribute : DataTransferObject, ICloneable<Attribute>
    {
        private int _entityTypeId;
        private string _name;
        private string _typeName;

        /// <summary>
        /// Gets or sets the identifier of the attributed entity type.
        /// </summary>
        /// <value>
        /// The identifier of the attributed entity type.
        /// </value>
        [ForeignKey(typeof(EntityType), Name = "FK_uJetSocialAttribute_uJetSocialEntityType_Id_As_EntityTypeId")]
        public int EntityTypeId
        {
            get
            {
                return _entityTypeId;
            }

            set
            {
                AssertIsWritableClone();
                _entityTypeId = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
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
        /// Gets or sets the type name
        /// </summary>
        /// <value>
        /// The type name.
        /// </value>
        public string TypeName
        {
            get
            {
                return _typeName;
            }

            set
            {
                AssertIsWritableClone();
                _typeName = value;
            }
        }

        /// <summary>
        /// Gets a writable clone.
        /// </summary>
        /// <returns>A writable clone.</returns>
        public Attribute CreateWritableClone()
        {
            return CreateWritableClone<Attribute>();
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns>A writable clone of this instance.</returns>
        protected override DataTransferObject Clone()
        {
            var clone = new Attribute
            {
                EntityTypeId = _entityTypeId,
                Name = _name,
                TypeName = _typeName
            };

            return clone;
        }
    }
}
