// <copyright file="Query{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
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
        private int _pageIndex;
        private int _pageSize;

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
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value" /> is less than <c>0</c>.</exception>
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Value cannot be less than 0.");
                }

                _pageIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        /// <value>
        /// The page size.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is less than <c>1</c>.</exception>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Value cannot be less than 1.");
                }

                _pageSize = value;
            }
        }

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
