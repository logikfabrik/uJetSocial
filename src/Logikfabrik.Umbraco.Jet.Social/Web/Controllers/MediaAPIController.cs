// <copyright file="MediaAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Jet.Web.Data;
    using Media;
    using Models;
    using Models.Querying;
    using Utilities;

    /// <summary>
    /// The <see cref="MediaAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class MediaAPIController : DataTransferObjectAPIController<Media>
    {
        private readonly IUmbracoHelperWrapper _umbracoHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaAPIController" /> class.
        /// </summary>
        public MediaAPIController()
            : this(new UmbracoHelperWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaAPIController" /> class.
        /// </summary>
        /// <param name="umbracoHelper">The Umbraco helper.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="umbracoHelper" /> is <c>null</c>.</exception>
        public MediaAPIController(IUmbracoHelperWrapper umbracoHelper)
        {
            if (umbracoHelper == null)
            {
                throw new ArgumentNullException(nameof(umbracoHelper));
            }

            _umbracoHelper = umbracoHelper;
        }

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
                Objects = result.Objects.Select(GetModel)
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

            return GetModel(media ?? provider.Add(new Media { MediaId = id }));
        }

        /// <summary>
        /// Gets a model for the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object.</param>
        /// <returns>A model for the specified data transfer object.</returns>
        protected override Media GetModel(Media dto)
        {
            var model = base.GetModel(dto);

            if (model == null)
            {
                return null;
            }

            var content = _umbracoHelper.TypedMedia(model.MediaId);

            var meta = new MetaMedia
            {
                Id = model.Id,
                Created = model.Created,
                Updated = model.Updated,
                Status = model.Status,
                MediaId = model.MediaId,
                Name = content.Name,
                Url = PublishedContentUtilities.GetUrl(content)
            };

            return meta;
        }
    }
}
