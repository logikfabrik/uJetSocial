// <copyright file="SearchQueryResult{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The <see cref="SearchQueryResult{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    [DataContract]
    public class SearchQueryResult<T>
        where T : Entity
    {
        /// <summary>
        /// Gets or sets the total number of entities.
        /// </summary>
        /// <value>
        /// The total number of entities.
        /// </value>
        [DataMember(Name = "total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        [DataMember(Name = "entities")]
        public IEnumerable<T> Entities { get; set; }
    }
}
