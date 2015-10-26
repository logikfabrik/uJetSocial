// <copyright file="DatabaseProvider.cs" company="Logikfabrik">
//   Copyright (c) 2015 anton(at)logikfabrik.se. Licensed under the MIT license.
// </copyright>

namespace Logikfabrik.Umbraco.Jet.Social
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a database provider.
    /// </summary>
    public class DatabaseProvider : IDatabaseProvider
    {
        /// <summary>
        /// Gets a connection.
        /// </summary>
        /// <returns>A connection.</returns>
        public IDbConnection GetConnection()
        {
            var connectionString = GetConnectionString();

            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Gets a procedure command.
        /// </summary>
        /// <param name="connection">The command connection.</param>
        /// <param name="procedureName">The procedure name.</param>
        /// <returns>A procedure command.</returns>
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Commands created using this function are for executing stored procedures.")]
        public IDbCommand GetProcedureCommand(IDbConnection connection, string procedureName)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (string.IsNullOrWhiteSpace(procedureName))
            {
                throw new ArgumentException("Command text cannot be null or white space.", nameof(procedureName));
            }

            var command = new SqlCommand(procedureName, connection as SqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            return command;
        }

        /// <summary>
        /// Gets a command.
        /// </summary>
        /// <param name="connection">The command connection.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns>A command.</returns>
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Commands created using this function are for executing parameterised queries.")]
        public IDbCommand GetCommand(IDbConnection connection, string commandText)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (string.IsNullOrWhiteSpace(commandText))
            {
                throw new ArgumentException("Command text cannot be null or white space.", nameof(commandText));
            }

            var command = new SqlCommand(commandText, connection as SqlConnection)
            {
                CommandType = CommandType.Text
            };

            return command;
        }

        /// <summary>
        /// Adds a command parameter.
        /// </summary>
        /// <param name="command">The command to add a parameter to.</param>
        /// <param name="type">The parameter data type.</param>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public void AddCommandParameter(IDbCommand command, DbType type, string name, object value)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space.", nameof(name));
            }

            var parameter = command.CreateParameter();

            parameter.DbType = type;
            parameter.ParameterName = name;
            parameter.Value = value;

            command.Parameters.Add(parameter);
        }

        /// <summary>
        /// Gets the Umbraco connection string.
        /// </summary>
        /// <returns>The Umbraco connection string.</returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
        }
    }
}
