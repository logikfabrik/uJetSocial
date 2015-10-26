// <copyright file="ReportAuthorIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// Represents a report author ID sort order.
    /// </summary>
    public class ReportAuthorIdSortOrder : SortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportAuthorIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The sort order.</param>
        public ReportAuthorIdSortOrder(Order order)
            : base("uJetCommunityReport.AuthorId", order)
        {
        }
    }
}
