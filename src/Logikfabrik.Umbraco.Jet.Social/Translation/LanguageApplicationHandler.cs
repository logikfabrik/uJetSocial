// <copyright file="LanguageApplicationHandler.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Translation
{
    using System.Web;
    using global::Umbraco.Core;
    using UI.Translation;
    using umbraco;

    /// <summary>
    /// The <see cref="LanguageApplicationHandler" /> class. Class for installing UI languages.
    /// </summary>
    public class LanguageApplicationHandler : ApplicationHandler
    {
        private static readonly object Lock = new object();

        private static bool configured;

        /// <summary>
        /// Called when the application is started.
        /// </summary>
        /// <param name="umbracoApplication">The Umbraco application.</param>
        /// <param name="applicationContext">The application context.</param>
        public override void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            if (!IsInstalled)
            {
                return;
            }

            if (configured)
            {
                return;
            }

            lock (Lock)
            {
                InstallLanguages(umbracoApplication);

                configured = true;
            }
        }

        private void InstallLanguages(HttpApplication umbracoApplication)
        {
            var languageDirectory = new LanguageDirectory(umbracoApplication.Context.Server.MapPath(string.Concat(GlobalSettings.Path, "/config/lang/")));

            var type = GetType();

            var resourceDirectory = new ResourceDirectory(type.Assembly, type.Namespace);

            new LanguageInstaller(languageDirectory, resourceDirectory).Install();
        }
    }
}
