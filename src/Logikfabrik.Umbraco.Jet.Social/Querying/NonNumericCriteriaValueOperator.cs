// <copyright file="NonNumericCriteriaValueOperator.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    /// <summary>
    /// The <see cref="NonNumericCriteriaValueOperator" /> enumeration.
    /// </summary>
    public enum NonNumericCriteriaValueOperator
    {
        /// <summary>
        /// Equal to.
        /// </summary>
        EqualTo,

        /// <summary>
        /// Not equal to.
        /// </summary>
        NotEqualTo,

        /// <summary>
        /// Similar to.
        /// </summary>
        SimilarTo,

        /// <summary>
        /// Starts with.
        /// </summary>
        StartsWith,

        /// <summary>
        /// Ends with.
        /// </summary>
        EndsWith
    }
}
