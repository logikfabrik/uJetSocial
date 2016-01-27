// <copyright file="DataTransferObjectAPIController{T}.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Http;
    using global::Umbraco.Web.Editors;
    using Models;

    /// <summary>
    /// The <see cref="DataTransferObjectAPIController{T}" /> class.
    /// </summary>
    /// <typeparam name="T">The data transfer object type.</typeparam>
    // ReSharper disable once InconsistentNaming
    public abstract class DataTransferObjectAPIController<T> : UmbracoAuthorizedJsonController
        where T : DataTransferObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectAPIController{T}" /> class.
        /// </summary>
        protected DataTransferObjectAPIController()
        {
            Provider = DataTransferObjectProviders.GetProvider(typeof(T)) as IDataTransferObjectProvider<T>;
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        protected IDataTransferObjectProvider<T> Provider { get; }

        /// <summary>
        /// Adds the specified data transfer object.
        /// </summary>
        /// <param name="dto">The data transfer object to add.</param>
        /// <returns>The added data transfer object.</returns>
        [HttpPost]
        public int Add(T dto)
        {
            return Provider.Add(dto).Id;
        }

        /// <summary>
        /// Updates the specified data transfer object.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        /// <param name="dto">The data transfer object to update.</param>
        /// <returns>The updated data transfer object.</returns>
        [HttpPost]
        public T Update(int id, T dto)
        {
            dto.Id = id;

            return Provider.Update(dto);
        }

        /// <summary>
        /// Gets the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The data transfer object identifier.</param>
        /// <returns>The data transfer object with the specified identifier.</returns>
        [HttpGet]
        public T Get(int id)
        {
            return Provider.Get(id);
        }

        /// <summary>
        /// Gets a query for querying the provider.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>A query.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="query" /> is <c>null</c>.</exception>
        protected Query<T> GetQuery(Query query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var q = new Query<T>(query.PageIndex, query.PageSize);

            if (query.CreatedFrom.HasValue)
            {
                q.Criterias.Add(obj => obj.Created >= query.CreatedFrom.Value);
            }

            if (query.CreatedTo.HasValue)
            {
                q.Criterias.Add(obj => obj.Created <= query.CreatedTo.Value);
            }

            if (query.UpdatedFrom.HasValue)
            {
                q.Criterias.Add(obj => obj.Created >= query.UpdatedFrom.Value);
            }

            if (query.UpdatedTo.HasValue)
            {
                q.Criterias.Add(obj => obj.Created <= query.UpdatedTo.Value);
            }

            if (query.Status.HasValue)
            {
                q.Criterias.Add(obj => obj.Status == (int)query.Status.Value);
            }

            if (query.OrderBy != null)
            {
                q.OrderBy = GetOrderBy(query.OrderBy);
            }

            return q;
        }

        private static Expression<Func<T, object>> GetOrderBy(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T), "obj");
            var property = typeof(T).GetProperty(propertyName);

            var expression = Expression.Convert(Expression.MakeMemberAccess(parameter, property), typeof(object));

            return Expression.Lambda<Func<T, object>>(expression, parameter);
        }
    }
}