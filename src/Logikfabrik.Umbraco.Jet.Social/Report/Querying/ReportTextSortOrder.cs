// <copyright file="ReportTextSortOrder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportTextSortOrder" /> class.
    /// </summary>
    public class ReportTextSortOrder : SortOrder, IReportSortOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportTextSortOrder" /> class.
        /// </summary>
        /// <param name="order">The order.</param>
        public ReportTextSortOrder(Order order)
            : base("uJetSocialReport.Text", order)
        {
        }
    }
}
