﻿// <copyright file="DocumentApplicationHandler.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Document
{
    using System.Linq;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Events;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Core.Services;

    /// <summary>
    /// The <see cref="DocumentApplicationHandler" /> class.
    /// </summary>
    public class DocumentApplicationHandler : RecycleBinApplicationHandler<Document>
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
                ContentService.EmptyingRecycleBin += EmptyingRecycleBin;

                configured = true;
            }
        }

        private static void EmptyingRecycleBin(IContentService sender, RecycleBinEventArgs args)
        {
            if (!args.IsContentRecycleBin)
            {
                return;
            }

            if (args.CanCancel && args.Cancel)
            {
                return;
            }

            Delete(args.Ids, args);
        }

        private static void Deleting(IContentService sender, DeleteEventArgs<IContent> args)
        {
            if (args.CanCancel && args.Cancel)
            {
                return;
            }

            Delete(args.DeletedEntities.Select(document => document.Id), args);
        }
    }
}
