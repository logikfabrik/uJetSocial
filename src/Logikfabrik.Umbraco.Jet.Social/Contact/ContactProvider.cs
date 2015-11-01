// <copyright file="ContactProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Contact
{
    using System;
    using System.Data;
    using Caching;
    using Querying;
    using Social.Querying;

    /// <summary>
    /// The <see cref="ContactProvider" /> class. Provider for <see cref="Contact" /> entities.
    /// </summary>
    public class ContactProvider : QueryableEntityProvider<Contact, IContactCriteria, IContactSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="databaseProvider">The database provider.</param>
        public ContactProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
            : base(entityProviderFactory, cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected override IQueryBuilder<IContactCriteria, IContactSortOrder> QueryBuilder => new ContactQueryBuilder();

        /// <summary>
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        protected override Contact GetEntityFromDatabase(int id)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityContactGet"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", id);

                    Contact entity = null;

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
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        protected override Contact AddEntityToDatabase(Contact entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityContactAdd"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "fromId", entity.From.Id);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "toId", entity.To.Id);

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
        protected override Contact UpdateEntityInDatabase(Contact entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityEntityUpdate"))
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
        protected override void RemoveEntityFromDatabase(Contact entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityContactRemove"))
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
            return Contact.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The entity.</returns>
        protected override Contact GetEntity(IDataReader reader)
        {
            var entityId = reader.GetInt32(0);
            var entityCreated = reader.GetDateTime(1);
            var entityUpdated = reader.GetDateTime(2);
            var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

            var contactFromId = reader.GetInt32(4);
            var contactFromType = reader.GetString(5);
            var contactToId = reader.GetInt32(6);
            var contactToType = reader.GetString(7);

            var contactFrom = EntityProviderFactory.GetEntityProvider(Type.GetType(contactFromType)).GetEntity(contactFromId);
            var contactTo = EntityProviderFactory.GetEntityProvider(Type.GetType(contactToType)).GetEntity(contactToId);

            var entity = new Contact((Member.Member)contactFrom, (Member.Member)contactTo)
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