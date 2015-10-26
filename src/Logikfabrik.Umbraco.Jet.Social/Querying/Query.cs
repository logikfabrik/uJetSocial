// <copyright file="Query.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System.Collections.Generic;
    using System.Linq;
    using Caching;

    /// <summary>
    /// Represents a query.
    /// </summary>
    /// <typeparam name="T1">The criteria type.</typeparam>
    /// <typeparam name="T2">The sort order type.</typeparam>
    public abstract class Query<T1, T2>
        where T1 : ICriteria
        where T2 : class, ISortOrder
    {
        /// <summary>
        /// The default page size.
        /// </summary>
        private const int DefaultPageSize = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query{T1,T2}" /> class.
        /// </summary>
        protected Query()
        {
            Criterias = new List<T1>();
            PageSize = DefaultPageSize;
        }

        /// <summary>
        /// Gets the criterias.
        /// </summary>
        public IList<T1> Criterias { get; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        public T2 SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the page index.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <returns>The cache key.</returns>
        public string GetCacheKey()
        {
            var obj = new
            {
                Type = GetType(),
                Criterias = Criterias.Select(criteria => criteria.GetCacheKey()).OrderBy(ck => ck),
                SortOrder,
                PageIndex,
                PageSize
            };

            return CacheKeyUtility.CreateCacheKey(obj);
        }
    }
}
