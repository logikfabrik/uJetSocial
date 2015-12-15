// <copyright file="TreeController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Trees
{
    using System;
    using System.Net.Http.Formatting;
    using global::Umbraco.Core.Services;
    using global::Umbraco.Web.Models.Trees;

    /// <summary>
    /// The <see cref="TreeController" /> class.
    /// </summary>
    public abstract class TreeController : global::Umbraco.Web.Trees.TreeController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="localizedTextService" /> is <c>null</c>.</exception>
        protected TreeController(ILocalizedTextService localizedTextService)
        {
            if (localizedTextService == null)
            {
                throw new ArgumentNullException(nameof(localizedTextService));
            }

            LocalizedTextService = localizedTextService;
        }

        /// <summary>
        /// Gets the root node display name.
        /// </summary>
        public override string RootNodeDisplayName => LocalizedTextService.Localize(TreeAlias);

        /// <summary>
        /// Gets the localized text service.
        /// </summary>
        /// <value>
        /// The localized text service.
        /// </value>
        protected ILocalizedTextService LocalizedTextService { get; }

        /// <summary>
        /// Determines whether the node with the specified identifier is the root node.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if the node with the specified identifier is the root node; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="id" /> is <c>null</c> or white space.</exception>
        protected bool IsRootNode(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or white space.", nameof(id));
            }

            int result;

            if (!int.TryParse(id, out result))
            {
                return false;
            }

            return result == global::Umbraco.Core.Constants.System.Root;
        }

        /// <summary>
        /// Gets the menu for the node with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>The menu.</returns>
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            return new MenuItemCollection();
        }
    }
}