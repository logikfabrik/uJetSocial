// <copyright file="UILanguageService.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Globalization.Localization
{
    using System;

    /// <summary>
    /// The <see cref="UILanguageService" /> interface.
    /// </summary>
    public class UILanguageService : IUILanguageService
    {
        /// <summary>
        /// Gets the translated text for the current language.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The translated text.
        /// </returns>
        /// <exception cref="ArgumentException"> Thrown if <paramref name="area" /> or <paramref name="key" /> are <c>null</c> or white space.</exception>
        public string GetText(string area, string key)
        {
            if (string.IsNullOrWhiteSpace(area))
            {
                throw new ArgumentException("Area cannot be null or white space.", nameof(area));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be null or white space.", nameof(key));
            }

            return umbraco.ui.GetText(area, key);
        }
    }
}
