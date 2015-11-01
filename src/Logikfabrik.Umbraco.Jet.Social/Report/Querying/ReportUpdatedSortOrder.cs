// <copyright file="ReportUpdatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportUpdatedSortOrder" /> class.
    /// </summary>
    public class ReportUpdatedSortOrder : EntityUpdatedSortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportUpdatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ReportUpdatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
