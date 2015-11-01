// <copyright file="EntityProviderFactory.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Caching;
    using Comment;
    using Contact;
    using Group;
    using Individual;
    using Member;
    using Report;

    /// <summary>
    /// The <see cref="EntityProviderFactory" /> class.
    /// </summary>
    public sealed class EntityProviderFactory : IEntityProviderFactory
    {
        private readonly Lazy<ConcurrentDictionary<Type, IEntityProvider>> _entityProviders;

        /// <summary>
        /// Prevents a default instance of the <see cref="EntityProviderFactory" /> class from being created.
        /// </summary>
        private EntityProviderFactory()
        {
            _entityProviders = new Lazy<ConcurrentDictionary<Type, IEntityProvider>>(GetDefaultEntityProviders);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static IEntityProviderFactory Instance { get; } = new EntityProviderFactory();

        /// <summary>
        /// Gets the entity provider for the specified entity type.
        /// </summary>
        /// <param name="entityType">The entity type.</param>
        /// <returns>The entity provider.</returns>
        public IEntityProvider GetEntityProvider(Type entityType)
        {
            if (entityType == null)
            {
                throw new ArgumentNullException(nameof(entityType));
            }

            IEntityProvider provider;

            if (!_entityProviders.Value.TryGetValue(entityType, out provider))
            {
                throw new Exception($"There is no entity provider registered for entities of type {entityType}.");
            }

            if (provider.EntityType == entityType)
            {
                return provider;
            }

            throw new Exception($"Entity provider and entity type mismatch for entity provider of type {provider.GetType()} and entity type {entityType}.");
        }

        /// <summary>
        /// Adds the specified entity provider.
        /// </summary>
        /// <param name="entityProvider">The entity provider.</param>
        public void AddEntityProvider(IEntityProvider entityProvider)
        {
            if (entityProvider == null)
            {
                throw new ArgumentNullException(nameof(entityProvider));
            }

            _entityProviders.Value.TryAdd(entityProvider.EntityType, entityProvider);
        }

        /// <summary>
        /// Removes the entity provider for the specified entity type.
        /// </summary>
        /// <param name="entityType">The entity type.</param>
        public void RemoveEntityProvider(Type entityType)
        {
            if (entityType == null)
            {
                throw new ArgumentNullException(nameof(entityType));
            }

            IEntityProvider provider;

            _entityProviders.Value.TryRemove(entityType, out provider);
        }

        /// <summary>
        /// Gets the default entity providers.
        /// </summary>
        /// <returns>The default entity providers.</returns>
        private ConcurrentDictionary<Type, IEntityProvider> GetDefaultEntityProviders()
        {
            // TODO: Rewrite the following two lines of code; do not use concrete implementations.
            var cacheManager = new CacheManager();
            var databaseProvider = new DatabaseProvider();

            var providers = new Dictionary<Type, IEntityProvider>
            {
                { typeof(Comment.Comment), new CommentProvider(this, cacheManager, databaseProvider) },
                { typeof(Group.Group), new GroupProvider(this, cacheManager, databaseProvider) },
                { typeof(GroupMembership), new GroupMembershipProvider(this, cacheManager, databaseProvider) },
                { typeof(GuestIndividual), new GuestIndividualProvider(this, cacheManager, databaseProvider) },
                { typeof(MemberIndividual), new MemberIndividualProvider(this, cacheManager, databaseProvider) },
                { typeof(Member.Member), new MemberProvider(this, cacheManager, databaseProvider) },
                { typeof(Report.Report), new ReportProvider(this, cacheManager, databaseProvider) },
                { typeof(Contact.Contact), new ContactProvider(this, cacheManager, databaseProvider) }
            };

            return new ConcurrentDictionary<Type, IEntityProvider>(providers);
        }
    }
}
