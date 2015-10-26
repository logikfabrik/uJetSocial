// <copyright file="ReportsTreeController.cs" company="Logikfabrik">
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
    /// The <see cref="ReportsTreeController" /> class. Umbraco UI tree for <see cref="Report.Report" />.
    /// </summary>
    [PluginController("uJetCommunity")]
    [Tree("uJetCommunity", "report", "Reports")]
    public class ReportsTreeController : CreatedTreeController<Report.Report>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsTreeController" /> class.
        /// </summary>
        /// <param name="uiLanguageService">The UI language service.</param>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        public ReportsTreeController(IUILanguageService uiLanguageService, IEntityProviderFactory entityProviderFactory)
            : base(uiLanguageService, entityProviderFactory)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportsTreeController" /> class.
        /// </summary>
        public ReportsTreeController()
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
