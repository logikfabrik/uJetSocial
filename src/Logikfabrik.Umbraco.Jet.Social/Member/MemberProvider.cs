// <copyright file="MemberProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Member
{
    /// <summary>
    /// The <see cref="MemberProvider" /> class.
    /// </summary>
    public class MemberProvider : DataTransferObjectProvider<Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public MemberProvider(IDatabaseWrapper database)
            : base(database)
        {
        }
    }
}
