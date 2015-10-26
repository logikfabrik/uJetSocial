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
    /// The <see cref="CommentProvider" /> class. The default provider for comments.
    /// </summary>
    public class CommentProvider : QueryableEntityProvider<Comment, ICommentCriteria, ICommentSortOrder>
    {
        private readonly IEntityProviderFactory _entityProviderFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentProvider" /> class.
        /// </summary>
        /// <param name="entityProviderFactory">The entity provider factory to use.</param>
        /// <param name="cacheManager">The cache manager to use.</param>
        /// <param name="databaseProvider">The database provider to use.</param>
        public CommentProvider(IEntityProviderFactory entityProviderFactory, ICacheManager cacheManager, IDatabaseProvider databaseProvider)
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
        protected override IQueryBuilder<ICommentCriteria, ICommentSortOrder> QueryBuilder => new CommentQueryBuilder();

        /// <summary>
        /// Gets a comment from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="id">The comment ID.</param>
        /// <returns>A comment.</returns>
        protected override Comment GetEntityFromDatabase(IDatabaseProvider provider, int id)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityCommentGet"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", id);

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
        /// Adds a comment to the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The comment to add.</param>
        /// <returns>The added comment.</returns>
        protected override Comment AddEntityToDatabase(IDatabaseProvider provider, Comment entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityCommentAdd"))
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
        /// Updates a comment in the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The comment to update.</param>
        /// <returns>The updated comment.</returns>
        protected override Comment UpdateEntityInDatabase(IDatabaseProvider provider, Comment entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityCommentUpdate"))
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
        /// Removes a comment from the database.
        /// </summary>
        /// <param name="provider">A database provider.</param>
        /// <param name="entity">The comment to remove.</param>
        protected override void RemoveEntityFromDatabase(IDatabaseProvider provider, Comment entity)
        {
            using (var connection = provider.GetConnection())
            {
                using (var command = provider.GetProcedureCommand(connection, "uJetCommunityCommentRemove"))
                {
                    provider.AddCommandParameter(command, DbType.Int32, "id", entity.Id);

                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the default cache key for a comment.
        /// </summary>
        /// <param name="id">The comment ID.</param>
        /// <returns>The default comment cache key.</returns>
        protected override string GetDefaultCacheKey(int id)
        {
            return Comment.GetDefaultCacheKey(id);
        }

        /// <summary>
        /// Gets a comment.
        /// </summary>
        /// <param name="reader">The data reader to read a comment from.</param>
        /// <returns>A comment.</returns>
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

            var commentEntity =
                _entityProviderFactory.GetEntityProvider(Type.GetType(commentEntityType)).GetEntity(commentEntityId);
            var commentAuthor =
                _entityProviderFactory.GetEntityProvider(Type.GetType(commentAuthorType)).GetEntity(commentAuthorId);

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
