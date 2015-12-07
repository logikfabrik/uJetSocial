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
        private readonly IDatabaseWrapper _databaseWrapper;
        private readonly Lazy<int> _typeId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectProvider{T}" /> class.
        /// </summary>
        /// <param name="databaseWrapper">The database wrapper.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="databaseWrapper" /> is <c>null</c>.</exception>
        protected DataTransferObjectProvider(IDatabaseWrapper databaseWrapper)
        {
            if (databaseWrapper == null)
            {
                throw new ArgumentNullException(nameof(databaseWrapper));
            }

            _databaseWrapper = databaseWrapper;
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
            var dto = _databaseWrapper.Get<T>(id);

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

            using (var transaction = _databaseWrapper.GetTransaction())
            {
                var entity = new Entity
                {
                    TypeId = _typeId.Value
                };

                id = decimal.ToInt32((decimal)_databaseWrapper.Add(entity));

                dto.Id = id;

                _databaseWrapper.Add(dto);

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

            return _databaseWrapper.Page<T>(query.PageIndex, query.PageSize, sql).Items;
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

            _databaseWrapper.Update(dto);
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
            using (var transaction = _databaseWrapper.GetTransaction())
            {
                _databaseWrapper.Delete<T>(id);
                _databaseWrapper.Delete<Entity>(id);

                transaction.Complete();
            }
        }

        /// <summary>
        /// Creates the tables.
        /// </summary>
        private void CreateTables()
        {
            if (!_databaseWrapper.TableExists(typeof(EntityType)))
            {
                _databaseWrapper.CreateTable(typeof(EntityType));
            }

            if (!_databaseWrapper.TableExists(typeof(Entity)))
            {
                _databaseWrapper.CreateTable(typeof(Entity));
            }

            if (_databaseWrapper.TableExists(typeof(T)))
            {
                return;
            }

            _databaseWrapper.CreateTable(typeof(T));
        }

        /// <summary>
        /// Gets the type identifier.
        /// </summary>
        /// <returns>The type identifier.</returns>
        private int GetTypeId()
        {
            var typeName = typeof(T).AssemblyQualifiedName;

            var sql = new Sql().Where<EntityType>(obj => obj.Type == typeName);

            var entityType = _databaseWrapper.Get<EntityType>(sql);

            if (entityType != null)
            {
                return entityType.Id;
            }

            entityType = new EntityType { Type = typeName };

            return decimal.ToInt32((decimal)_databaseWrapper.Add(entityType));
        }
    }
}
