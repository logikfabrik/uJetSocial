// <copyright file="LanguageDirectory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The <see cref="LanguageDirectory" /> class.
    /// </summary>
    public class LanguageDirectory
    {
        private readonly Lazy<IEnumerable<LanguageFile>> _languageFiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageDirectory" /> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="path" /> is <c>null</c> or white space.</exception>
        public LanguageDirectory(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path cannot be null or white space.", nameof(path));
            }

            _languageFiles = new Lazy<IEnumerable<LanguageFile>>(() => Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly).Select(file => new LanguageFile(file)));
        }

        /// <summary>
        /// Gets all language files in the directory.
        /// </summary>
        /// <returns>All language files in the directory.</returns>
        public IEnumerable<LanguageFile> GetFiles()
        {
            return _languageFiles.Value;
        }
    }
}
