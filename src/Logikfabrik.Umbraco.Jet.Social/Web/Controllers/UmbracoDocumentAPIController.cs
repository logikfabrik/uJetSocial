// <copyright file="UmbracoDocumentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Models;

    /// <summary>
    /// The <see cref="UmbracoDocumentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class UmbracoDocumentAPIController : APIController
    {
        [HttpPost]
        public IEnumerable<UmbracoDocument> Query(string name)
        {
            // TODO: Implement logic.
            return new[]
            {
                new UmbracoDocument { Name = "Name 1" },
                new UmbracoDocument { Name = "Name 2" },
                new UmbracoDocument { Name = "Name 3" },
                new UmbracoDocument { Name = "Name 4" },
                new UmbracoDocument { Name = "Name 5" }
            };
        }
    }
}
