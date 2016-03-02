// <copyright file="APIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Web.Http.Controllers;
    using global::Umbraco.Web.Editors;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The <see cref="APIController" /> class.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public abstract class APIController : UmbracoAuthorizedJsonController
    {
        /// <summary>
        /// Initializes the <see cref="APIController" /> instance with the specified controller context.
        /// </summary>
        /// <param name="controllerContext">The <see cref="HttpControllerContext" /> object that is used for the initialization.</param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            SetCamelCaseContractResolver(controllerContext);
        }

        private static void SetCamelCaseContractResolver(HttpControllerContext controllerContext)
        {
            var formatters = controllerContext.Configuration.Formatters;

            var formatter = formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();

            if (formatter == null)
            {
                return;
            }

            formatters.Remove(formatter);

            formatters.Add(new JsonMediaTypeFormatter
            {
                SerializerSettings = { ContractResolver = new CamelCasePropertyNamesContractResolver() }
            });
        }
    }
}
