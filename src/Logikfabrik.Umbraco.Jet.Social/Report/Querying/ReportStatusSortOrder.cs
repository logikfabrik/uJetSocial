// <copyright file="ReportStatusSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportStatusSortOrder" /> class.
    /// </summary>
    public class ReportStatusSortOrder : EntityStatusSortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportStatusSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ReportStatusSortOrder(Order order)
            : base(order)
        {
        }
    }
}
