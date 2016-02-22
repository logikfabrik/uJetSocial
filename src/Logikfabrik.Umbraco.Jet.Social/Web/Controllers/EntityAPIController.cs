﻿// <copyright file="EntityAPIController.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

using Umbraco.Core.Logging;
using Umbraco.Core.ObjectResolution;
using Umbraco.Core.Persistence;

namespace Logikfabrik.Umbraco.Jet.Social.Web.Controllers
{
    using System;
    using System.Web.Http;
    using global::Umbraco.Web.Mvc;
    using global::Umbraco.Web.Editors;
    using Models;

    /// <summary>
    /// The <see cref="EntityAPIController" /> class.
    /// </summary>
    [PluginController("uJetSocial")]

    // ReSharper disable once InconsistentNaming
    public class EntityAPIController : UmbracoAuthorizedJsonController
    {
        private readonly Lazy<IDatabaseWrapper> _database;

        public EntityAPIController()
            : this(GetDatabase())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAPIController" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="database" /> is <c>null</c>.</exception>
        public EntityAPIController(Func<IDatabaseWrapper> database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }

            _database = new Lazy<IDatabaseWrapper>(database);
        }

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

        private static Func<IDatabaseWrapper> GetDatabase()
        {
            var context = global::Umbraco.Core.ApplicationContext.Current.DatabaseContext;

            return () => new DatabaseWrapper(context.Database, ResolverBase<LoggerResolver>.Current.Logger, context.SqlSyntax);
        }
    }
}