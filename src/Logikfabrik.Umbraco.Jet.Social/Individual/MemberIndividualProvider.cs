// <copyright file="MemberIndividualProvider.cs" company="Logikfabrik">
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
    /// Represents a member individual provider.
    /// </summary>
    public class MemberIndividualProvider : QueryableEntityProvider<MemberIndividual, IMemberIndividualCriteria, IMemberIndividualSortOrder>
    {
        private readonly IEntityProviderFactory _entityProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberIndividualProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory to use.</param>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public MemberIndividualProvider(IEntityProviderFactory entityProviderFactory, ICacheManager cacheManager, IDatabaseProvider databaseProvider)
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
        protected override IQueryBuilder<IMemberIndividualCriteria, IMemberIndividualSortOrder> QueryBuilder => new MemberIndividualQueryBuilder();

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected override MemberIndividual GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualMemberGet"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", id);

                    MemberIndividual entity = null;

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
        protected override MemberIndividual AddEntityToDatabase(IDatabaseProvider provider, MemberIndividual entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualMemberAdd"))
                {
                    provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.Int32, "memberId", entity.Member.Id);

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
        protected override MemberIndividual UpdateEntityInDatabase(IDatabaseProvider provider, MemberIndividual entity)
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
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, MemberIndividual entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityIndividualMemberRemove"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        protected override string GetDefaultCacheKey(int id)
        {
            return Individual.GetDefaultCacheKey(id);
        }

        protected override MemberIndividual GetEntity(IDataReader reader)
        {
            var entityId = reader.GetInt32(0);
            var entityCreated = reader.GetDateTime(1);
            var entityUpdated = reader.GetDateTime(2);
            var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

            var individualMemberMemberId = reader.GetInt32(4);

            var individualMemberMember =
                _entityProviderFactory.GetEntityProvider(typeof(Member.Member)).GetEntity(individualMemberMemberId);

            var entity = new MemberIndividual((Member.Member)individualMemberMember)
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
