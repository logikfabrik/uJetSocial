// <copyright file="MediaProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Media
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="MediaProvider" /> class.
    /// </summary>
    public class MediaProvider : DataTransferObjectProvider<Media>, IMediaProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public MediaProvider(Func<IDatabaseWrapper> database)
            : base(database)
        {
        }

        /// <summary>
        /// Gets the data transfer object with the specified Umbraco identifier.
        /// </summary>
        /// <param name="id">The Umbraco identifier.</param>
        /// <returns>The data transfer object with the specified Umbraco identifier.</returns>
        public Media GetByUmbracoId(int id)
        {
            var query = new Query<Media>(0, int.MaxValue);

            query.Criterias.Add(media => media.MediaId == id);

            var objects = Query(query).Objects;

            return objects.SingleOrDefault();
        }
    }
}