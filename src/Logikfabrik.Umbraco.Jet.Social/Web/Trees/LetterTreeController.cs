﻿// <copyright file="LetterTreeController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Trees
{
    using System;
    using System.Linq;
    using System.Net.Http.Formatting;
    using global::Umbraco.Core.Services;
    using global::Umbraco.Web.Models.Trees;

    /// <summary>
    /// The <see cref="LetterTreeController" /> class.
    /// </summary>
    public abstract class LetterTreeController : TreeController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LetterTreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        protected LetterTreeController(ILocalizedTextService localizedTextService)
            : base(localizedTextService)
        {
        }

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

            var letters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => ((char)i).ToString()).ToList();

            letters.Add("...");

            var nodes = new TreeNodeCollection();

            nodes.AddRange(letters.Select(letter => CreateTreeNode(letter, id, new FormDataCollection((string)null), letter, ChildIcon, false)));

            return nodes;
        }
    }
}
