﻿// <copyright file="ReportTextCriteria.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report.Querying
{
    using Social.Querying;

    /// <summary>
    /// The <see cref="ReportTextCriteria" /> class.
    /// </summary>
    public class ReportTextCriteria : Criteria, IReportCriteria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportTextCriteria" /> class.
        /// </summary>
        public ReportTextCriteria()
            : base("uJetSocialReport.Text")
        {
        }
    }
}