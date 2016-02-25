// <copyright file="LanguageFile.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System;
    using System.IO;

    /// <summary>
    /// The <see cref="LanguageFile" /> class.
    /// </summary>
    public class LanguageFile : File
    {
        private readonly string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageFile" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="path" /> is <c>null</c> or white space.</exception>
        public LanguageFile(string path)
            : base(GetStream(path))
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path cannot be null or white space.", nameof(path));
            }

            _path = path;
        }

        /// <summary>
        /// Gets a stream for the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>A stream for the specified path.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="path" /> is <c>null</c> or white space.</exception>
        public static Stream GetStream(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path cannot be null or white space.", nameof(path));
            }

            var copy = new MemoryStream();

            using (var stream = System.IO.File.OpenRead(path))
            {
                stream.CopyTo(copy);
                copy.Position = 0;
            }

            return copy;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            Xml.Save(_path);
        }
    }
}
