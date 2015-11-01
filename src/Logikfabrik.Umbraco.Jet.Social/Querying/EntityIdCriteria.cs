// <copyright file="EntityIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="EntityIdCriteria" /> class.
    /// </summary>
    public abstract class EntityIdCriteria : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityIdCriteria" /> class.
        /// </summary>
        protected EntityIdCriteria()
            : base("uJetCommunityEntity.Id")
        {
        }
    }
}
