// <copyright file="MediaApplicationHandler.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Media
{
    using System.Linq;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Events;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Core.Services;

    /// <summary>
    /// The <see cref="MediaApplicationHandler" /> class.
    /// </summary>
    public class MediaApplicationHandler : RecycleBinApplicationHandler<Media>
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
                MediaService.Deleting += Deleting;
                MediaService.EmptyingRecycleBin += EmptyingRecycleBin;

                configured = true;
            }
        }

        private static void EmptyingRecycleBin(IMediaService sender, RecycleBinEventArgs args)
        {
            if (!args.IsMediaRecycleBin)
            {
                return;
            }

            if (args.CanCancel && args.Cancel)
            {
                return;
            }

            Delete(args.Ids, args);
        }

        private static void Deleting(IMediaService sender, DeleteEventArgs<IMedia> args)
        {
            if (args.CanCancel && args.Cancel)
            {
                return;
            }

            Delete(args.DeletedEntities.Select(media => media.Id), args);
        }
    }
}
