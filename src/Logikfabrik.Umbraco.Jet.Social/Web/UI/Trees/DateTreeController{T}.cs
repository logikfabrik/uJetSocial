// <copyright file="DateTreeController{T}.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http.Formatting;
    using global::Umbraco.Web.Models.Trees;
    using Globalization.Localization;

    /// <summary>
    /// The <see cref="CreatedTreeController{T}" /> class. Abstract base class for date structured Umbraco UI trees.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public abstract class CreatedTreeController<T> : TreeController
        where T : Entity
    {
        private readonly IEntityProviderFactory _entityProviderFactory;
        private readonly Lazy<IDictionary<int, IDictionary<int, int>>> _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatedTreeController{T}" /> class.
        /// </summary>
        /// <param name="uiLanguageService">The UI language service.</param>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entityProviderFactory" /> is <c>null</c>.</exception>
        protected CreatedTreeController(IUILanguageService uiLanguageService, IEntityProviderFactory entityProviderFactory)
            : base(uiLanguageService)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            _entityProviderFactory = entityProviderFactory;
            _count = new Lazy<IDictionary<int, IDictionary<int, int>>>(GetDates);
        }

        /// <summary>
        /// Gets the tree nodes for the node with the given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>Tree nodes.</returns>
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
            foreach (var count in _count.Value)
            {
                var total = count.Value.Sum(month => month.Value);

                nodes.Add(CreateTreeNode(count.Key.ToString(CultureInfo.InvariantCulture), id, queryStrings, $"{count.Key.ToString(CultureInfo.InvariantCulture)} ({total})", string.Empty, total > 0));
            }

            return nodes;
        }

        private IDictionary<int, IDictionary<int, int>> GetDates()
        {
            return _entityProviderFactory.GetEntityProvider(typeof(T)).GetEntityCountByCreated();
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

                if (_count.Value[year].ContainsKey(month))
                {
                    total = _count.Value[year][month];
                }

                nodes.Add(CreateTreeNode($"{year}-{month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0')}", id, queryStrings, $"{DateTimeFormatInfo.InvariantInfo.GetMonthName(month)} ({total})", string.Empty, false));
            }

            return nodes;
        }
    }
}
