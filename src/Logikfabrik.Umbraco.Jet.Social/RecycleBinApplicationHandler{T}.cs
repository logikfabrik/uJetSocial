// <copyright file="RecycleBinApplicationHandler{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Events;
    using global::Umbraco.Core.Models;
    using global::Umbraco.Web.Security;

    /// <summary>
    /// The <see cref="RecycleBinApplicationHandler{T}" /> interface.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    public abstract class RecycleBinApplicationHandler<T> : ApplicationHandler
        where T : DataTransferObject
    {
        /// <summary>
        /// Deletes the nodes with specified Umbraco IDs.
        /// </summary>
        /// <param name="umbracoIds">The Umbraco Ids.</param>
        /// <param name="args">The <see cref="CancellableEventArgs" /> instance containing the event data.</param>
        protected static void Delete(IEnumerable<int> umbracoIds, CancellableEventArgs args)
        {
            var provider = (IUmbracoToDataTransferObjectProvider<T>)DataTransferObjectProviders.GetProvider(typeof(T));

            var failedIds = new List<int>();

            foreach (var umbracoId in umbracoIds)
            {
                var dto = provider.GetByUmbracoId(umbracoId);

                if (dto == null)
                {
                    continue;
                }

                try
                {
                    provider.Remove(dto.Id);
                }
                catch (Exception)
                {
                    failedIds.Add(umbracoId);
                }
            }

            if (!args.CanCancel || !failedIds.Any())
            {
                return;
            }

            var culture = GetUICulture();

            var category = ApplicationContext.Current.Services.TextService.Localize("errorCategoryEmptyRecycleBin", culture);
            var message = ApplicationContext.Current.Services.TextService.Localize(failedIds.Count == 1 ? $"emptyRecycleBin{typeof(T).Name}Error" : $"emptyRecycleBin{typeof(T).Name}Errors", culture);

            args.CancelOperation(new EventMessage(category, string.Format(message, string.Join(", ", failedIds)), EventMessageType.Error));
        }

        /// <summary>
        /// Gets the UI culture for the current user.
        /// </summary>
        /// <returns>The UI culture for the current user.</returns>
        private static CultureInfo GetUICulture()
        {
            var security = new WebSecurity(new HttpContextWrapper(HttpContext.Current), ApplicationContext.Current);

            return security.CurrentUser.GetUserCulture(ApplicationContext.Current.Services.TextService);
        }
    }
}
