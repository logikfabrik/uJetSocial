// <copyright file="IMediaProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Media
{
    /// <summary>
    /// The <see cref="IMediaProvider" /> interface.
    /// </summary>
    public interface IMediaProvider : IDataTransferObjectProvider<Media>
    {
        /// <summary>
        /// Gets the data transfer object with the specified media identifier.
        /// </summary>
        /// <param name="id">The media identifier.</param>
        /// <returns>The data transfer object with the specified media identifier.</returns>
        Media GetByMediaId(int id);
    }
}
