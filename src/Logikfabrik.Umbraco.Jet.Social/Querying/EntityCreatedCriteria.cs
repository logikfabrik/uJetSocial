// <copyright file="EntityCreatedCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="EntityCreatedCriteria" /> class.
    /// </summary>
    public abstract class EntityCreatedCriteria : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCreatedCriteria" /> class.
        /// </summary>
        protected EntityCreatedCriteria()
            : base("uJetCommunityEntity.Created")
        {
        }
    }
}
