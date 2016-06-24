// <copyright file="DataTransferObjectTypeAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Web.Http;
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Web.Mvc;

    /// <summary>
    /// The <see cref="DataTransferObjectTypeAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class DataTransferObjectTypeAPIController : APIController
    {
        private readonly Lazy<IDatabaseWrapper> _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectTypeAPIController" /> class.
        /// </summary>
        public DataTransferObjectTypeAPIController()
            : this(DatabaseWrapperFactory.GetDatabase)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTransferObjectTypeAPIController" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="database" /> is <c>null</c>.</exception>
        public DataTransferObjectTypeAPIController(Func<IDatabaseWrapper> database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            _database = new Lazy<IDatabaseWrapper>(database);
        }

        /// <summary>
        /// Gets the type of the data transfer object with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The type of the data transfer object with the specified identifier.</returns>
        [HttpGet]
        public object GetType(int id)
        {
            var sql = new Sql()
                .Select("*")
                .From<Entity>(_database.Value.SyntaxProvider)
                .LeftJoin<EntityType>(_database.Value.SyntaxProvider)
                .On<Entity, EntityType>(_database.Value.SyntaxProvider, e => e.TypeId, et => et.Id)
                .Where<Entity>(e => e.Id == id);

            var entity = _database.Value.Get<Entity>(sql);

            if (entity == null)
            {
                return null;
            }

            var type = Type.GetType(entity.Type, false);

            if (type == null)
            {
                return null;
            }

            return new
            {
                type.Name,
                type.FullName
            };
        }
    }
}