// <copyright file="ResourceDirectory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The <see cref="ResourceDirectory" /> class.
    /// </summary>
    public class ResourceDirectory
    {
        private readonly Lazy<IEnumerable<ResourceFile>> _resourceFiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDirectory" /> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="namespace">The namespace.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="assembly" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="namespace" /> is <c>null</c> or white space.</exception>
        public ResourceDirectory(Assembly assembly, string @namespace)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (string.IsNullOrWhiteSpace(@namespace))
            {
                throw new ArgumentException("Namespace cannot be null or white space.", nameof(@namespace));
            }

            _resourceFiles = new Lazy<IEnumerable<ResourceFile>>(() =>
            {
                var pattern = string.Concat(@namespace, ".+.xml");

                return ResourceReader.GetResourceNames(assembly, pattern).Select(name => new ResourceFile(ResourceReader.Read(assembly, name)));
            });
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns>The files.</returns>
        public IEnumerable<ResourceFile> GetFiles()
        {
            return _resourceFiles.Value;
        }
    }
}
