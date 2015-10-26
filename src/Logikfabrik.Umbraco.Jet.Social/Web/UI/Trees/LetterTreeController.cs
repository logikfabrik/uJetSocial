// <copyright file="LetterTreeController.cs" company="Logikfabrik">
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
    /// The <see cref="LetterTreeController" /> class. Abstract base class for letter structured Umbraco UI trees.
    /// </summary>
    public abstract class LetterTreeController : TreeController
    {
        private readonly Lazy<IDictionary<char, int>> _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetterTreeController" /> class.
        /// </summary>
        /// <param name="uiLanguageService">The UI language service.</param>
        protected LetterTreeController(IUILanguageService uiLanguageService)
            : base(uiLanguageService)
        {
            _count = new Lazy<IDictionary<char, int>>(GetCount);
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns>The count.</returns>
        protected abstract IDictionary<char, int> GetCount();

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

            var nodes = new TreeNodeCollection();
            var letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();
            int total;

            foreach (var letter in letters)
            {
                if (!_count.Value.ContainsKey(letter))
                {
                    nodes.Add(CreateTreeNode(letter.ToString(CultureInfo.InvariantCulture), id, new FormDataCollection((string)null), $"{letter} ({0})", string.Empty, false));
                }
                else
                {
                    total = _count.Value[letter];

                    nodes.Add(CreateTreeNode(letter.ToString(CultureInfo.InvariantCulture), id, new FormDataCollection((string)null), $"{letter} ({total})", string.Empty, false));
                }
            }

            total = _count.Value.Where(count => !letters.Contains(count.Key)).Sum(count => count.Value);

            if (total > 0)
            {
                nodes.Add(CreateTreeNode("Others", id, new FormDataCollection((string)null), $"{"Others"} ({total})", string.Empty, false));
            }

            return nodes;
        }
    }
}
