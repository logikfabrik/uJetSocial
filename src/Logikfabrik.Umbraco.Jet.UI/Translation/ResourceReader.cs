// <copyright file="ResourceReader.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The <see cref="ResourceReader" /> class.
    /// </summary>
    public static class ResourceReader
    {
        /// <summary>
        /// Gets a list of all embedded resources.
        /// </summary>
        /// <param name="assembly">The assembly to list resources for.</param>
        /// <returns>A list of resource names.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="assembly" /> is <c>null</c>.</exception>
        public static IEnumerable<string> GetResourceNames(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            return assembly.GetManifestResourceNames();
        }

        /// <summary>
        /// Gets a list of all embedded resources matching the given pattern.
        /// </summary>
        /// <param name="assembly">The assembly to list resources for.</param>
        /// <param name="pattern">The pattern to match.</param>
        /// <returns>A list of resource names.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="assembly" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="pattern" /> is <c>null</c> or white space.</exception>
        public static IEnumerable<string> GetResourceNames(Assembly assembly, string pattern)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentException("Pattern cannot be null or white space.", nameof(pattern));
            }

            var regex = new Regex(pattern);

            return GetResourceNames(assembly).Where(name => regex.IsMatch(name));
        }

        /// <summary>
        /// Reads an assembly embedded resource.
        /// </summary>
        /// <param name="assembly">The assembly to read from.</param>
        /// <param name="resourceName">The name of the resource to read.</param>
        /// <returns>A resource stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="assembly" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="resourceName" /> is <c>null</c> or white space.</exception>
        public static Stream Read(Assembly assembly, string resourceName)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                throw new ArgumentException("Resource name cannot be null or white space.", nameof(resourceName));
            }

            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}
