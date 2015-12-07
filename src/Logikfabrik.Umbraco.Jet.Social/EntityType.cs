// <copyright file="EntityType.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Persistence.DatabaseAnnotations;

    /// <summary>
    /// The <see cref="EntityType" /> class.
    /// </summary>
    [TableName("uJetSocialEntityType")]
    [PrimaryKey("Id", autoIncrement = true)]
    public class EntityType
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
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [Index(IndexTypes.UniqueNonClustered)]
        [Column("Type")]
        public string Type { get; set; }
    }
}
