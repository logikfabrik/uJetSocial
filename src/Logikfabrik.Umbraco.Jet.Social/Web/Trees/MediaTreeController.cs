﻿// <copyright file="MediaTreeController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Trees
{
    using System.Net.Http.Formatting;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Services;
    using global::Umbraco.Web.Models.Trees;
    using global::Umbraco.Web.Mvc;
    using global::Umbraco.Web.Trees;
    using umbraco.BusinessLogic.Actions;

    /// <summary>
    /// The <see cref="MediaTreeController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]
    [Tree("uJetSocial", "ujetMedia", "Media")]
    public class MediaTreeController : TreeController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        public MediaTreeController(ILocalizedTextService localizedTextService)
            : base(localizedTextService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTreeController" /> class.
        /// </summary>
        public MediaTreeController()
            : this(ApplicationContext.Current.Services.TextService)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has children; otherwise, <c>false</c>.
        /// </value>
        protected override bool HasChildren => false;

        /// <summary>
        /// Gets the menu for the node with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>The menu.</returns>
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            if (!IsRootNode(id))
            {
                return base.GetMenuForNode(id, queryStrings);
            }

            var menu = new MenuItemCollection();

            menu.Items.Add<ActionRefresh>(Localize($"{TreeApplicationAlias}/refreshAction"), false);

            return menu;
        }
    }
}
