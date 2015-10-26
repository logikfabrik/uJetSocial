// <copyright file="EntityUpdatedCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// Represents a entity updated criteria.
    /// </summary>
    public abstract class EntityUpdatedCriteria : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityUpdatedCriteria" /> class.
        /// </summary>
        protected EntityUpdatedCriteria()
            : base("uJetCommunityEntity.Updated")
        {
        }
    }
}
