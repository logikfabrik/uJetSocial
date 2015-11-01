// <copyright file="NumericCriteriaValue{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// The <see cref="NumericCriteriaValue{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public class NumericCriteriaValue<T> : CriteriaValue
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public NumericCriteriaValueOperator Operator { get; set; }

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
                case NumericCriteriaValueOperator.EqualTo:
                    return "{0} = {1}";
                case NumericCriteriaValueOperator.NotEqualTo:
                    return "{0} != {1}";
                case NumericCriteriaValueOperator.LargerThan:
                    return "{0} > {1}";
                case NumericCriteriaValueOperator.LessThan:
                    return "{0} < {1}";
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
                { $"{columnName}{Operator}Value", Value }
            };
        }
    }
}