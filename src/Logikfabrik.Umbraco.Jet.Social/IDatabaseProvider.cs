// <copyright file="IDatabaseProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System.Data;

    /// <summary>
    /// Represents the database provider interface.
    /// </summary>
    public interface IDatabaseProvider
    {
        /// <summary>
        /// Gets a connection.
        /// </summary>
        /// <returns>A connection.</returns>
        IDbConnection GetConnection();

        /// <summary>
        /// Gets a procedure command.
        /// </summary>
        /// <param name="connection">The command connection.</param>
        /// <param name="procedureName">The procedure name.</param>
        /// <returns>A procedure command.</returns>
        IDbCommand GetProcedureCommand(IDbConnection connection, string procedureName);

        /// <summary>
        /// Gets a command.
        /// </summary>
        /// <param name="connection">The command connection.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns>A command.</returns>
        IDbCommand GetCommand(IDbConnection connection, string commandText);

        /// <summary>
        /// Adds a command parameter.
        /// </summary>
        /// <param name="command">The command to add a parameter to.</param>
        /// <param name="type">The parameter data type.</param>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        void AddCommandParameter(IDbCommand command, DbType type, string name, object value);
    }
}
