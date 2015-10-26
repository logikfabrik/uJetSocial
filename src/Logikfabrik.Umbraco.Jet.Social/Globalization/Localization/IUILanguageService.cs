// <copyright file="IUILanguageService.cs" company="Logikfabrik">
// Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Globalization.Localization
{
    /// <summary>
    /// The <see cref="IUILanguageService" /> interface.
    /// </summary>
    public interface IUILanguageService
    {
        /// <summary>
        /// Gets the translated text for the current language.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="key">The key.</param>
        /// <returns>The translated text.</returns>
        string GetText(string area, string key);
    }
}
