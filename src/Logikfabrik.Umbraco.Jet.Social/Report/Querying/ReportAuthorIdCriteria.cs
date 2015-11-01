// <copyright file="ReportAuthorIdCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportAuthorIdCriteria" /> class.
    /// </summary>
    public class ReportAuthorIdCriteria : Criteria, IReportCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportAuthorIdCriteria" /> class.
        /// </summary>
        public ReportAuthorIdCriteria()
            : base("uJetCommunityReport.AuthorId")
        {
        }
    }
}
