// <copyright file="NonNumericCriteriaValue.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// Represents a non numeric criteria value.
    /// </summary>
    public class NonNumericCriteriaValue : CriteriaValue
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public NonNumericCriteriaValueOperator Operator { get; set; }

        /// <summary>
        /// Gets the DB type.
        /// </summary>
        public override DbType DbType => GetDbType(typeof(string));

        /// <summary>
        /// Gets the command format.
        /// </summary>
        /// <returns>The command format.</returns>
        public override string GetCommandFormat()
        {
            switch (Operator)
            {
                case NonNumericCriteriaValueOperator.EqualTo:
                    return "{0} = {1}";
                case NonNumericCriteriaValueOperator.NotEqualTo:
                    return "{0} != {1}";
                case NonNumericCriteriaValueOperator.SimilarTo:
                    return "{0} LIKE '%'{1}'%'";
                case NonNumericCriteriaValueOperator.StartsWith:
                    return "{0} LIKE {1}'%'";
                case NonNumericCriteriaValueOperator.EndsWith:
                    return "{0} LIKE '%'{1}";
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Gets the command parameters.
        /// </summary>
        /// <param name="criteria">A criteria.</param>
        /// <returns>The command parameters.</returns>
        public override IDictionary<string, object> GetCommandParameters(ICriteria criteria)
        {
            var columnName = criteria.ColumnName.Split('.').Last();

            return new Dictionary<string, object>
            {
                {$"{columnName}{Operator}Value", Value }
            };
        }
    }
}
