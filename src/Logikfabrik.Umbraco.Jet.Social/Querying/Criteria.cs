// <copyright file="Criteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Linq;
    using Caching;

    /// <summary>
    /// The <see cref="Criteria" /> class.
    /// </summary>
    public abstract class Criteria : ICriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Criteria" /> class.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <exception cref="System.ArgumentException">Thrown if <paramref name="columnName" /> is <c>null</c> or white space.</exception>
        protected Criteria(string columnName)
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                throw new ArgumentException("Column name cannot be null or white space.", nameof(columnName));
            }

            ColumnName = columnName;
        }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public ICriteriaValue Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <returns>
        /// The command text.
        /// </returns>
        public string GetCommandText()
        {
            if (Value == null)
            {
                return null;
            }

            var names = (new object[] { ColumnName }).Concat(Value.GetCommandParameters(this).Keys.Select(k => string.Concat("@", k))).ToArray();

            return string.Format(Value.GetCommandFormat(), names);
        }

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <returns>
        /// The cache key.
        /// </returns>
        public string GetCacheKey()
        {
            object obj;

            if (Value == null)
            {
                obj = new
                {
                    ColumnName
                };
            }
            else
            {
                obj = new
                {
                    ColumnName,
                    Value = new
                    {
                        CommandFormat = Value.GetCommandFormat()
                    }
                };
            }

            return CacheKeyUtility.CreateCacheKey(obj);
        }
    }
}