// <copyright file="DataTransferObjectProvider{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Linq;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="DataTransferObjectProvider{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    public abstract class DataTransferObjectProvider<T> : IDataTransferObjectProvider<T>
        where T : DataTransferObject
    {
        private readonly Lazy<IDatabaseWrapper> _database;
        private readonly Lazy<int> _typeId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectProvider{T}" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="database" /> is <c>null</c>.</exception>
        protected DataTransferObjectProvider(Func<IDatabaseWrapper> database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            _database = new Lazy<IDatabaseWrapper>(() =>
            {
                var db = database();

                CreateTables(db);

                return db;
            });

            _typeId = new Lazy<int>(GetEntityTypeId);
        }

        /// <summary>
        /// Updates the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object to update.</param>
        /// <returns>
        /// The updated data transfer object object.
        /// </returns>
        DataTransferObject IDataTransferObjectProvider.Update(DataTransferObject dto)
        {
            return Update((T)dto);
        }

        /// <summary>
        /// Gets the data transfer object of type <typeparamref name="T" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        /// <returns>
        /// The data transfer object of type <typeparamref name="T" /> with the specified identifier.
        /// </returns>
        public virtual T Get(int id)
        {
            var dto = _database.Value.Get<T>(id);

            if (dto == null)
            {
                return null;
            }

            dto.IsReadOnly = true;

            return dto;
        }

        /// <summary>
        /// Adds the specified data transfer object of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The data transfer object of type <typeparamref name="T" /> to add.</param>
        /// <returns>
        /// The added data transfer object of type <typeparamref name="T" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public T Add(T dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DataTransferObjectValidator.ThrowIfReadOnly(dto);

            int id;

            using (var transaction = _database.Value.GetTransaction())
            {
                var entity = new Entity
                {
                    TypeId = _typeId.Value
                };

                id = decimal.ToInt32((decimal)_database.Value.Add(entity));

                dto.Id = id;

                _database.Value.Add(dto);

                transaction.Complete();
            }

            dto.Id = id;
            dto.IsReadOnly = true;

            return dto;
        }

        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// Matching data transfer object instances of type <typeparamref name="T" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="query" /> is <c>null</c>.</exception>
        public QueryResult<T> Query(Query<T> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var sql = new Sql();

            if (query.Criterias.Any())
            {
                sql = query.Criterias.Aggregate(sql, (current, criteria) => current.Where(criteria));
            }

            sql = query.OrderBy != null
                ? sql.OrderBy<T>(query.OrderBy, _database.Value.SyntaxProvider)
                : sql.OrderBy<T>(obj => obj.Created, _database.Value.SyntaxProvider);

            var page = _database.Value.Page<T>(query.PageIndex, query.PageSize, sql);

            return new QueryResult<T>
            {
                Total = page.TotalItems,
                Objects = page.Items
            };
        }

        /// <summary>
        /// Updates the specified data transfer object of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The data transfer object of type <typeparamref name="T" /> to update.</param>
        /// <returns>
        /// The updated data transfer object of type <typeparamref name="T" />.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public T Update(T dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DataTransferObjectValidator.ThrowIfReadOnly(dto);

            _database.Value.Update(dto);

            dto.IsReadOnly = true;

            return dto;
        }

        /// <summary>
        /// Gets the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        /// <returns>
        /// The data transfer object with the specified identifier.
        /// </returns>
        DataTransferObject IDataTransferObjectProvider.Get(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Adds the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object to add.</param>
        /// <returns>
        /// The added data transfer object.
        /// </returns>
        DataTransferObject IDataTransferObjectProvider.Add(DataTransferObject dto)
        {
            return Add((T)dto);
        }

        /// <summary>
        /// Removes the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        public void Remove(int id)
        {
            using (var transaction = _database.Value.GetTransaction())
            {
                _database.Value.Delete<T>(id);
                _database.Value.Delete<Entity>(id);

                transaction.Complete();
            }
        }

        /// <summary>
        /// Gets the entity type with the specified identifier.
        /// </summary>
        /// <param name="id">The entity type identifier.</param>
        /// <returns>The entity type with the specified identifier.</returns>
        protected Type GetEntityType(int id)
        {
            var sql = new Sql()
                .Select("*")
                .From<Entity>(_database.Value.SyntaxProvider)
                .LeftJoin<EntityType>(_database.Value.SyntaxProvider)
                .On<Entity, EntityType>(_database.Value.SyntaxProvider, e => e.TypeId, et => et.Id)
                .Where<Entity>(e => e.Id == id);

            var entity = _database.Value.Get<Entity>(sql);

            return entity == null ? null : Type.GetType(entity.Type, false);
        }

        /// <summary>
        /// Creates the tables.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="database" /> is <c>null</c>.</exception>
        private void CreateTables(IDatabaseWrapper database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            if (!database.TableExists(typeof(EntityType)))
            {
                database.CreateTable(typeof(EntityType));
            }

            if (!database.TableExists(typeof(Entity)))
            {
                database.CreateTable(typeof(Entity));
            }

            if (database.TableExists(typeof(T)))
            {
                return;
            }

            database.CreateTable(typeof(T));
        }

        /// <summary>
        /// Gets the entity type identifier.
        /// </summary>
        /// <returns>The entity type identifier</returns>
        private int GetEntityTypeId()
        {
            var typeName = typeof(T).AssemblyQualifiedName;

            var sql = new Sql().Where<EntityType>(et => et.Type == typeName);

            var entityType = _database.Value.Get<EntityType>(sql);

            if (entityType != null)
            {
                return entityType.Id;
            }

            entityType = new EntityType { Type = typeName };

            return decimal.ToInt32((decimal)_database.Value.Add(entityType));
        }
    }
}
