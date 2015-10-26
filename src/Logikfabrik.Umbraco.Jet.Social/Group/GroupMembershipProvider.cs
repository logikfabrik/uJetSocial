// <copyright file="GroupMembershipProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using System.Data;
    using Caching;

    /// <summary>
    /// Represents a group membership provider.
    /// </summary>
    public class GroupMembershipProvider : EntityProvider<GroupMembership>
    {
        private readonly IEntityProviderFactory _entityProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembershipProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory to use.</param>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public GroupMembershipProvider(IEntityProviderFactory entityProviderFactory, ICacheManager cacheManager, IDatabaseProvider databaseProvider)
            : base(cacheManager, databaseProvider)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            _entityProviderFactory = entityProviderFactory;
        }

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected override GroupMembership GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupMembershipGet"))
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

                        var groupMembershipGroupId = reader.GetInt32(4);
                        var groupMembershipGroupType = reader.GetString(5);
                        var groupMembershipMemberId = reader.GetInt32(6);
                        var groupMembershipMemberType = reader.GetString(7);

                        var groupMembershipGroup =
                            _entityProviderFactory.GetEntityProvider(Type.GetType(groupMembershipGroupType)).GetEntity(groupMembershipGroupId);
                        var groupMembershipMember =
                            _entityProviderFactory.GetEntityProvider(Type.GetType(groupMembershipMemberType)).GetEntity(groupMembershipMemberId);

                        var entity = new GroupMembership((Group)groupMembershipGroup, (Member.Member)groupMembershipMember)
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
        protected override GroupMembership AddEntityToDatabase(IDatabaseProvider provider, GroupMembership entity)
        {
            using (var connection = provider.GetConnection())
            using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupMembershipAdd"))
            {
                provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                provider.AddCommandParameter(command, DbType.Int32, "groupId", entity.Group.Id);
                provider.AddCommandParameter(command, DbType.Int32, "memberId", entity.Member.Id);

                connection.Open();

                entity.Id = (int)command.ExecuteScalar();
                entity.IsReadOnly = true;

                return entity;
            }
        }

        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        protected override GroupMembership UpdateEntityInDatabase(IDatabaseProvider provider, GroupMembership entity)
        {
            using (var connection = provider.GetConnection())
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

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to remove.</param>
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, GroupMembership entity)
        {
            using (var connection = provider.GetConnection())
            using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupMembershipRemove"))
            {
                provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        protected override string GetDefaultCacheKey(int id)
        {
            return GroupMembership.GetDefaultCacheKey(id);
        }
    }
}
