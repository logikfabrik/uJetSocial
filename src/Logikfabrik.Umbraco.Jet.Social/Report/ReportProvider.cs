// <copyright file="ReportProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Report
{
    using System;
    using System.Data;
    using Caching;
    using Querying;
    using Social.Querying;

    /// <summary>
    /// Represents a report provider.
    /// </summary>
    public class ReportProvider : QueryableEntityProvider<Report, IReportCriteria, IReportSortOrder>
    {
        private readonly IEntityProviderFactory _entityProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory to use.</param>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public ReportProvider(IEntityProviderFactory entityProviderFactory, ICacheManager cacheManager, IDatabaseProvider databaseProvider)
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
        protected override IQueryBuilder<IReportCriteria, IReportSortOrder> QueryBuilder => new ReportQueryBuilder();

        /// <summary>
        /// Gets an entity from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The entity ID.</param>
        /// <returns>An entity.</returns>
        protected override Report GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityReportGet"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", id);

                    Report entity = null;

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
        protected override Report AddEntityToDatabase(IDatabaseProvider provider, Report entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityReportAdd"))
                {
                    provider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.Int32, "entityId", entity.Entity.Id);
                    provider.AddCommandParameter(command, DbType.Int32, "authorId", entity.Author.Id);
                    provider.AddCommandParameter(command, DbType.String, "text", entity.Text);

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
        protected override Report UpdateEntityInDatabase(IDatabaseProvider provider, Report entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityReportUpdate"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                    provider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    provider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    provider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    provider.AddCommandParameter(command, DbType.String, "text", entity.Text);

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
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, Report entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityReportRemove"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        protected override string GetDefaultCacheKey(int id) => Report.GetDefaultCacheKey(id);

        protected override Report GetEntity(IDataReader reader)
        {
            var entityId = reader.GetInt32(0);
            var entityCreated = reader.GetDateTime(1);
            var entityUpdated = reader.GetDateTime(2);
            var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

            var reportEntityId = reader.GetInt32(4);
            var reportEntityType = reader.GetString(5);
            var reportAuthorId = reader.GetInt32(6);
            var reportAuthorType = reader.GetString(7);
            var reportText = reader.GetString(8);

            var reportEntity =
                _entityProviderFactory.GetEntityProvider(Type.GetType(reportEntityType)).GetEntity(reportEntityId);
            var reportAuthor =
                _entityProviderFactory.GetEntityProvider(Type.GetType(reportAuthorType)).GetEntity(reportAuthorId);

            var entity = new Report(reportEntity, (Individual.Individual)reportAuthor)
            {
                IsReadOnly = false,
                Id = entityId,
                Created = entityCreated,
                Updated = entityUpdated,
                Status = entityStatus,
                Text = reportText
            };

            entity.IsReadOnly = true;

            return entity;
        }
    }
}
