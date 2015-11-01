// <copyright file="CriteriaValue.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The <see cref="CriteriaValue" /> class.
    /// </summary>
    public abstract class CriteriaValue : ICriteriaValue
    {
        /// <summary>
        /// Gets the database type.
        /// </summary>
        /// <value>
        /// The database type.
        /// </value>
        public abstract DbType DbType { get; }

        /// <summary>
        /// Gets the command format.
        /// </summary>
        /// <returns>
        /// The command format.
        /// </returns>
        public abstract string GetCommandFormat();

        /// <summary>
        /// Gets the command parameters.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>
        /// The command parameters.
        /// </returns>
        public abstract IDictionary<string, object> GetCommandParameters(ICriteria criteria);

        /// <summary>
        /// Gets the database type for the specified value type.
        /// </summary>
        /// <param name="valueType">The value type.</param>
        /// <returns>The database type.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="valueType" /> is <c>null</c>.</exception>
        /// <exception cref="NotSupportedException">Thrown if <paramref name="valueType" /> is not supported.</exception>
        protected DbType GetDbType(Type valueType)
        {
            if (valueType == null)
            {
                throw new ArgumentNullException(nameof(valueType));
            }

            if (valueType == typeof(string))
            {
                return DbType.String;
            }

            if (valueType == typeof(DateTime))
            {
                return DbType.DateTime;
            }

            if (valueType == typeof(int))
            {
                return DbType.Int32;
            }

            if (valueType == typeof(long))
            {
                return DbType.Int64;
            }

            throw new NotSupportedException($"Value type of type {valueType} is not supported.");
        }
    }
}
