// <copyright file="ReportIdSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportIdSortOrder" /> class.
    /// </summary>
    public class ReportIdSortOrder : EntityIdSortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportIdSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ReportIdSortOrder(Order order)
            : base(order)
        {
        }
    }
}
