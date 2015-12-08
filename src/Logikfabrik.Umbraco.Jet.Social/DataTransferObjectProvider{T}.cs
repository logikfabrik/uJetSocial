// <copyright file="DataTransferObjectProvider{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="DataTransferObjectProvider{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="DataTransferObject" /> type.</typeparam>
    public abstract class DataTransferObjectProvider<T> : IDataTransferObjectProvider<T>
        where T : DataTransferObject
    {
        private readonly Lazy<int> _typeId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectProvider{T}" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="database" /> is <c>null</c>.</exception>
        protected DataTransferObjectProvider(IDatabaseWrapper database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            Database = database;
            _typeId = new Lazy<int>(GetTypeId);

            CreateTables();
        }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        protected IDatabaseWrapper Database { get; }

        /// <summary>
        /// Updates the specified <see cref="DataTransferObject" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" />.</param>
        void IDataTransferObjectProvider.Update(DataTransferObject dto)
        {
            Update((T)dto);
        }

        /// <summary>
        /// Gets the <see cref="DataTransferObject" /> of type <typeparamref name="T" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="DataTransferObject" /> of type <typeparamref name="T" /> identifier.</param>
        /// <returns>The <see cref="DataTransferObject" /> of type <typeparamref name="T" />.</returns>
        public virtual T Get(int id)
        {
            var dto = Database.Get<T>(id);

            if (dto == null)
            {
                return null;
            }

            dto.IsReadOnly = true;

            return dto;
        }

        /// <summary>
        /// Adds the specified <see cref="DataTransferObject" /> of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> of type <typeparamref name="T" />.</param>
        /// <returns>The <see cref="DataTransferObject" /> of type <typeparamref name="T" /> identifier.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public int Add(T dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DataTransferObjectValidator.ThrowIfReadOnly(dto);

            int id;

            using (var transaction = Database.GetTransaction())
            {
                var entity = new Entity
                {
                    TypeId = _typeId.Value
                };

                id = decimal.ToInt32((decimal)Database.Add(entity));

                dto.Id = id;

                Database.Add(dto);

                transaction.Complete();
            }

            return id;
        }

        /// <summary>
        /// Queries the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Matching <see cref="DataTransferObject" /> instances of type <typeparamref name="T" />.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="query" /> is <c>null</c>.</exception>
        public IEnumerable<T> Query(Query<T> query)
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

            if (query.OrderBy != null)
            {
                // TODO: Order by.
            }

            return Database.Page<T>(query.PageIndex, query.PageSize, sql).Items;
        }

        /// <summary>
        /// Updates the specified <see cref="DataTransferObject" /> of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> of type <typeparamref name="T" />.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        public void Update(T dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            DataTransferObjectValidator.ThrowIfReadOnly(dto);

            Database.Update(dto);
        }

        /// <summary>
        /// Gets the <see cref="DataTransferObject" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="DataTransferObject" /> identifier.</param>
        /// <returns>The <see cref="DataTransferObject" />.</returns>
        DataTransferObject IDataTransferObjectProvider.Get(int id)
        {
            return Get(id);
        }

        /// <summary>
        /// Adds the specified <see cref="DataTransferObject" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" />.</param>
        /// <returns>The <see cref="DataTransferObject" /> identifier.</returns>
        int IDataTransferObjectProvider.Add(DataTransferObject dto)
        {
            return Add((T)dto);
        }

        /// <summary>
        /// Removes the <see cref="DataTransferObject" /> with the specified identifier.
        /// </summary>
        /// <param name="id">The <see cref="DataTransferObject" /> identifier.</param>
        public void Remove(int id)
        {
            using (var transaction = Database.GetTransaction())
            {
                Database.Delete<T>(id);
                Database.Delete<Entity>(id);

                transaction.Complete();
            }
        }

        protected Type GetType(int entityId)
        {
            var sql = new Sql()
                .Select("*")
                .From<Entity>()
                .LeftJoin<EntityType>()
                .On<Entity, EntityType>(e => e.TypeId, et => et.Id)
                .Where<Entity>(obj => obj.Id == entityId);

            var entity = Database.Get<Entity>(sql);

            return entity == null ? null : Type.GetType(entity.Type, false);
        }

        /// <summary>
        /// Creates the tables.
        /// </summary>
        private void CreateTables()
        {
            if (!Database.TableExists(typeof(EntityType)))
            {
                Database.CreateTable(typeof(EntityType));
            }

            if (!Database.TableExists(typeof(Entity)))
            {
                Database.CreateTable(typeof(Entity));
            }

            if (Database.TableExists(typeof(T)))
            {
                return;
            }

            Database.CreateTable(typeof(T));
        }

        /// <summary>
        /// Gets the type identifier.
        /// </summary>
        /// <returns>The type identifier.</returns>
        private int GetTypeId()
        {
            var typeName = typeof(T).AssemblyQualifiedName;

            var sql = new Sql().Where<EntityType>(obj => obj.Type == typeName);

            var entityType = Database.Get<EntityType>(sql);

            if (entityType != null)
            {
                return entityType.Id;
            }

            entityType = new EntityType { Type = typeName };

            return decimal.ToInt32((decimal)Database.Add(entityType));
        }
    }
}
