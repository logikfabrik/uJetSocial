// <copyright file="SortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Querying
{
    using System;

    /// <summary>
    /// The <see cref="SortOrder" /> class.
    /// </summary>
    public abstract class SortOrder : ISortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SortOrder" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="order">The order.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name" /> is <c>null</c> or white space.</exception>
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
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public Order Order { get; }

        /// <summary>
        /// Builds the sort order.
        /// </summary>
        /// <returns>
        /// The sort order.
        /// </returns>
        public string Build()
        {
            return $"{Name} {GetOrder()}";
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <returns>The order.</returns>
        /// <exception cref="NotSupportedException">Thrown if the order is not supported.</exception>
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
