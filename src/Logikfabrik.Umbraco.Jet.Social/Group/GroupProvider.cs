﻿// <copyright file="GroupProvider.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="GroupProvider" /> class.
    /// </summary>
    public sealed class GroupProvider : DataTransferObjectProvider<Group>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public GroupProvider(Database database)
            : base(database)
        {
        }
    }
}
