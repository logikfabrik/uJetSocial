// <copyright file="File.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.UI.Translation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// The <see cref="File" /> class.
    /// </summary>
    public abstract class File
    {
        private readonly Lazy<XmlDocument> _document;
        private readonly Lazy<bool> _valid;

        /// <summary>
        /// Initializes a new instance of the <see cref="File" /> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="stream" /> is <c>null</c>.</exception>
        protected File(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            _document = new Lazy<XmlDocument>(() =>
            {
                var xml = new XmlDocument();

                xml.Load(stream);

                return xml;
            });

            _valid = new Lazy<bool>(() =>
            {
                var valid = true;

                var xml = _document.Value;

                xml.Schemas.Add(GetSchema());
                xml.Validate((sender, args) => { valid = false; });

                return valid;
            });
        }

        /// <summary>
        /// Gets a value indicating whether this is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        public bool Valid => _valid.Value;

        /// <summary>
        /// Gets the XML.
        /// </summary>
        /// <value>
        /// The XML.
        /// </value>
        protected XmlDocument Xml => _document.Value;

        /// <summary>
        /// Inserts a key.
        /// </summary>
        /// <param name="area">The area to insert the key into.</param>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The key value to insert.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="area" /> is <c>null</c> or white space.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="key" /> is <c>null</c> or white space.</exception>
        public void InsertKey(string area, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(area))
            {
                throw new ArgumentException("Area cannot be null or white space.", nameof(area));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be null or white space.", nameof(key));
            }

            var node = Xml.SelectSingleNode($"//area[@alias='{area}']//key[@alias='{key}']");

            if (node != null)
            {
                node.InnerText = value;

                return;
            }

            node = InsertArea(area).AppendChild(Xml.CreateNode(XmlNodeType.Element, "key", null));

            if (node.Attributes == null)
            {
                return;
            }

            var attribute = node.Attributes.Append(Xml.CreateAttribute("alias"));

            attribute.InnerText = key;
            node.InnerText = value;
        }

        /// <summary>
        /// Gets the language file alias.
        /// </summary>
        /// <returns>The language file alias.</returns>
        public string GetAlias()
        {
            var node = Xml.SelectSingleNode("//language/@alias");

            return node?.Value;
        }

        /// <summary>
        /// Gets all language file areas.
        /// </summary>
        /// <returns>All language file areas.</returns>
        public IEnumerable<string> GetAreas()
        {
            var nodes = Xml.SelectNodes("//area/@alias");

            return nodes?.Cast<XmlNode>().Select(node => node.Value) ?? new string[] { };
        }

        /// <summary>
        /// Gets all keys in the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>All keys in the specified area.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="area" /> is <c>null</c> or white space.</exception>
        public IDictionary<string, string> GetKeys(string area)
        {
            if (string.IsNullOrWhiteSpace(area))
            {
                throw new ArgumentException("Area cannot be null or white space.", nameof(area));
            }

            var nodes = Xml.SelectNodes($"//area[@alias='{area}']//key");

            if (nodes == null)
            {
                return new Dictionary<string, string>();
            }

            var keys = new Dictionary<string, string>();

            foreach (var node in nodes.Cast<XmlNode>())
            {
                var attribute = node.Attributes?.GetNamedItem("alias");

                if (attribute == null)
                {
                    continue;
                }

                keys.Add(attribute.Value, node.InnerText);
            }

            return keys;
        }

        /// <summary>
        /// Inserts the area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The inserted area.</returns>
        private XmlNode InsertArea(string area)
        {
            var node = Xml.SelectSingleNode($"//area[@alias='{area}']");

            if (node != null)
            {
                return node;
            }

            // ReSharper disable once PossibleNullReferenceException
            node = Xml.DocumentElement.AppendChild(Xml.CreateNode(XmlNodeType.Element, "area", null));

            if (node.Attributes == null)
            {
                return node;
            }

            var attribute = node.Attributes.Append(Xml.CreateAttribute("alias"));

            attribute.InnerText = area;

            return node;
        }

        private XmlSchema GetSchema()
        {
            using (var stream = ResourceReader.Read(GetType().Assembly, "Logikfabrik.Umbraco.Jet.UI.Translation.Schema.xsd"))
            {
                return XmlSchema.Read(stream, (sender, args) => { });
            }
        }
    }
}
