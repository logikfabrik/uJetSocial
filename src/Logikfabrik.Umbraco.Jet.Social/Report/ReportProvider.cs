﻿// <copyright file="ReportProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report
{
    using System;

    /// <summary>
    /// The <see cref="ReportProvider" /> class.
    /// </summary>
    public class ReportProvider : DataTransferObjectProvider<Report>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportProvider" /> class.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="database">The database.</param>
        public ReportProvider(
            Func<ICacheWrapper> cache,
            Func<IDatabaseWrapper> database)
            : base(cache, database)
        {
        }

        /// <summary>
        /// Gets the report with the specified identifier.
        /// </summary>
        /// <param name="id">The report identifier.</param>
        /// <returns>
        /// The report with the specified identifier.
        /// </returns>
        public override Report Get(int id)
        {
            var report = base.Get(id);

            if (report == null)
            {
                return null;
            }

            report.IsReadOnly = false;

            report.EntityType = GetEntityType(report.EntityId);
            report.AuthorType = GetEntityType(report.AuthorId);

            report.IsReadOnly = true;

            Cache.AddObject(report);

            return report;
        }
    }
}
