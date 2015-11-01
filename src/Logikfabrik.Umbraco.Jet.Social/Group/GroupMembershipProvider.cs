// <copyright file="GroupMembershipProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using System.Data;
    using Caching;

    /// <summary>
    /// The <see cref="GroupMembershipProvider" /> class. Provider for <see cref="GroupMembership" /> entities.
    /// </summary>
    public class GroupMembershipProvider : EntityProvider<GroupMembership>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupMembershipProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="databaseProvider">The database provider.</param>
        public GroupMembershipProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
            : base(entityProviderFactory, cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        protected override GroupMembership GetEntityFromDatabase(int id)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialGroupMembershipGet"))
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

                        var groupMembershipGroupId = reader.GetInt32(4);
                        var groupMembershipGroupType = reader.GetString(5);
                        var groupMembershipMemberId = reader.GetInt32(6);
                        var groupMembershipMemberType = reader.GetString(7);

                        var groupMembershipGroup = EntityProviderFactory.GetEntityProvider(Type.GetType(groupMembershipGroupType)).GetEntity(groupMembershipGroupId);
                        var groupMembershipMember = EntityProviderFactory.GetEntityProvider(Type.GetType(groupMembershipMemberType)).GetEntity(groupMembershipMemberId);

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
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        protected override GroupMembership AddEntityToDatabase(GroupMembership entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialGroupMembershipAdd"))
            {
                DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "groupId", entity.Group.Id);
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "memberId", entity.Member.Id);

                connection.Open();

                entity.Id = (int)command.ExecuteScalar();
                entity.IsReadOnly = true;

                return entity;
            }
        }

        /// <summary>
        /// Updates the specified entity in the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The updated entity.
        /// </returns>
        protected override GroupMembership UpdateEntityInDatabase(GroupMembership entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
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

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected override void RemoveEntityFromDatabase(GroupMembership entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialGroupMembershipRemove"))
            {
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                connection.Open();

                command.ExecuteNonQuery();
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
            return GroupMembership.GetDefaultCacheKey(id);
        }
    }
}
