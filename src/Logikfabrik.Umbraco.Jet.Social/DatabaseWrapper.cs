// <copyright file="DatabaseWrapper.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using global::Umbraco.Core.Logging;
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Persistence.SqlSyntax;

    /// <summary>
    /// The <see cref="DatabaseWrapper" /> class.
    /// </summary>
    public class DatabaseWrapper : Data.DatabaseWrapper, IDatabaseWrapper
    {
        private readonly Database _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseWrapper" /> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="syntaxProvider">The syntax provider.</param>
        public DatabaseWrapper(Database database, ILogger logger, ISqlSyntaxProvider syntaxProvider)
            : base(database, logger, syntaxProvider)
        {
            _database = database;
            SyntaxProvider = syntaxProvider;
        }

        /// <summary>
        /// Gets the syntax provider.
        /// </summary>
        /// <value>
        /// The syntax provider.
        /// </value>
        public ISqlSyntaxProvider SyntaxProvider { get; }

        /// <summary>
        /// Gets a transaction.
        /// </summary>
        /// <returns>A transaction.</returns>
        public Transaction GetTransaction()
        {
            return _database.GetTransaction();
        }

        /// <summary>
        /// Pages the table of the specified object type for objects.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sql">The query.</param>
        /// <returns>A table page.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="sql" /> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="pageIndex" /> is less than <c>0</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="pageSize" /> is less than <c>1</c>.</exception>
        public Page<T> Page<T>(int pageIndex, int pageSize, Sql sql)
            where T : class
        {
            if (pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, "Page index cannot be less than 0.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Page size cannot be less than 1.");
            }

            if (sql == null)
            {
                throw new ArgumentNullException(nameof(sql));
            }

            // Min page index is 1.
            pageIndex++;

            return _database.Page<T>(pageIndex, pageSize, sql);
        }

        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>The primary key.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="obj" /> is <c>null</c>.</exception>
        public object Add<T>(T obj)
            where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var primaryKey = _database.Insert(obj);

            return primaryKey;
        }

        /// <summary>
        /// Deletes the object of the specified object type with the specified primary key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="primaryKey">The primary key.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="primaryKey" /> is <c>null</c>.</exception>
        public void Delete<T>(object primaryKey)
            where T : class
        {
            if (primaryKey == null)
            {
                throw new ArgumentNullException(nameof(primaryKey));
            }

            _database.Delete<T>(primaryKey);
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="obj" /> is <c>null</c>.</exception>
        public void Update<T>(T obj)
            where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            _database.Update(obj);
        }
    }
}
