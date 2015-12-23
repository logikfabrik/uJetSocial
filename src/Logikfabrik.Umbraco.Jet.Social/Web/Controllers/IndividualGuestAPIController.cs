// <copyright file="IndividualGuestAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Individual;
    using Models;

    /// <summary>
    /// The <see cref="IndividualGuestAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class IndividualGuestAPIController : DataTransferObjectAPIController<IndividualGuest>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="IndividualGuest" />.</returns>
        [HttpPost]
        public QueryResult<IndividualGuest> Query(IndividualGuestQuery query)
        {
            var q = GetQuery(query);

            if (!string.IsNullOrWhiteSpace(query.FirstName))
            {
                q.Criterias.Add(obj => obj.FirstName.StartsWith(query.FirstName, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(query.LastName))
            {
                q.Criterias.Add(obj => obj.LastName.StartsWith(query.LastName, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                q.Criterias.Add(obj => obj.Email.StartsWith(query.Email, StringComparison.InvariantCultureIgnoreCase));
            }

            var result = Provider.Query(q);

            return new QueryResult<IndividualGuest>
            {
                Total = result.Total,
                Objects = result.Objects
            };
        }
    }
}
