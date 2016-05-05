// <copyright file="ContentLookup.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Core.Persistence;
    using Jet.Web.Data;

    /// <summary>
    /// The <see cref="ContentLookup" /> class.
    /// </summary>
    public class ContentLookup : IContentLookup
    {
        private readonly IUmbracoHelperWrapper _umbracoHelper;
        private readonly Lazy<IDatabaseWrapper> _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentLookup" /> class.
        /// </summary>
        public ContentLookup()
            : this(DatabaseWrapperFactory.GetDatabase, new UmbracoHelperWrapper())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentLookup" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="umbracoHelper">The Umbraco helper.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="database" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="umbracoHelper" /> is <c>null</c>.</exception>
        public ContentLookup(Func<IDatabaseWrapper> database, IUmbracoHelperWrapper umbracoHelper)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            if (umbracoHelper == null)
            {
                throw new ArgumentNullException(nameof(umbracoHelper));
            }

            _database = new Lazy<IDatabaseWrapper>(database);
            _umbracoHelper = umbracoHelper;
        }

        /// <summary>
        /// Gets documents by selection criteria.
        /// </summary>
        /// <param name="xPath">The selection criteria.</param>
        /// <returns>The documents matching the selection criteria.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="xPath" /> is <c>null</c> or white space.</exception>
        public IEnumerable<IPublishedContent> GetDocumentsByXPath(string xPath)
        {
            if (string.IsNullOrWhiteSpace(xPath))
            {
                throw new ArgumentException("Selection criteria cannot be null or white space.", nameof(xPath));
            }

            var identifiers = GetNodeIdentifiers(UmbracoNodeObjectTypes.Document, xPath);

            return identifiers.Select(id => _umbracoHelper.TypedDocument(id));
        }

        /// <summary>
        /// Gets media by selection criteria.
        /// </summary>
        /// <param name="xPath">The selection criteria.</param>
        /// <returns>The media matching the selection criteria.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="xPath" /> is <c>null</c> or white space.</exception>
        public IEnumerable<IPublishedContent> GetMediaByXPath(string xPath)
        {
            if (string.IsNullOrWhiteSpace(xPath))
            {
                throw new ArgumentException("Selection criteria cannot be null or white space.", nameof(xPath));
            }

            var identifiers = GetNodeIdentifiers(UmbracoNodeObjectTypes.Media, xPath);

            return identifiers.Select(id => _umbracoHelper.TypedMedia(id));
        }

        /// <summary>
        /// Gets members by selection criteria.
        /// </summary>
        /// <param name="xPath">The selection criteria.</param>
        /// <returns>The members matching the selection criteria.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="xPath" /> is <c>null</c> or white space.</exception>
        public IEnumerable<IPublishedContent> GetMembersByXPath(string xPath)
        {
            if (string.IsNullOrWhiteSpace(xPath))
            {
                throw new ArgumentException("Selection criteria cannot be null or white space.", nameof(xPath));
            }

            var identifiers = GetNodeIdentifiers(UmbracoNodeObjectTypes.Member, xPath);

            return identifiers.Select(id => _umbracoHelper.TypedMember(id));
        }

        private IEnumerable<int> GetNodeIdentifiers(string umbracoNodeObjectType, string xPath)
        {
            var xml = GetPublishedXml(umbracoNodeObjectType);

            // TODO: Find the bug in this code. Will produce 0 hits.
            var iterator = xml.CreateNavigator().Select(xPath);

            while (iterator.MoveNext())
            {
                var id = iterator.Current.Evaluate("string(@id)") as string;

                if (id == null)
                {
                    continue;
                }

                yield return int.Parse(id);
            }
        }

        private XmlDocument GetPublishedXml(string umbracoNodeObjectType)
        {
            var xml = new XmlDocument();

            xml.AppendChild(xml.CreateElement("nodes"));

            var builder = new StringBuilder();

            foreach (var row in _database.Value.Fetch<dynamic>(new Sql("SELECT xml FROM cmsContentXml WHERE nodeId IN (SELECT id FROM umbracoNode WHERE nodeObjectType = @nodeObjectType)", new { nodeObjectType = Guid.Parse(umbracoNodeObjectType) })))
            {
                builder.Append(row.xml);
            }

            xml.FirstChild.InnerXml = builder.ToString();

            return xml;
        }
    }
}
