// <copyright file="IIndividualMemberProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    /// <summary>
    /// The <see cref="IIndividualMemberProvider" /> interface.
    /// </summary>
    public interface IIndividualMemberProvider : IDataTransferObjectProvider<IndividualMember>
    {
        /// <summary>
        /// Gets the data transfer object with the specified member identifier.
        /// </summary>
        /// <param name="id">The member identifier.</param>
        /// <returns>The data transfer object with the specified member identifier.</returns>
        IndividualMember GetByMemberId(int id);
    }
}