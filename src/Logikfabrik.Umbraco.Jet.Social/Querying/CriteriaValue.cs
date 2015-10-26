// <copyright file="CriteriaValue.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Represents a criteria value.
    /// </summary>
    public abstract class CriteriaValue : ICriteriaValue
    {
        /// <summary>
        /// Gets the DB type.
        /// </summary>
        public abstract DbType DbType { get; }

        /// <summary>
        /// Gets the command format.
        /// </summary>
        /// <returns>The command format.</returns>
        public abstract string GetCommandFormat();

        /// <summary>
        /// Gets the command parameters.
        /// </summary>
        /// <param name="criteria">A criteria.</param>
        /// <returns>The command parameters.</returns>
        public abstract IDictionary<string, object> GetCommandParameters(ICriteria criteria);

        /// <summary>
        /// Gets a DB type for the given value type.
        /// </summary>
        /// <param name="valueType">The value type to get a DB type for.</param>
        /// <returns>A DB type.</returns>
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
