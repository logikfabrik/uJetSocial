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
    /// Represents a guest individual provider.
    /// </summary>
    public class GuestIndividualProvider : QueryableEntityProvider<GuestIndividual, IGuestIndividualCriteria, IGuestIndividualSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuestIndividualProvider" /> class.
        /// </summary>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public GuestIndividualProvider(ICacheManager cacheManager, IDatabaseProvider databaseProvider)
            : base(cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected override IQueryBuilder<IGuestIndividualCriteria, IGuestIndividualSortOrder> QueryBuilder => new GuestIndividualQueryBuilder();

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected override GuestIndividual GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestGet"))
            {
                provider.AddCommandParameter(command, DbType.Int32, "id", id);

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
        /// Adds an entity to the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        protected override GuestIndividual AddEntityToDatabase(IDatabaseProvider provider, GuestIndividual entity)
        {
            using (var connection = provider.GetConnection())
            using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestAdd"))
            {
                provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                provider.AddCommandParameter(command, DbType.String, "firstName", entity.FirstName);
                provider.AddCommandParameter(command, DbType.String, "lastName", entity.LastName);
                provider.AddCommandParameter(command, DbType.String, "email", entity.Email);

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
        protected override GuestIndividual UpdateEntityInDatabase(IDatabaseProvider provider, GuestIndividual entity)
        {
            using (var connection = provider.GetConnection())
            using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestUpdate"))
            {
                provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                provider.AddCommandParameter(command, DbType.String, "firstName", entity.FirstName);
                provider.AddCommandParameter(command, DbType.String, "lastName", entity.LastName);
                provider.AddCommandParameter(command, DbType.String, "email", entity.Email);

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
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, GuestIndividual entity)
        {
            using (var connection = provider.GetConnection())
            using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualGuestRemove"))
            {
                provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        protected override string GetDefaultCacheKey(int id)
        {
            return Individual.GetDefaultCacheKey(id);
        }

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
