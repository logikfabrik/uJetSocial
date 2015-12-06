// <copyright file="DataTransferObjectProvider{T}.cs" company="Logikfabrik">
//  Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using global::Umbraco.Core.Persistence;

    /// <summary>
    /// The <see cref="DataTransferObjectProvider{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The <see cref="DataTransferObject" /> type.</typeparam>
    public abstract class DataTransferObjectProvider<T> : IDataTransferObjectProvider<T>
        where T : DataTransferObject
    {
        private readonly Database _database;
        private readonly Lazy<int> _typeId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectProvider{T}" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        protected DataTransferObjectProvider(Database database)
        {
            _database = database;
            _typeId = new Lazy<int>(GetTypeId);

            CreateTables();
        }

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
        public T Get(int id)
        {
            var sql = new Sql().Select("*")
                .From<T>()
                .Where<T>(obj => obj.Id == id);

            var dto = _database.SingleOrDefault<T>(sql);

            dto.IsReadOnly = true;

            return dto;
        }

        /// <summary>
        /// Adds the specified <see cref="DataTransferObject" /> of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> of type <typeparamref name="T" />.</param>
        /// <returns>The <see cref="DataTransferObject" /> of type <typeparamref name="T" /> identifier.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="dto" /> is read-only.</exception>
        public int Add(T dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (dto.IsReadOnly)
            {
                throw new InvalidOperationException("The specified data transfer object is read-only. A read-only object can not be added.");
            }

            int id;

            using (var transaction = _database.GetTransaction())
            {
                var entity = new Entity
                {
                    TypeId = _typeId.Value
                };

                id = decimal.ToInt32((decimal)_database.Insert(entity));

                dto.Id = id;

                _database.Insert(dto);

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

            var sql = new Sql().Select("*")
                .From<T>();

            if (query.Criterias.Any())
            {
                sql = query.Criterias.Aggregate(sql, (current, criteria) => current.Where(criteria));
            }

            if (query.OrderBy != null)
            {
                // TODO: Order by.
            }

            return _database.Page<T>(query.PageIndex, query.PageSize, sql).Items;
        }

        /// <summary>
        /// Updates the specified <see cref="DataTransferObject" /> of type <typeparamref name="T" />.
        /// </summary>
        /// <param name="dto">The <see cref="DataTransferObject" /> of type <typeparamref name="T" />.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dto" /> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown if <paramref name="dto" /> is read-only.</exception>
        public void Update(T dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            if (dto.IsReadOnly)
            {
                throw new InvalidOperationException("The specified data transfer object is read-only. A read-only object can not be updated.");
            }

            _database.Save(dto);
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
            using (var transaction = _database.GetTransaction())
            {
                _database.Delete<T>(id);
                _database.Delete<Entity>(id);

                transaction.Complete();
            }
        }

        /// <summary>
        /// Gets the table name for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The table name for the specified type.</returns>
        private static string GetTableName(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var attribute = type.GetCustomAttribute<TableNameAttribute>();

            return attribute?.Value;
        }

        /// <summary>
        /// Creates the tables.
        /// </summary>
        private void CreateTables()
        {
            if (!_database.TableExist(GetTableName(typeof(EntityType))))
            {
                _database.CreateTable(true, typeof(EntityType));
            }

            if (!_database.TableExist(GetTableName(typeof(Entity))))
            {
                _database.CreateTable(true, typeof(Entity));
            }

            if (_database.TableExist(GetTableName(typeof(T))))
            {
                return;
            }

            _database.CreateTable(true, typeof(T));
        }

        /// <summary>
        /// Gets the type identifier.
        /// </summary>
        /// <returns>The type identifier.</returns>
        private int GetTypeId()
        {
            var typeName = typeof(T).AssemblyQualifiedName;

            var sql = new Sql().Select("*").From<EntityType>().Where<EntityType>(obj => obj.Type == typeName);

            var entityType = _database.SingleOrDefault<EntityType>(sql);

            if (entityType != null)
            {
                return entityType.Id;
            }

            entityType = new EntityType { Type = typeName };

            return decimal.ToInt32((decimal)_database.Insert(entityType));
        }
    }
}
