// <copyright file="ContentLookupExpressionBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Xml.XPath;

    /// <summary>
    /// The <see cref="ContentLookupExpressionBuilder" /> class.
    /// </summary>
    public class ContentLookupExpressionBuilder
    {
        /// <summary>
        /// Creates an expression for selecting by the specified attribute.
        /// </summary>
        /// <param name="attribute">The attribute to select by.</param>
        /// <param name="value">The value to match.</param>
        /// <returns>An expression.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="attribute" /> is <c>null</c> or white space.</exception>
        public XPathExpression SelectByAttribute(string attribute, string value)
        {
            if (string.IsNullOrWhiteSpace(attribute))
            {
                throw new ArgumentException("Attribute cannot be null or white space.", nameof(attribute));
            }

            var expression = XPathExpression.Compile(string.IsNullOrWhiteSpace(value)
                ? $"//*[@{attribute}]"
                : $"//*[contains(translate(@{attribute}, '{value.ToUpper()}', '{value.ToLower()}'),'{value.ToLower()}')]");

            return expression;
        }

        /// <summary>
        /// Creates an expression for selecting, sorted by the specified attribute.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="attribute">The attribute to sort by.</param>
        /// <param name="dataType">The attribute data type.</param>
        /// <returns>An expression.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="expression" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="attribute" /> is <c>null</c> or white space.</exception>
        public XPathExpression SortByAttribute(XPathExpression expression, string attribute, XmlDataType dataType)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (string.IsNullOrWhiteSpace(attribute))
            {
                throw new ArgumentException("Attribute cannot be null or white space.", nameof(attribute));
            }

            expression.AddSort($"@{attribute}", XmlSortOrder.Ascending, XmlCaseOrder.None, string.Empty, XmlDataType.Text);

            return expression;
        }
    }
}
