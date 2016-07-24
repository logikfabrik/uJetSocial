// <copyright file="ReportAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using Models.Querying;

    /// <summary>
    /// The <see cref="ReportAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class ReportAPIController : DataTransferObjectAPIController<Report.Report>
    {
        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching data transfer object instances of type <see cref="Report.Report" />.</returns>
        [HttpPost]
        public QueryResult<Report.Report> Query(ReportQuery query)
        {
            var q = GetQuery(query);

            if (!string.IsNullOrWhiteSpace(query.Text))
            {
                q.Criterias.Add(obj => obj.Text.StartsWith(query.Text, StringComparison.InvariantCultureIgnoreCase));
            }

            var result = Provider.Query(q);

            return new QueryResult<Report.Report>
            {
                Total = result.Total,
                Objects = result.Objects.Select(GetModel)
            };
        }
    }
}
