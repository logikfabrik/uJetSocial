// <copyright file="ReportQueryBuilder.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using System.Collections.Generic;
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportQueryBuilder" /> class.
    /// </summary>
    public class ReportQueryBuilder : EntityQueryBuilder<IReportCriteria, IReportSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportQueryBuilder" /> class.
        /// </summary>
        public ReportQueryBuilder()
            : base(GetColumns(), "uJetSocialReport")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetSocialReport.EntityId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetSocialReport.EntityId) AS EntityType",
                "uJetSocialReport.AuthorId",
                "(SELECT CET.Type FROM uJetSocialEntityType as CET JOIN uJetSocialEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetSocialReport.AuthorId) AS AuthorType",
                "uJetSocialReport.Text"
            };
        }
    }
}
