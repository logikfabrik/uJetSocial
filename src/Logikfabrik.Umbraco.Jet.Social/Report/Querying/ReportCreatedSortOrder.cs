// <copyright file="ReportCreatedSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportCreatedSortOrder" /> class.
    /// </summary>
    public class ReportCreatedSortOrder : EntityCreatedSortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportCreatedSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ReportCreatedSortOrder(Order order)
            : base(order)
        {
        }
    }
}
