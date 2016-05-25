// <copyright file="TreeController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Trees
{
    using System;
    using System.Globalization;
    using System.Net.Http.Formatting;
    using System.Reflection;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Core.Services;
    using global::Umbraco.Web.Models.Trees;
    using global::Umbraco.Web.Trees;

    /// <summary>
    /// The <see cref="TreeController" /> class.
    /// </summary>
    public abstract class TreeController : global::Umbraco.Web.Trees.TreeController
    {
        private readonly ILocalizedTextService _localizedTextService;

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

            _localizedTextService = localizedTextService;

            RootNodeRendering += OnRootNodeRendering;
        }

        /// <summary>
        /// Gets the root node display name.
        /// </summary>
        public override string RootNodeDisplayName => Localize($"{TreeApplicationAlias}/{TreeAlias}Tree");

        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has children; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool HasChildren => true;

        /// <summary>
        /// Gets the child icon.
        /// </summary>
        /// <value>
        /// The child icon.
        /// </value>
        protected virtual string ChildIcon => string.Empty;

        /// <summary>
        /// Gets the root icon.
        /// </summary>
        /// <value>
        /// The root icon.
        /// </value>
        protected virtual string RootIcon => string.Empty;

        /// <summary>
        /// Gets the tree application alias.
        /// </summary>
        /// <value>
        /// The tree application alias.
        /// </value>
        protected string TreeApplicationAlias
        {
            get
            {
                var attr = GetType().GetCustomAttribute<TreeAttribute>();

                return attr?.ApplicationAlias;
            }
        }

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

        /// <summary>
        /// Gets the tree nodes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>The tree nodes.</returns>
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            return new TreeNodeCollection();
        }

        /// <summary>
        /// Localizes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The specified key localized.</returns>
        protected string Localize(string key)
        {
            return _localizedTextService.Localize(key, GetUICulture());
        }

        private string GetRoutePath()
        {
            return $"{TreeApplicationAlias}/{TreeAlias}/dashboard/-1";
        }

        /// <summary>
        /// Gets the UI culture for the current user.
        /// </summary>
        /// <returns>The UI culture for the current user.</returns>
        private CultureInfo GetUICulture()
        {
            return Security.CurrentUser.GetUserCulture(_localizedTextService);
        }

        private void OnRootNodeRendering(TreeControllerBase sender, TreeNodeRenderingEventArgs e)
        {
            if (sender != this)
            {
                return;
            }

            if (!string.IsNullOrEmpty(RootIcon))
            {
                e.Node.Icon = RootIcon;
            }

            e.Node.RoutePath = GetRoutePath();

            if (HasChildren)
            {
                return;
            }

            e.Node.HasChildren = false;
        }
    }
}