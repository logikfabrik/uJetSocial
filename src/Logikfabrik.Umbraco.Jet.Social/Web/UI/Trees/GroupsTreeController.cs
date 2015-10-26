// <copyright file="GroupsTreeController.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Formatting;
    using global::Umbraco.Web.Models.Trees;
    using global::Umbraco.Web.Mvc;
    using Globalization;
    using Globalization.Localization;
    using Group;
    using umbraco.businesslogic;
    using umbraco.BusinessLogic.Actions;

    /// <summary>
    /// The <see cref="GroupsTreeController" /> class. Umbraco UI tree for <see cref="Group" />.
    /// </summary>
    [PluginController("uJetCommunity")]
    [Tree("uJetCommunity", "group", "Groups")]
    public class GroupsTreeController : LetterTreeController
    {
        private readonly IEntityProviderFactory _entityProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsTreeController" /> class.
        /// </summary>
        public GroupsTreeController()
            : this(new UILanguageService(), EntityProviderFactory.Instance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupsTreeController" /> class.
        /// </summary>
        /// <param name="uiLanguageService">The UI language service.</param>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="entityProviderFactory" /> is <c>null</c>.</exception>
        public GroupsTreeController(IUILanguageService uiLanguageService, IEntityProviderFactory entityProviderFactory)
            : base(uiLanguageService)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            _entityProviderFactory = entityProviderFactory;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <returns>
        /// The count.
        /// </returns>
        protected override IDictionary<char, int> GetCount()
        {
            return ((GroupProvider)_entityProviderFactory.GetEntityProvider(typeof(Group))).GetEntityCountByName();
        }

        /// <summary>
        /// Gets the menu for the node with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>
        /// A menu.
        /// </returns>
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            if (!IsRootNode(id))
            {
                return base.GetMenuForNode(id, queryStrings);
            }

            var menu = new MenuItemCollection();

            menu.Items.Add<ActionNew>(UILanguageService.GetText(Areas.Actions, Keys.Create));
            menu.Items.Add<ActionRefresh>(UILanguageService.GetText(Areas.Actions, Keys.RefreshNode), true);

            return menu;
        }
    }
}
