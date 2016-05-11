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
    using System.Xml.XPath;
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
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The documents matching the selection criteria.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="expression" /> is <c>null</c></exception>
        public IEnumerable<IPublishedContent> GetDocumentsByXPath(XPathExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var identifiers = GetNodeIdentifiers(UmbracoNodeObjectTypes.Document, expression);

            return identifiers.Select(id => _umbracoHelper.TypedDocument(id));
        }

        /// <summary>
        /// Gets media by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The media matching the selection criteria.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="expression" /> is <c>null</c></exception>
        public IEnumerable<IPublishedContent> GetMediaByXPath(XPathExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var identifiers = GetNodeIdentifiers(UmbracoNodeObjectTypes.Media, expression);

            return identifiers.Select(id => _umbracoHelper.TypedMedia(id));
        }

        /// <summary>
        /// Gets members by selection criteria.
        /// </summary>
        /// <param name="expression">The selection criteria.</param>
        /// <returns>The members matching the selection criteria.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="expression" /> is <c>null</c></exception>
        public IEnumerable<IPublishedContent> GetMembersByXPath(XPathExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var identifiers = GetNodeIdentifiers(UmbracoNodeObjectTypes.Member, expression);

            return identifiers.Select(id => _umbracoHelper.TypedMember(id));
        }

        private IEnumerable<int> GetNodeIdentifiers(string umbracoNodeObjectType, XPathExpression expression)
        {
            var xml = GetPublishedXml(umbracoNodeObjectType);

            var iterator = xml.CreateNavigator().Select(expression);

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
            var builder = new StringBuilder();

            builder.Append("<nodes>");

            foreach (var row in _database.Value.Fetch<dynamic>(new Sql("SELECT xml FROM cmsContentXml WHERE nodeId IN (SELECT id FROM umbracoNode WHERE nodeObjectType = @nodeObjectType)", new { nodeObjectType = Guid.Parse(umbracoNodeObjectType) })))
            {
                builder.Append(row.xml);
            }

            builder.Append("</nodes>");

            var xml = new XmlDocument();

            xml.LoadXml(builder.ToString());

            return xml;
        }
    }
}
