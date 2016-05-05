// <copyright file="DatabaseWrapperFactory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Core.ObjectResolution;

    /// <summary>
    /// The <see cref="DatabaseWrapperFactory" /> class.
    /// </summary>
    public static class DatabaseWrapperFactory
    {
        /// <summary>
        /// Gets a database.
        /// </summary>
        /// <returns>A database.</returns>
        public static IDatabaseWrapper GetDatabase()
        {
            var context = global::Umbraco.Core.ApplicationContext.Current.DatabaseContext;

            return new DatabaseWrapper(context.Database, ResolverBase<LoggerResolver>.Current.Logger, context.SqlSyntax);
        }
    }
}
