// <copyright file="IDatabaseWrapper.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using global::Umbraco.Core.Persistence;
    using global::Umbraco.Core.Persistence.SqlSyntax;

    /// <summary>
    /// The <see cref="IDatabaseWrapper" /> interface.
    /// </summary>
    public interface IDatabaseWrapper : Data.IDatabaseWrapper
    {
        /// <summary>
        /// Gets the syntax provider.
        /// </summary>
        /// <value>
        /// The syntax provider.
        /// </value>
        ISqlSyntaxProvider SyntaxProvider { get; }

        /// <summary>
        /// Gets a transaction.
        /// </summary>
        /// <returns>A transaction.</returns>
        Transaction GetTransaction();

        /// <summary>
        /// Gets the object of the specified object type using the specified query.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="sql">The query.</param>
        /// <returns>The object.</returns>
        T Get<T>(Sql sql)
            where T : class;

        /// <summary>
        /// Pages the table of the specified object type for objects.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="sql">The query.</param>
        /// <returns>A table page.</returns>
        Page<T> Page<T>(int pageIndex, int pageSize, Sql sql)
            where T : class;

        /// <summary>
        /// Adds the specified object.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>The primary key.</returns>
        object Add<T>(T obj)
            where T : class;

        /// <summary>
        /// Deletes the object of the specified object type with the specified primary key.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="primaryKey">The primary key.</param>
        void Delete<T>(object primaryKey)
            where T : class;

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">The object.</param>
        void Update<T>(T obj)
            where T : class;
    }
}
