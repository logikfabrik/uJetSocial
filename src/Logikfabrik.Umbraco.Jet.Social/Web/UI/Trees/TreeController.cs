// <copyright file="TreeController.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Trees
{
    using System;
    using System.Net.Http.Formatting;
    using global::Umbraco.Web.Models.Trees;
    using Globalization.Localization;

    /// <summary>
    /// The <see cref="TreeController" /> class. Abstract base class for Umbraco UI trees.
    /// </summary>
    public abstract class TreeController : global::Umbraco.Web.Trees.TreeController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeController" /> class.
        /// </summary>
        /// <param name="uiLanguageService">The UI language service.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="uiLanguageService" /> is <c>null</c>.</exception>
        protected TreeController(IUILanguageService uiLanguageService)
        {
            if (uiLanguageService == null)
            {
                throw new ArgumentNullException(nameof(uiLanguageService));
            }

            UILanguageService = uiLanguageService;
        }

        /// <summary>
        /// The root node display name.
        /// </summary>
        public override string RootNodeDisplayName => UILanguageService.GetText("treeHeaders", TreeAlias);

        /// <summary>
        /// Gets the UI language service.
        /// </summary>
        /// <value>
        /// The UI language service.
        /// </value>
        protected IUILanguageService UILanguageService { get; }

        /// <summary>
        /// Determines whether the node with the specified identifier is the root node.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if the node with the specified identifier is the root node; otherwise, <c>false</c>.</returns>
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
        /// <returns>A menu.</returns>
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            return new MenuItemCollection();
        }
    }
}