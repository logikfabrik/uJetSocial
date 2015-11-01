// <copyright file="EntityStatusCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="EntityStatusCriteria" /> class.
    /// </summary>
    public abstract class EntityStatusCriteria : Criteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityStatusCriteria" /> class.
        /// </summary>
        protected EntityStatusCriteria()
            : base("uJetSocialEntity.Status")
        {
        }
    }
}
