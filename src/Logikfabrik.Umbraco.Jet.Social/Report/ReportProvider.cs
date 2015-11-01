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
    /// The <see cref="ReportProvider" /> class. Provider for <see cref="Report" /> entities.
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
        public ReportProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
            : base(entityProviderFactory, cacheManager, databaseProvider)
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
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity.</returns>
        protected override Report GetEntityFromDatabase(int id)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityReportGet"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", id);

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
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The added entity.</returns>
        protected override Report AddEntityToDatabase(Report entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityReportAdd"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "type", EntityType.FullName);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "entityId", entity.Entity.Id);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "authorId", entity.Author.Id);
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "text", entity.Text);

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
        /// <returns>The updated entity.</returns>
        protected override Report UpdateEntityInDatabase(Report entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityReportUpdate"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "created", entity.Created);
                    DatabaseProvider.AddCommandParameter(command, DbType.DateTime, "updated", entity.Updated);
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "status", entity.Status);
                    DatabaseProvider.AddCommandParameter(command, DbType.String, "text", entity.Text);

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
        protected override void RemoveEntityFromDatabase(Report entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetCommunityReportRemove"))
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
        /// <returns>The default cache key.</returns>
        protected override string GetDefaultCacheKey(int id) => Report.GetDefaultCacheKey(id);

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The entity.</returns>
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

            var reportEntity = _entityProviderFactory.GetEntityProvider(Type.GetType(reportEntityType)).GetEntity(reportEntityId);
            var reportAuthor = _entityProviderFactory.GetEntityProvider(Type.GetType(reportAuthorType)).GetEntity(reportAuthorId);

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
