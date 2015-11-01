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
            : base(GetColumns(), "uJetCommunityReport")
        {
        }

        private static IEnumerable<string> GetColumns()
        {
            return new[]
            {
                "uJetCommunityReport.EntityId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetCommunityReport.EntityId) AS EntityType",
                "uJetCommunityReport.AuthorId",
                "(SELECT CET.Type FROM uJetCommunityEntityType as CET JOIN uJetCommunityEntity AS CE ON CE.TypeId = CET.Id WHERE CE.Id = uJetCommunityReport.AuthorId) AS AuthorType",
                "uJetCommunityReport.Text"
            };
        }
    }
}
