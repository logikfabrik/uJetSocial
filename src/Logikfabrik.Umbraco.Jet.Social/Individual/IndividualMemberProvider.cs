// <copyright file="IndividualMemberProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="IndividualMemberProvider" /> class.
    /// </summary>
    public class IndividualMemberProvider : IndividualProvider<IndividualMember>, IIndividualMemberProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndividualMemberProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public IndividualMemberProvider(Func<IDatabaseWrapper> database)
            : base(database)
        {
        }

        /// <summary>
        /// Gets the data transfer object with the specified member identifier.
        /// </summary>
        /// <param name="id">The member identifier.</param>
        /// <returns>The data transfer object with the specified member identifier.</returns>
        public IndividualMember GetByMemberId(int id)
        {
            var query = new Query<IndividualMember>(0, int.MaxValue);

            query.Criterias.Add(member => member.MemberId == id);

            var objects = Query(query).Objects;

            return objects.SingleOrDefault();
        }
    }
}
