// <copyright file="ReportProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report
{
    /// <summary>
    /// The <see cref="ReportProvider" /> class.
    /// </summary>
    public class ReportProvider : DataTransferObjectProvider<Report>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportProvider" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public ReportProvider(IDatabaseWrapper database)
            : base(database)
        {
        }
    }
}
