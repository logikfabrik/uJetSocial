// <copyright file="PublishedContentUtilities.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Utilities
{
    using System;
    using global::Umbraco.Core.Models;

    /// <summary>
    /// The <see cref="PublishedContentUtilities" /> class. Utilities for working with <see cref="IPublishedContent" />.
    /// </summary>
    public static class PublishedContentUtilities
    {
        /// <summary>
        /// Gets the URL for the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>The URL for the specified content.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="content" /> is <c>null</c>.</exception>
        public static string GetUrl(IPublishedContent content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (content.DocumentTypeId == (int)ContentTypes.Folder)
            {
                return null;
            }

            try
            {
                return content.Url;
            }
            catch (NotSupportedException)
            {
                // This is just a precaution. Url is not accessible for folders, and might not be accessible for other types too.
            }

            return null;
        }
    }
}
