// <copyright file="LanguageInstaller.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System;
    using System.Linq;

    /// <summary>
    /// The <see cref="LanguageInstaller" /> class.
    /// </summary>
    public class LanguageInstaller
    {
        private readonly LanguageDirectory _languageDirectory;
        private readonly ResourceDirectory _resourceDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageInstaller" /> class.
        /// </summary>
        /// <param name="languageDirectory">The language directory.</param>
        /// <param name="resourceDirectory">The resource directory.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="languageDirectory" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="resourceDirectory" /> is <c>null</c>.</exception>
        public LanguageInstaller(LanguageDirectory languageDirectory, ResourceDirectory resourceDirectory)
        {
            if (languageDirectory == null)
            {
                throw new ArgumentNullException(nameof(languageDirectory));
            }

            if (resourceDirectory == null)
            {
                throw new ArgumentNullException(nameof(resourceDirectory));
            }

            _languageDirectory = languageDirectory;
            _resourceDirectory = resourceDirectory;
        }

        /// <summary>
        /// Installs all language files in the resource directory.
        /// </summary>
        public void Install()
        {
            var languageFiles = _languageDirectory.GetFiles();

            foreach (var languageFile in languageFiles)
            {
                var resourceFile = GetResourceFile(languageFile.GetAlias());

                if (resourceFile == null)
                {
                    continue;
                }

                InstallLanguage(languageFile, resourceFile);
            }
        }

        private ResourceFile GetResourceFile(string alias)
        {
            var files = _resourceDirectory.GetFiles();

            return files.SingleOrDefault(f => f.GetAlias().Equals(alias, StringComparison.InvariantCultureIgnoreCase));
        }

        private void InstallLanguage(LanguageFile languageFile, File resourceFile)
        {
            foreach (var area in resourceFile.GetAreas())
            {
                var keys = resourceFile.GetKeys(area);

                foreach (var key in keys)
                {
                    languageFile.InsertKey(area, key.Key, key.Value);
                }
            }

            languageFile.Save();
        }
    }
}