// <copyright file="GroupProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    /// <summary>
    /// The <see cref="GroupProvider" /> class.
    /// </summary>
    public class GroupProvider : DataTransferObjectProvider<Group>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupProvider" /> class.
        /// </summary>
        /// <param name="databaseWrapper">The database wrapper.</param>
        public GroupProvider(IDatabaseWrapper databaseWrapper)
            : base(databaseWrapper)
        {
        }
    }
}
