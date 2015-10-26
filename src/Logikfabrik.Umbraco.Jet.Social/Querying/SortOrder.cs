// <copyright file="SortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;

    /// <summary>
    /// Represents a sort order.
    /// </summary>
    public abstract class SortOrder : ISortOrder
    {
        protected SortOrder(string name, Order order)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.", nameof(name));
            }

            Name = name;
            Order = order;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the order.
        /// </summary>
        public Order Order { get; }

        /// <summary>
        /// Builds the sort order.
        /// </summary>
        /// <returns>The sort order.</returns>
        public string Build()
        {
            return $"{Name} {GetOrder()}";
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <returns>The order.</returns>
        private string GetOrder()
        {
            switch (Order)
            {
                case Order.Ascending:
                    return "ASC";
                case Order.Descending:
                    return "DESC";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
