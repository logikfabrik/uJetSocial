// <copyright file="DocumentApplicationHandler.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    using System;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Events;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Core.Services;

    /// <summary>
    /// The <see cref="DocumentApplicationHandler" /> class.
    /// </summary>
    public class DocumentApplicationHandler : ApplicationHandler
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
                ContentService.Deleting += Deleting;

                configured = true;
            }
        }

        private static void Deleting(IContentService sender, DeleteEventArgs<IContent> args)
        {
            if (args.Cancel)
            {
                return;
            }

            var provider = (IDocumentProvider)DataTransferObjectProviders.GetProvider(typeof(Document));

            foreach (var entity in args.DeletedEntities)
            {
                var document = provider.GetByDocumentId(entity.Id);

                if (document == null)
                {
                    continue;
                }

                try
                {
                    provider.Remove(document.Id);
                }
                catch (Exception)
                {
                    if (args.CanCancel)
                    {
                        // TODO: The document cannot be removed as it's used within uJetSocial. Show an error message.
                        args.Cancel = true;
                    }
                }
            }
        }
    }
}
