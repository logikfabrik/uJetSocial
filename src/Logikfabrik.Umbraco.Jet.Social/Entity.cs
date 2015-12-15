// <copyright file="Entity.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Persistence.DatabaseAnnotations;

    /// <summary>
    /// The <see cref="Entity" /> class.
    /// </summary>
    [TableName("uJetSocialEntity")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class Entity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKeyColumn(AutoIncrement = true)]
        [Column("Id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        [ForeignKey(typeof(EntityType), Name = "FK_uJetSocialEntity_uJetSocialEntityType_Id_As_TypeId")]
        [Column("TypeId")]
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [ResultColumn]
        public string Type { get; set; }
    }
}
