// <copyright file="ReportEntityIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a report entity ID sort order.
    /// </summary>
    public class ReportEntityIdSortOrder : SortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportEntityIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public ReportEntityIdSortOrder(Order order)
            : base("uJetCommunityReport.EntityId", order)
        {
        }
    }
}
