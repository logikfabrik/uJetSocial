// <copyright file="DateTreeController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http.Formatting;
    using global::Umbraco.Core.Services;
    using global::Umbraco.Web.Models.Trees;

    /// <summary>
    /// The <see cref="DateTreeController" /> class.
    /// </summary>
    public abstract class DateTreeController : TreeController
    {
        private readonly Lazy<IDictionary<int, IDictionary<int, int>>> _dates;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        protected DateTreeController(ILocalizedTextService localizedTextService)
            : base(localizedTextService)
        {
            _dates = new Lazy<IDictionary<int, IDictionary<int, int>>>(GetDates);
        }

        /// <summary>
        /// Gets the dates.
        /// </summary>
        /// <returns>The dates.</returns>
        protected abstract IDictionary<int, IDictionary<int, int>> GetDates();

        /// <summary>
        /// Gets the tree nodes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>The tree nodes.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="id" /> is <c>null</c> or white space.</exception>
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or white space.", nameof(id));
            }

            if (!IsRootNode(id))
            {
                return GetTreeNodesForYear(id, queryStrings);
            }

            var nodes = new TreeNodeCollection();

            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var count in _dates.Value)
            {
                var total = count.Value.Sum(month => month.Value);

                var node = CreateTreeNode(count.Key.ToString(CultureInfo.InvariantCulture), id, queryStrings, $"{count.Key.ToString(CultureInfo.InvariantCulture)} ({total})", string.Empty, total > 0);

                nodes.Add(node);
            }

            return nodes;
        }

        private TreeNodeCollection GetTreeNodesForYear(string id, FormDataCollection queryStrings)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or white space.", nameof(id));
            }

            var nodes = new TreeNodeCollection();

            var year = int.Parse(id);

            for (var month = 1; month < 13; month++)
            {
                var total = 0;

                if (_dates.Value[year].ContainsKey(month))
                {
                    total = _dates.Value[year][month];
                }

                nodes.Add(CreateTreeNode($"{year}-{month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0')}", id, queryStrings, $"{DateTimeFormatInfo.InvariantInfo.GetMonthName(month)} ({total})", string.Empty, false));
            }

            return nodes;
        }
    }
}
