// <copyright file="CommentTreeController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Trees
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Formatting;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Services;
    using global::Umbraco.Web.Models.Trees;
    using global::Umbraco.Web.Mvc;
    using global::Umbraco.Web.Trees;
    using umbraco.BusinessLogic.Actions;

    /// <summary>
    /// The <see cref="CommentTreeController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]
    [Tree("uJetSocial", "comment", "Comments")]
    public class CommentTreeController : DateTreeController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentTreeController" /> class.
        /// </summary>
        /// <param name="localizedTextService">The localized text service.</param>
        public CommentTreeController(ILocalizedTextService localizedTextService)
            : base(localizedTextService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentTreeController" /> class.
        /// </summary>
        public CommentTreeController()
            : this(ApplicationContext.Current.Services.TextService)
        {
        }

        /// <summary>
        /// Gets the menu for the node with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="queryStrings">The query strings.</param>
        /// <returns>
        /// The menu.
        /// </returns>
        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            if (!IsRootNode(id))
            {
                return base.GetMenuForNode(id, queryStrings);
            }

            var menu = new MenuItemCollection();

            menu.Items.Add<ActionNew>(LocalizedTextService.Localize("Create"));
            menu.Items.Add<ActionRefresh>(LocalizedTextService.Localize("RefreshNode"), true);

            return menu;
        }

        /// <summary>
        /// Gets the dates.
        /// </summary>
        /// <returns>
        /// The dates.
        /// </returns>
        protected override IDictionary<int, IDictionary<int, int>> GetDates()
        {
            // TODO: Get dates.
            throw new NotImplementedException();
        }
    }
}
