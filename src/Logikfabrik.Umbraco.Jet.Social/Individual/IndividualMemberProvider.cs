// <copyright file="IndividualMemberProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    /// <summary>
    /// The <see cref="IndividualMemberProvider" /> class.
    /// </summary>
    public class IndividualMemberProvider : DataTransferObjectProvider<IndividualMember>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualMemberProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public IndividualMemberProvider(IDatabaseWrapper database)
            : base(database)
        {
        }
    }
}
