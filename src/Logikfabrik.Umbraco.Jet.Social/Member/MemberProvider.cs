// <copyright file="MemberProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Member
{
    using System;
    using System.Data;
    using Caching;

    /// <summary>
    /// The <see cref="MemberProvider" /> class. Provider for <see cref="Member" /> entities.
    /// </summary>
    public class MemberProvider : EntityProvider<Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="databaseProvider">The database provider.</param>
        public MemberProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
            : base(entityProviderFactory, cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the member with the specified provider user key.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns>The member.</returns>
        public Member GetEntity(object providerUserKey)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentNullException(nameof(providerUserKey));
            }

            var e = CacheManager.GetEntity<Member>(Member.GetDefaultCacheKey(providerUserKey));

            if (e != null)
            {
                return e;
            }

            e = GetEntityFromDatabase(providerUserKey);

            if (e == null)
            {
                return null;
            }

            CacheManager.AddEntity(e);

            return e;
        }

        /// <summary>
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        protected override Member GetEntityFromDatabase(int id)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialMemberGet"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", id);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        var entityId = reader.GetInt32(0);
                        var entityCreated = reader.GetDateTime(1);
                        var entityUpdated = reader.GetDateTime(2);
                        var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

                        var memberProviderUserKey = reader.GetInt32(4);

                        var entity = new Member(memberProviderUserKey)
                        {
                            IsReadOnly = false,
                            Id = entityId,
                            Created = entityCreated,
                            Updated = entityUpdated,
                            Status = entityStatus
                        };

                        entity.IsReadOnly = true;

                        return entity;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        protected override Member AddEntityToDatabase(Member entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialMemberAdd"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "providerUserKey", (int)entity.ProviderUserKey);

                    connection.Open();

                    entity.Id = (int)command.ExecuteScalar();
                    entity.IsReadOnly = true;

                    return entity;
                }
            }
        }

        /// <summary>
        /// Updates the specified entity in the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The updated entity.
        /// </returns>
        protected override Member UpdateEntityInDatabase(Member entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialEntityUpdate"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);

                    connection.Open();

                    command.ExecuteNonQuery();

                    entity.IsReadOnly = true;

                    return entity;
                }
            }
        }

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void RemoveEntityFromDatabase(Member entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialMemberRemove"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the default cache key using the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The default cache key.
        /// </returns>
        protected override string GetDefaultCacheKey(int id)
        {
            return Member.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets the member with the specified provider user key from the database.
        /// </summary>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns>The member.</returns>
        private Member GetEntityFromDatabase(object providerUserKey)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialMemberGetByProviderUserKey"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "providerUserKey", providerUserKey);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            return null;
                        }

                        var entityId = reader.GetInt32(0);
                        var entityCreated = reader.GetDateTime(1);
                        var entityUpdated = reader.GetDateTime(2);
                        var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

                        var memberProviderUserKey = reader.GetInt32(4);

                        var entity = new Member(memberProviderUserKey)
                        {
                            IsReadOnly = false,
                            Id = entityId,
                            Created = entityCreated,
                            Updated = entityUpdated,
                            Status = entityStatus
                        };

                        entity.IsReadOnly = true;

                        return entity;
                    }
                }
            }
        }
    }
}
