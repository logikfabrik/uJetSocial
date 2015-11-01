// <copyright file="ReportEntityIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportEntityIdSortOrder" /> class.
    /// </summary>
    public class ReportEntityIdSortOrder : SortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportEntityIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ReportEntityIdSortOrder(Order order)
            : base("uJetSocialReport.EntityId", order)
        {
        }
    }
}
