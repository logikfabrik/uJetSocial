// <copyright file="ResourceFile.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System.IO;

    /// <summary>
    /// The <see cref="ResourceFile" /> class.
    /// </summary>
    public class ResourceFile : File
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceFile" /> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public ResourceFile(Stream stream)
            : base(stream)
        {
        }
    }
}
