// <copyright file="GroupProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Group
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Caching;
    using Querying;
    using Social.Querying;

    /// <summary>
    /// Represents a group provider.
    /// </summary>
    public class GroupProvider : QueryableEntityProvider<Group, IGroupCriteria, IGroupSortOrder>
    {
        private readonly IEntityProviderFactory _entityProviderFactory;
        private readonly IDatabaseProvider _databaseProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory to use.</param>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public GroupProvider(IEntityProviderFactory entityProviderFactory, ICacheManager cacheManager, IDatabaseProvider databaseProvider)
            : base(cacheManager, databaseProvider)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            _entityProviderFactory = entityProviderFactory;
            _databaseProvider = databaseProvider;
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected override IQueryBuilder<IGroupCriteria, IGroupSortOrder> QueryBuilder => new GroupQueryBuilder();

        /// <summary>
        /// Gets the total entity count.
        /// </summary>
        /// <returns>The total entity count.</returns>
        public IDictionary<char, int> GetEntityCountByName()
        {
            using (var connection = _databaseProvider.GetConnection())
            {
                using (var command = _databaseProvider.GetProcedureCommand(connection, "uJetCommunityGroupCountByName"))
                {
                    var countByName = new Dictionary<char, int>();

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);
                            var count = reader.GetInt32(1);

                            countByName.Add(name.Length > 0 ? char.Parse(name) : '\0', count);
                        }
                    }

                    return countByName;
                }
            }
        }

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected override Group GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupGet"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", id);

                    Group entity = null;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            entity = GetEntity(reader);
                        }
                    }

                    return entity;
                }
            }
        }

        /// <summary>
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        protected override Group AddEntityToDatabase(IDatabaseProvider provider, Group entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupAdd"))
                {
                    provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.Int32, "ownerId", entity.Owner.Id);
                    provider.AddCommandParameter(command, DbType.String, "name", entity.Name);
                    provider.AddCommandParameter(command, DbType.String, "description", entity.Description);

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
        protected override Group UpdateEntityInDatabase(IDatabaseProvider provider, Group entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupUpdate"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.Int32, "ownerId", entity.Owner.Id);
                    provider.AddCommandParameter(command, DbType.String, "name", entity.Name);
                    provider.AddCommandParameter(command, DbType.String, "description", entity.Description);

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
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, Group entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityGroupRemove"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        protected override string GetDefaultCacheKey(int id)
        {
            return Group.GetDefaultCacheKey(id);
        }

        protected override Group GetEntity(IDataReader reader)
        {
            var entityId = reader.GetInt32(0);
            var entityCreated = reader.GetDateTime(1);
            var entityUpdated = reader.GetDateTime(2);
            var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

            var groupOwnerId = reader.GetInt32(4);
            var groupOwnerType = reader.GetString(5);
            var groupName = reader.GetString(6);
            var groupDescription = reader.GetString(7);

            var groupOwner =
                _entityProviderFactory.GetEntityProvider(Type.GetType(groupOwnerType))
                    .GetEntity(groupOwnerId);

            var entity = new Group((Individual.Individual)groupOwner)
            {
                IsReadOnly = false,
                Id = entityId,
                Created = entityCreated,
                Updated = entityUpdated,
                Status = entityStatus,
                Name = groupName,
                Description = groupDescription
            };

            entity.IsReadOnly = true;

            return entity;
        }
    }
}