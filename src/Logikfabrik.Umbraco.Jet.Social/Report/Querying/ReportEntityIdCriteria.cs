// <copyright file="ReportEntityIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportEntityIdCriteria" /> class.
    /// </summary>
    public class ReportEntityIdCriteria : Criteria, IReportCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportEntityIdCriteria" /> class.
        /// </summary>
        public ReportEntityIdCriteria()
            : base("uJetSocialReport.EntityId")
        {
        }
    }
}
