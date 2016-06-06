// <copyright file="MediaAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Media;
    using Models.Querying;

    /// <summary>
    /// The <see cref="MediaAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class MediaAPIController : DataTransferObjectAPIController<Media>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="Media" />.</returns>
        [HttpPost]
        public QueryResult<Media> Query(MediaQuery query)
        {
            var q = GetQuery(query);

            if (query.MediaId.HasValue)
            {
                q.Criterias.Add(obj => obj.MediaId == query.MediaId.Value);
            }

            var result = Provider.Query(q);

            return new QueryResult<Media>
            {
                Total = result.Total,
                Objects = result.Objects
            };
        }

        /// <summary>
        /// Gets the media with the specified Umbraco identifier, or create one if one does not exist.
        /// </summary>
        /// <param name="id">The Umbraco media identifier.</param>
        /// <returns>The media.</returns>
        [HttpGet]
        public Media GetByMediaId(int id)
        {
            var provider = (IMediaProvider)Provider;

            var media = provider.GetByUmbracoId(id);

            return media ?? provider.Add(new Media { MediaId = id });
        }
    }
}
