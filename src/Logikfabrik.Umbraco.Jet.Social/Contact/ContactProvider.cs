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
    /// Represents a contact provider.
    /// </summary>
    public class ContactProvider : QueryableEntityProvider<Contact, IContactCriteria, IContactSortOrder>
    {
        private readonly IEntityProviderFactory _entityProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory to use.</param>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public ContactProvider(IEntityProviderFactory entityProviderFactory, ICacheManager cacheManager, IDatabaseProvider databaseProvider)
            : base(cacheManager, databaseProvider)
        {
            if (entityProviderFactory == null)
            {
                throw new ArgumentNullException(nameof(entityProviderFactory));
            }

            _entityProviderFactory = entityProviderFactory;
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected override IQueryBuilder<IContactCriteria, IContactSortOrder> QueryBuilder => new ContactQueryBuilder();

        /// <summary>
        /// Gets a contact from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The contact ID.</param>
        /// <returns>A contact.</returns>
        protected override Contact GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityContactGet"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", id);

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
        /// Adds a contact to the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The contact to add.</param>
        /// <returns>The added contact.</returns>
        protected override Contact AddEntityToDatabase(IDatabaseProvider provider, Contact entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityContactAdd"))
                {
                    provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.Int32, "fromId", entity.From.Id);
                    provider.AddCommandParameter(command, DbType.Int32, "toId", entity.To.Id);

                    connection.Open();

                    entity.Id = (int)command.ExecuteScalar();
                    entity.IsReadOnly = true;

                    return entity;
                }
            }
        }

        /// <summary>
        /// Updates a contact in the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The contact to update.</param>
        /// <returns>The updated contact.</returns>
        protected override Contact UpdateEntityInDatabase(IDatabaseProvider provider, Contact entity)
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
        /// Removes a contact from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The contact to remove.</param>
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, Contact entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityContactRemove"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the default cache key for a contact.
        /// </summary>
        /// <param name="id">The contact ID.</param>
        /// <returns>The default contact cache key.</returns>
        protected override string GetDefaultCacheKey(int id)
        {
            return Contact.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets a contact.
        /// </summary>
        /// <param name="reader">The data reader to read a contact from.</param>
        /// <returns>A contact.</returns>
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

            var contactFrom =
                _entityProviderFactory.GetEntityProvider(Type.GetType(contactFromType)).GetEntity(contactFromId);
            var contactTo =
                _entityProviderFactory.GetEntityProvider(Type.GetType(contactToType)).GetEntity(contactToId);

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