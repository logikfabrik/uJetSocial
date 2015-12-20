// <copyright file="DataTransferObjectProviders.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using Comment;
    using Contact;
    using Document;
    using global::Umbraco.Core;
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Core.ObjectResolution;
    using Group;
    using Individual;
    using Report;

    /// <summary>
    /// The <see cref="DataTransferObjectProviders" /> class.
    /// </summary>
    public static class DataTransferObjectProviders
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        public static DataTransferObjectProviderDictionary Providers { get; } = GetDefaultProviders();

        /// <summary>
        /// Gets the provider for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The provider for the specified type.</returns>
        public static IDataTransferObjectProvider GetProvider(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            IDataTransferObjectProvider provider;

            return !Providers.TryGetValue(type, out provider) ? null : provider;
        }

        /// <summary>
        /// Gets the default providers.
        /// </summary>
        /// <returns>The default providers.</returns>
        private static DataTransferObjectProviderDictionary GetDefaultProviders()
        {
            Func<IDatabaseWrapper> database = () =>
            {
                var context = ApplicationContext.Current.DatabaseContext;

                return new DatabaseWrapper(context.Database, ResolverBase<LoggerResolver>.Current.Logger, context.SqlSyntax);
            };

            return new DataTransferObjectProviderDictionary
            {
                { typeof(Comment.Comment), new CommentProvider(database) },
                { typeof(Contact.Contact), new ContactProvider(database) },
                { typeof(Document.Document), new DocumentProvider(database) },
                { typeof(Group.Group), new GroupProvider(database) },
                { typeof(IndividualGuest), new IndividualGuestProvider(database) },
                { typeof(IndividualMember), new IndividualMemberProvider(database) },
                { typeof(Report.Report), new ReportProvider(database) }
            };
        }
    }
}
