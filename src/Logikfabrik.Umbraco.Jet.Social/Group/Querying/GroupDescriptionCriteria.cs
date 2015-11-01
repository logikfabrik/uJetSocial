﻿// <copyright file="GroupDescriptionCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="GroupDescriptionCriteria" /> class.
    /// </summary>
    public class GroupDescriptionCriteria : Criteria, IGroupCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupDescriptionCriteria" /> class.
        /// </summary>
        public GroupDescriptionCriteria()
            : base("uJetSocialGroup.Description")
        {
        }
    }
}