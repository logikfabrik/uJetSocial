// <copyright file="LetterTreeController.cs" company="Logikfabrik">
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
    /// The <see cref="LetterTreeController" /> class.
    /// </summary>
    public abstract class LetterTreeController : TreeController
    {
        private readonly Lazy<IDictionary<char, int>> _letters;

        /// <summary>
        /// Initializes a new instance of the <see cref="LetterTreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        protected LetterTreeController(ILocalizedTextService localizedTextService)
            : base(localizedTextService)
        {
            _letters = new Lazy<IDictionary<char, int>>(GetLetters);
        }

        /// <summary>
        /// Gets the letters.
        /// </summary>
        /// <returns>The letters.</returns>
        protected abstract IDictionary<char, int> GetLetters();

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

            var nodes = new TreeNodeCollection();
            var letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();
            int total;

            foreach (var letter in letters)
            {
                if (!_letters.Value.ContainsKey(letter))
                {
                    nodes.Add(CreateTreeNode(letter.ToString(CultureInfo.InvariantCulture), id, new FormDataCollection((string)null), $"{letter} ({0})", string.Empty, false));
                }
                else
                {
                    total = _letters.Value[letter];

                    nodes.Add(CreateTreeNode(letter.ToString(CultureInfo.InvariantCulture), id, new FormDataCollection((string)null), $"{letter} ({total})", string.Empty, false));
                }
            }

            total = _letters.Value.Where(count => !letters.Contains(count.Key)).Sum(count => count.Value);

            if (total > 0)
            {
                nodes.Add(CreateTreeNode("Others", id, new FormDataCollection((string)null), $"{"Others"} ({total})", string.Empty, false));
            }

            return nodes;
        }
    }
}
