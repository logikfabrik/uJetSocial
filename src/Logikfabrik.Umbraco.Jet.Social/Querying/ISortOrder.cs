// <copyright file="ISortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="ISortOrder" /> interface.
    /// </summary>
    public interface ISortOrder
    {
        /// <summary>
        /// Builds the sort order.
        /// </summary>
        /// <returns>The sort order.</returns>
        string Build();
    }
}
