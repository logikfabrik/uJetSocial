// <copyright file="NumericRangeCriteriaValue{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// The <see cref="NumericRangeCriteriaValue{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public class NumericRangeCriteriaValue<T> : CriteriaValue
            where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// Gets or sets the minimum value.
        /// </summary>
        /// <value>
        /// The minimum value.
        /// </value>
        public T MinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        public T MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public NumericRangeCriteriaValueOperator Operator { get; set; }

        /// <summary>
        /// Gets the database type.
        /// </summary>
        public override DbType DbType => GetDbType(typeof(T));

        /// <summary>
        /// Gets the command format.
        /// </summary>
        /// <returns>The command format.</returns>
        public override string GetCommandFormat()
        {
            switch (Operator)
            {
                case NumericRangeCriteriaValueOperator.Between:
                    return "{0} BETWEEN {1} AND {2}";
                case NumericRangeCriteriaValueOperator.NotBetween:
                    return "{0} NOT BETWEEN {1} AND {2}";
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets the command parameters.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>The command parameters.</returns>
        public override IDictionary<string, object> GetCommandParameters(ICriteria criteria)
        {
            var columnName = criteria.ColumnName.Split('.').Last();

            return new Dictionary<string, object>
            {
                { $"{columnName}{Operator}MinValue", MinValue },
                { $"{columnName}{Operator}MaxValue", MaxValue }
            };
        }
    }
}
