// <copyright file="Query{T}.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The <see cref="Query{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="DataTransferObject" /> type.</typeparam>
    public class Query<T>
        where T : DataTransferObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Query{T}" /> class.
        /// </summary>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        public Query(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Criterias = new List<Expression<Func<T, bool>>>();
        }

        /// <summary>
        /// Gets or sets the page index.
        /// </summary>
        /// <value>
        /// The page index.
        /// </value>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>
        /// The page size.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets the criterias.
        /// </summary>
        /// <value>
        /// The criterias.
        /// </value>
        public IList<Expression<Func<T, bool>>> Criterias { get; }

        public Expression<Func<T, object>> OrderBy { get; set; }
    }
}
