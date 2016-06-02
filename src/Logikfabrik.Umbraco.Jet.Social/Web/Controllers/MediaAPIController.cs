// <copyright file="MediaAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Media;

    /// <summary>
    /// The <see cref="MediaAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class MediaAPIController : DataTransferObjectAPIController<Media>
    {
        [HttpGet]
        public Media GetByMediaId(int id)
        {
            var provider = (IMediaProvider)Provider;

            var media = provider.GetByUmbracoId(id);

            return media ?? provider.Add(new Media { MediaId = id });
        }
    }
}
