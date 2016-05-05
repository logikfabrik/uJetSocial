// <copyright file="UmbracoDocumentAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Models;
    using Models.Querying;

    /// <summary>
    /// The <see cref="UmbracoDocumentAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class UmbracoDocumentAPIController : APIController
    {
        [HttpPost]
        public QueryResult<UmbracoDocument> Query(UmbracoQuery query)
        {
            // TODO: Implement logic.
            var items = new[]
            {
                new UmbracoDocument { Name = "Name 1" },
                new UmbracoDocument { Name = "Name 2" },
                new UmbracoDocument { Name = "Name 3" },
                new UmbracoDocument { Name = "Name 4" },
                new UmbracoDocument { Name = "Name 5" }
            };

            return new QueryResult<UmbracoDocument>
            {
                Objects = items,
                Total = items.Length
            };
        }
    }
}
