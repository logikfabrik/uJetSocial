// <copyright file="GuestIndividualProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Individual
{
    using System;
    using System.Data;
    using Caching;
    using Querying;
    using Social.Querying;

    /// <summary>
    /// The <see cref="GuestIndividualProvider" /> class. Provider for <see cref="GuestIndividual" /> entities.
    /// </summary>
    public class GuestIndividualProvider : QueryableEntityProvider<GuestIndividual, IGuestIndividualCriteria, IGuestIndividualSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="databaseProvider">The database provider.</param>
        public GuestIndividualProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
            : base(entityProviderFactory, cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected override IQueryBuilder<IGuestIndividualCriteria, IGuestIndividualSortOrder> QueryBuilder => new GuestIndividualQueryBuilder();

        /// <summary>
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        protected override GuestIndividual GetEntityFromDatabase(int id)
        {
            using (var connection = DatabaseProvider.GetConnection())
            using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestGet"))
            {
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", id);

                GuestIndividual entity = null;

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

        /// <summary>
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        protected override GuestIndividual AddEntityToDatabase(GuestIndividual entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestAdd"))
            {
                DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                DatabaseProvider.AddCommandParameter(command, DbType.String, "firstName", entity.FirstName);
                DatabaseProvider.AddCommandParameter(command, DbType.String, "lastName", entity.LastName);
                DatabaseProvider.AddCommandParameter(command, DbType.String, "email", entity.Email);

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
        protected override GuestIndividual UpdateEntityInDatabase(GuestIndividual entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestUpdate"))
            {
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                DatabaseProvider.AddCommandParameter(command, DbType.String, "firstName", entity.FirstName);
                DatabaseProvider.AddCommandParameter(command, DbType.String, "lastName", entity.LastName);
                DatabaseProvider.AddCommandParameter(command, DbType.String, "email", entity.Email);

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
        protected override void RemoveEntityFromDatabase(GuestIndividual entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestRemove"))
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
            return Individual.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The entity.</returns>
        protected override GuestIndividual GetEntity(IDataReader reader)
        {
            var entityId = reader.GetInt32(0);
            var entityCreated = reader.GetDateTime(1);
            var entityUpdated = reader.GetDateTime(2);
            var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

            var individualFirstName = reader.GetString(4);
            var individualLastName = reader.GetString(5);
            var individualEmail = reader.GetString(6);

            var entity = new GuestIndividual
            {
                IsReadOnly = false,
                Id = entityId,
                Created = entityCreated,
                Updated = entityUpdated,
                Status = entityStatus,
                FirstName = individualFirstName,
                LastName = individualLastName,
                Email = individualEmail
            };

            entity.IsReadOnly = true;

            return entity;
        }
    }
}
