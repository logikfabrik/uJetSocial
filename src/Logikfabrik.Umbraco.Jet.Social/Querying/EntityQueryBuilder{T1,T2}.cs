// <copyright file="EntityQueryBuilder{T1,T2}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The <see cref="EntityQueryBuilder{T1, T2}" /> class.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public abstract class EntityQueryBuilder<T1, T2> : QueryBuilder<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityQueryBuilder{T1, T2}" /> class.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="table">The table.</param>
        protected EntityQueryBuilder(IEnumerable<string> columns, string table)
            : base(GetColumns().Union(columns), "uJetSocialEntity")
        {
        }

        /// <summary>
        /// Gets the joins.
        /// </summary>
        /// <returns>
        /// The joins.
        /// </returns>
        protected override IEnumerable<string> GetJoins()
        {
            return new[] { string.Format("{0} ON {0}.Id = uJetSocialEntity.Id", Table) };
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetSocialEntity.Id",
                "uJetSocialEntity.Created",
                "uJetSocialEntity.Updated",
                "uJetSocialEntity.Status"
            };
        }
    }
}
