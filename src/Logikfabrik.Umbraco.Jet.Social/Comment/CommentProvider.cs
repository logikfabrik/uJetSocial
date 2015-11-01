// <copyright file="CommentProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Comment
{
    using System;
    using System.Data;
    using Caching;
    using Querying;
    using Social.Querying;

    /// <summary>
    /// The <see cref="CommentProvider" /> class. Provider for <see cref="Contact" /> entities.
    /// </summary>
    public class CommentProvider : QueryableEntityProvider<Comment, ICommentCriteria, ICommentSortOrder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory.</param>
        /// <param name="cacheManager">The cache manager.</param>
        /// <param name="databaseProvider">The database provider.</param>
        public CommentProvider(
            IEntityProviderFactory entityProviderFactory,
            ICacheManager cacheManager,
            IDatabaseProvider databaseProvider)
            : base(entityProviderFactory, cacheManager, databaseProvider)
        {
        }

        /// <summary>
        /// Gets the query builder.
        /// </summary>
        protected override IQueryBuilder<ICommentCriteria, ICommentSortOrder> QueryBuilder => new CommentQueryBuilder();

        /// <summary>
        /// Gets the entity with the specified identifier from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        protected override Comment GetEntityFromDatabase(int id)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialCommentGet"))
                {
                    DatabaseProvider.AddCommandParameter(command, DbType.Int32, "id", id);

                    Comment entity = null;

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
        protected override Comment AddEntityToDatabase(Comment entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialCommentAdd"))
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
        /// <returns>
        /// The updated entity.
        /// </returns>
        protected override Comment UpdateEntityInDatabase(Comment entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialCommentUpdate"))
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
        protected override void RemoveEntityFromDatabase(Comment entity)
        {
            using (var connection = DatabaseProvider.GetConnection())
            {
                using (var command = DatabaseProvider.GetProcedureCommand(connection, "uJetSocialCommentRemove"))
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
            return Comment.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>The entity.</returns>
        protected override Comment GetEntity(IDataReader reader)
        {
            var entityId = reader.GetInt32(0);
            var entityCreated = reader.GetDateTime(1);
            var entityUpdated = reader.GetDateTime(2);
            var entityStatus = (EntityStatus)Enum.ToObject(typeof(EntityStatus), reader.GetInt32(3));

            var commentEntityId = reader.GetInt32(4);
            var commentEntityType = reader.GetString(5);
            var commentAuthorId = reader.GetInt32(6);
            var commentAuthorType = reader.GetString(7);
            var commentText = reader.GetString(8);

            var commentEntity = EntityProviderFactory.GetEntityProvider(Type.GetType(commentEntityType)).GetEntity(commentEntityId);
            var commentAuthor = EntityProviderFactory.GetEntityProvider(Type.GetType(commentAuthorType)).GetEntity(commentAuthorId);

            var entity = new Comment(commentEntity, (Individual.Individual)commentAuthor)
            {
                IsReadOnly = false,
                Id = entityId,
                Created = entityCreated,
                Updated = entityUpdated,
                Status = entityStatus,
                Text = commentText
            };

            entity.IsReadOnly = true;

            return entity;
        }
    }
}
