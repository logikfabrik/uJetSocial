// <copyright file="CommentsTreeController.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.UI.Trees
{
    using System.Net.Http.Formatting;
    using global::Umbraco.Web.Models.Trees;
    using global::Umbraco.Web.Mvc;
    using Globalization;
    using Globalization.Localization;
    using umbraco.businesslogic;
    using umbraco.BusinessLogic.Actions;

    /// <summary>
    /// The <see cref="CommentsTreeController" /> class. Umbraco UI tree for <see cref="Comment.Comment" />.
    /// </summary>
    [PluginController("uJetSocial")]
    [Tree("uJetSocial", "comment", "Comments")]
    public class CommentsTreeController : CreatedTreeController<Comment.Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsTreeController"/> class.
        /// </summary>
        /// <param name="uiLanguageService">The UI language service.</param>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        public CommentsTreeController(IUILanguageService uiLanguageService, IEntityProviderFactory entityProviderFactory)
            : base(uiLanguageService, entityProviderFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsTreeController" /> class.
        /// </summary>
        public CommentsTreeController()
            : this(new UILanguageService(), EntityProviderFactory.Instance)
        {
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
