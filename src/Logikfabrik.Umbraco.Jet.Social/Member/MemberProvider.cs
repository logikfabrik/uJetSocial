// <copyright file="MemberProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Member
{
    using System;
    using System.Data;
    using Caching;

    /// <summary>
    /// Represents a member provider.
    /// </summary>
    public class MemberProvider : EntityProvider<Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberProvider" /> class.
        /// </summary>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public MemberProvider(ICacheManager cacheManager, IDatabaseProvider databaseProvider)
            : base(cacheManager, databaseProvider)
        {
        }

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

            e = GetEntityFromDatabase(DatabaseProvider, providerUserKey);

            if (e == null)
            {
                return null;
            }

            CacheManager.AddEntity(e);

            return e;
        }

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected override Member GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityMemberGet"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", id);

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
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        protected override Member AddEntityToDatabase(IDatabaseProvider provider, Member entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityMemberAdd"))
                {
                    provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.Int32, "providerUserKey", (int)entity.ProviderUserKey);

                    connection.Open();

                    entity.Id = (int)command.ExecuteScalar();
                    entity.IsReadOnly = true;

                    return entity;
                }
            }
        }

        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        protected override Member UpdateEntityInDatabase(IDatabaseProvider provider, Member entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityEntityUpdate"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);

                    connection.Open();

                    command.ExecuteNonQuery();

                    entity.IsReadOnly = true;

                    return entity;
                }
            }
        }

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to remove.</param>
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, Member entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityMemberRemove"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        protected override string GetDefaultCacheKey(int id)
        {
            return Member.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets a member from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="providerUserKey">The provider user key.</param>
        /// <returns>A member.</returns>
        private static Member GetEntityFromDatabase(IDatabaseProvider provider, object providerUserKey)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityMemberGetByProviderUserKey"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "providerUserKey", providerUserKey);

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
