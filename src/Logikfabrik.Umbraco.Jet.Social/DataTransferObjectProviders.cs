// <copyright file="DataTransferObjectProviders.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using Attribute;
    using Comment;
    using Contact;
    using Document;
    using Group;
    using Individual;
    using Media;
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
            Func<ICacheWrapper> cache = CacheWrapperFactory.GetCache;
            Func<IDatabaseWrapper> database = DatabaseWrapperFactory.GetDatabase;

            return new DataTransferObjectProviderDictionary
            {
                { typeof(Attribute.Attribute), new AttributeProvider(cache, database) },
                { typeof(Comment.Comment), new CommentProvider(cache, database) },
                { typeof(Contact.Contact), new ContactProvider(cache, database) },
                { typeof(Document.Document), new DocumentProvider(cache, database) },
                { typeof(Group.Group), new GroupProvider(cache, database) },
                { typeof(GroupMembership), new GroupMembershipProvider(cache, database) },
                { typeof(IndividualGuest), new IndividualGuestProvider(cache, database) },
                { typeof(IndividualMember), new IndividualMemberProvider(cache, database) },
                { typeof(Media.Media), new MediaProvider(cache, database) },
                { typeof(Report.Report), new ReportProvider(cache, database) }
            };
        }
    }
}
