﻿// <copyright file="GroupTreeController.cs" company="Logikfabrik">
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
    /// The <see cref="GroupTreeController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]
    [Tree("uJetSocial", "ujetGroup", "Groups")]
    public class GroupTreeController : LetterTreeController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        public GroupTreeController(ILocalizedTextService localizedTextService)
            : base(localizedTextService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupTreeController" /> class.
        /// </summary>
        public GroupTreeController()
            : this(ApplicationContext.Current.Services.TextService)
        {
        }

        /// <summary>
        /// Gets the child icon.
        /// </summary>
        /// <value>
        /// The child icon.
        /// </value>
        protected override string ChildIcon => "icon-users";

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

            menu.Items.Add<ActionNew>(Localize($"{TreeApplicationAlias}/newAction"));
            menu.Items.Add<ActionRefresh>(Localize($"{TreeApplicationAlias}/refreshAction"), true);

            return menu;
        }
    }
}
