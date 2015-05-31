// ===============================================================================
// Microsoft Data Access Application Block for .NET
// http://msdn.microsoft.com/library/en-us/dnbda/html/daab-rm.asp
//
// cs
//
// This file contains the implementations of the DbHelper and DbParameterCache
// classes.
//
// For more information see the Data Access Application Block Implementation Overview. 
// ===============================================================================
// Release history
// VERSION	DESCRIPTION
//   2.0	Added support for FillDataset, UpdateDataset and "Param" helper methods
//
// ===============================================================================
// Copyright (C) 2000-2001 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR
// FITNESS FOR A PARTICULAR PURPOSE.
// ==============================================================================

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace DBUtility
{
    /// <summary>
    /// The DbHelper class is intended to encapsulate high performance, scalable best practices for 
    /// common uses of SqlClient
    /// </summary>
    public abstract class DbHelper
    {
        #region private utility methods & constructors

        /// <summary>
        /// This method is used to attach array of DbParameters to a IDbCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of DbParameters to be added to command</param>
        private void AttachParameters(IDbCommand command, IDbDataParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (IDbDataParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The IDbCommand to be prepared</param>
        /// <param name="connection">A valid IDbConnection, on which to execute this command</param>
        /// <param name="transaction">A valid IDbTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of DbParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private void PrepareCommand(IDbCommand command, IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion private utility methods & constructors

        #region ExecuteNonQuery

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset and takes no parameters) against the database specified in 
        /// the connection string
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteNonQuery(commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("connectionString");

            // Create & open a IDbConnection, and dispose of it after we are done
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteNonQuery(connection, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(IDbConnection connection, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (IDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the DbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            if (mustCloseConnection)
                connection.Close();
            return retval;
        }

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset and takes no parameters) against the provided IDbTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteNonQuery(transaction, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns no resultset) against the specified IDbTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public int ExecuteNonQuery(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Finally, execute the command
            int retval = cmd.ExecuteNonQuery();

            // Detach the DbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }

        #endregion ExecuteNonQuery

        #region ExecuteDataset

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public DataSet ExecuteDataset(CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteDataset(commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public DataSet ExecuteDataset(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("connectionString");

            // Create & open a IDbConnection, and dispose of it after we are done
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                return ExecuteDataset(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public DataSet ExecuteDataset(IDbConnection connection, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteDataset(connection, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public DataSet ExecuteDataset(IDbConnection connection, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (IDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (DbDataAdapter da = CreateDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the DbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    connection.Close();

                // Return the dataset
                return ds;
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public DataSet ExecuteDataset(IDbTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteDataset(transaction, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public DataSet ExecuteDataset(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (DbDataAdapter da = CreateDataAdapter(cmd))
            {
                DataSet ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the DbParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                // Return the dataset
                return ds;
            }
        }

        #endregion ExecuteDataset

        #region ExecuteReader

        /// <summary>
        /// This enum is used to indicate whether the connection was provided by the caller, or created by DbHelper, so that
        /// we can set the appropriate CommandBehavior when calling ExecuteReader()
        /// </summary>
        private enum DbConnectionOwnership
        {
            /// <summary>Connection is owned and managed by DbHelper</summary>
            Internal,
            /// <summary>Connection is owned and managed by the caller</summary>
            External
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteReader(commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public IDataReader ExecuteReader(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("connectionString");
            IDbConnection connection = null;
            try
            {
                connection = CreateConnection();
                connection.Open();

                // Call the private overload that takes an internally owned connection in place of the connection string
                return ExecuteReader(connection, null, commandType, commandText, commandParameters, DbConnectionOwnership.Internal);
            }
            catch
            {
                // If we fail to return the SqlDatReader, we need to close the connection ourselves
                if (connection != null) connection.Close();
                throw;
            }

        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public IDataReader ExecuteReader(IDbConnection connection, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteReader(connection, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public IDataReader ExecuteReader(IDbConnection connection, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            // Pass through the call to the private overload using a null transaction value and an externally owned connection
            return ExecuteReader(connection, (IDbTransaction)null, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        /// <summary>
        /// Create and prepare a IDbCommand, and call ExecuteReader with the appropriate CommandBehavior.
        /// </summary>
        /// <remarks>
        /// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
        /// 
        /// If the caller provided the connection, we want to leave it to them to manage.
        /// </remarks>
        /// <param name="connection">A valid IDbConnection, on which to execute this command</param>
        /// <param name="transaction">A valid IDbTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of DbParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="connectionOwnership">Indicates whether the connection parameter was provided by the caller, or created by DbHelper</param>
        /// <returns>IDataReader containing the results of the command</returns>
        private IDataReader ExecuteReader(IDbConnection connection, IDbTransaction transaction, CommandType commandType, string commandText, IDbDataParameter[] commandParameters, DbConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

                // Create a reader
                IDataReader dataReader;

                // Call ExecuteReader with the appropriate CommandBehavior
                if (connectionOwnership == DbConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }

                // Detach the DbParameters from the command object, so they can be used again.
                // HACK: There is a problem here, the output parameter values are fletched 
                // when the reader is closed, so if the parameters are detached from the command
                // then the SqlReader can�t set its values. 
                // When this happen, the parameters can�t be used again in other command.
                bool canClear = true;
                foreach (IDbDataParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }

                if (canClear)
                {
                    cmd.Parameters.Clear();
                }

                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                    connection.Close();
                throw;
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  IDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public IDataReader ExecuteReader(IDbTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteReader(transaction, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///   IDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A IDataReader containing the resultset generated by the command</returns>
        public IDataReader ExecuteReader(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Pass through to private overload, indicating that the connection is owned by the caller
            return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, DbConnectionOwnership.External);
        }

        #endregion ExecuteReader

        #region ExecuteScalar

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteScalar(commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (ConnectionString == null || ConnectionString.Length == 0) throw new ArgumentNullException("connectionString");
            // Create & open a IDbConnection, and dispose of it after we are done
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                return ExecuteScalar(connection, commandType, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(IDbConnection connection, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteScalar(connection, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(IDbConnection connection, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();

            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (IDbTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the DbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            if (mustCloseConnection)
                connection.Close();

            return retval;
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset and takes no parameters) against the provided IDbTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(IDbTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of DbParameters
            return ExecuteScalar(transaction, commandType, commandText, (IDbDataParameter[])null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a 1x1 resultset) against the specified IDbTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public object ExecuteScalar(IDbTransaction transaction, CommandType commandType, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");

            // Create a command and prepare it for execution
            IDbCommand cmd = CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // Detach the DbParameters from the command object, so they can be used again
            cmd.Parameters.Clear();
            return retval;
        }

        #endregion ExecuteScalar

        #region FillDataset
        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)</param>
        public void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            // Create & open a IDbConnection, and dispose of it after we are done
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                FillDataset(connection, commandType, commandText, dataSet, tableNames);
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        public void FillDataset(string connectionString, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params IDbDataParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // Create & open a IDbConnection, and dispose of it after we are done
            using (IDbConnection connection = CreateConnection())
            {
                connection.Open();

                // Call the overload that takes a connection in place of the connection string
                FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
            }
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>    
        public void FillDataset(IDbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        public void FillDataset(IDbConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params IDbDataParameter[] commandParameters)
        {
            FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset and takes no parameters) against the provided IDbTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        public void FillDataset(IDbTransaction transaction, CommandType commandType,
            string commandText,
            DataSet dataSet, string[] tableNames)
        {
            FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
        }

        /// <summary>
        /// Execute a IDbCommand (that returns a resultset) against the specified IDbTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        public void FillDataset(IDbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params IDbDataParameter[] commandParameters)
        {
            FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
        }

        /// <summary>
        /// Private helper method that execute a IDbCommand (that returns a resultset) against the specified IDbTransaction and IDbConnection
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(conn, trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new IDbDataParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid IDbConnection</param>
        /// <param name="transaction">A valid IDbTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        private void FillDataset(IDbConnection connection, IDbTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params IDbDataParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (dataSet == null) throw new ArgumentNullException("dataSet");

            // Create a command and prepare it for execution
            IDbCommand command = CreateCommand();
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);

            // Create the DataAdapter & DataSet
            using (DbDataAdapter dataAdapter = CreateDataAdapter(command))
            {

                // Add the table mappings specified by the user
                if (tableNames != null && tableNames.Length > 0)
                {
                    string tableName = "Table";
                    for (int index = 0; index < tableNames.Length; index++)
                    {
                        if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                        tableName += (index + 1).ToString();
                    }
                }

                // Fill the DataSet using default values for DataTable names, etc
                dataAdapter.Fill(dataSet);

                // Detach the DbParameters from the command object, so they can be used again
                command.Parameters.Clear();
            }

            if (mustCloseConnection)
                connection.Close();
        }
        #endregion

        #region UpdateDataset
        /// <summary>
        /// Executes the respective command for each inserted, updated, or deleted row in the DataSet.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  UpdateDataset(conn, insertCommand, deleteCommand, updateCommand, dataSet, "Order");
        /// </remarks>
        /// <param name="insertCommand">A valid transact-SQL statement or stored procedure to insert new records into the data source</param>
        /// <param name="deleteCommand">A valid transact-SQL statement or stored procedure to delete records from the data source</param>
        /// <param name="updateCommand">A valid transact-SQL statement or stored procedure used to update records in the data source</param>
        /// <param name="dataSet">The DataSet used to update the data source</param>
        /// <param name="tableName">The DataTable used to update the data source.</param>
        public void UpdateDataset(IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand, DataSet dataSet, string tableName)
        {
            if (insertCommand == null) throw new ArgumentNullException("insertCommand");
            if (deleteCommand == null) throw new ArgumentNullException("deleteCommand");
            if (updateCommand == null) throw new ArgumentNullException("updateCommand");
            if (tableName == null || tableName.Length == 0) throw new ArgumentNullException("tableName");

            // Create a DbDataAdapter, and dispose of it after we are done
            using (DbDataAdapter dataAdapter = CreateDataAdapter(null,
                insertCommand, deleteCommand, updateCommand))
            {
                // Update the dataset changes in the data source
                dataAdapter.Update(dataSet, tableName);

                // Commit all the changes made to the DataSet
                dataSet.AcceptChanges();
            }
        }

        #endregion

        /// <summary>
        /// 创建一个DbHelper的子类的实例，通过反射类名创建
        /// </summary>
        /// <param name="className">不区分大小写，可选值：MySql、OleDb、Oracle、SQLite、SqlServer</param>
        public static DbHelper Create(string className)
        {
            Type type = Type.GetType("DBUtility." + className, true, true);
            ConstructorInfo ci = type.GetConstructor(new Type[] { });
            return (DbHelper)ci.Invoke(null);
        }

        /// <summary>
        /// 获取或设置数据库连接
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 创建IDbConnection的实例
        /// </summary>
        public abstract IDbConnection CreateConnection();

        /// <summary>
        /// 创建IDbCommand的实例
        /// </summary>
        public abstract IDbCommand CreateCommand();

        /// <summary>
        /// 创建DbDataAdapter的实例
        /// </summary>
        public abstract DbDataAdapter CreateDataAdapter(IDbCommand selectCommand,
            IDbCommand insertCommand, IDbCommand deleteCommand, IDbCommand updateCommand);

        /// <summary>
        /// 创建DbDataAdapter的实例
        /// </summary>
        public DbDataAdapter CreateDataAdapter(IDbCommand cmd)
        {
            DbDataAdapter adapter = CreateDataAdapter(cmd, null, null, null);
            return adapter;
        }

        #region CreateDbParameter

        /// <summary>
        /// 创建IDbDataParameter的实例
        /// </summary>
        public abstract IDbDataParameter CreateDbParameter(string parameterName);

        /// <summary>
        /// 创建IDbDataParameter的实例
        /// </summary>
        public IDbDataParameter CreateDbParameter(string parameterName, ParameterDirection direction, object value)
        {
            IDbDataParameter param = CreateDbParameter(parameterName);
            param.Direction = direction;
            param.Value = value;
            return param;
        }

        /// <summary>
        /// 创建IDbDataParameter的实例
        /// </summary>
        public IDbDataParameter CreateDbParameter(string parameterName, DbType dbType, ParameterDirection direction, object value)
        {
            IDbDataParameter param = CreateDbParameter(parameterName);
            param.DbType = dbType;
            param.Direction = direction;
            param.Value = value;
            return param;
        }

        /// <summary>
        /// 创建IDbDataParameter的实例
        /// </summary>
        public IDbDataParameter CreateDbParameter(string parameterName, DbType dbType, ParameterDirection direction)
        {
            return CreateDbParameter(parameterName, dbType, 0, direction);
        }

        /// <summary>
        /// 创建IDbDataParameter的实例
        /// </summary>
        public IDbDataParameter CreateDbParameter(string parameterName, DbType dbType, int size, ParameterDirection direction)
        {
            IDbDataParameter param = CreateDbParameter(parameterName);
            param.DbType = dbType;
            if (size > 0) param.Size = size;
            param.Direction = direction;
            return param;
        }

        #endregion
    }

    /// <summary>
    /// DbParameterCache provides functions to leverage a static cache of procedure parameters, and the
    /// ability to discover parameters for stored procedures at run-time.
    /// </summary>
    public sealed class DbParameterCache
    {
        #region private methods, variables, and constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new DbParameterCache()"
        private DbParameterCache() { }

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Deep copy of cached IDbDataParameter array
        /// </summary>
        /// <param name="originalParameters"></param>
        /// <returns></returns>
        private static IDbDataParameter[] CloneParameters(IDbDataParameter[] originalParameters)
        {
            IDbDataParameter[] clonedParameters = new IDbDataParameter[originalParameters.Length];

            for (int i = 0, j = originalParameters.Length; i < j; i++)
            {
                clonedParameters[i] = (IDbDataParameter)((ICloneable)originalParameters[i]).Clone();
            }

            return clonedParameters;
        }

        #endregion private methods, variables, and constructors

        #region caching functions

        /// <summary>
        /// Add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters to be cached</param>
        public static void CacheParameterSet(string connectionString, string commandText, params IDbDataParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// Retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">A valid connection string for a IDbConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An array of SqlParamters</returns>
        public static IDbDataParameter[] GetCachedParameterSet(string connectionString, string commandText)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            string hashKey = connectionString + ":" + commandText;

            IDbDataParameter[] cachedParameters = paramCache[hashKey] as IDbDataParameter[];
            if (cachedParameters == null)
            {
                return null;
            }
            else
            {
                return CloneParameters(cachedParameters);
            }
        }

        #endregion caching functions
    }

    /// <summary>
    /// 由Object取值
    /// </summary>
    public sealed class DbValue
    {
        /// <summary>
        /// 取得Int16值
        /// </summary>
        public static Int16? GetInt16(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                short result;
                if (Int16.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得UInt16值
        /// </summary>
        public static UInt16? GetUInt16(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                ushort result;
                if (UInt16.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得Int值
        /// </summary>
        public static int? GetInt(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                int result;
                if (int.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得UInt值
        /// </summary>
        public static uint? GetUInt(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                uint result;
                if (uint.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得UInt64值
        /// </summary>
        public static ulong? GetULong(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                ulong result;
                if (ulong.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得byte值
        /// </summary>
        public static byte? GetByte(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                byte result;
                if (byte.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得sbyte值
        /// </summary>
        public static sbyte? GetSByte(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                sbyte result;
                if (sbyte.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得Long值
        /// </summary>
        public static long? GetLong(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                long result;
                if (long.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得Decimal值
        /// </summary>
        public static decimal? GetDecimal(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                decimal result;
                if (decimal.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得float值
        /// </summary>
        public static float? GetFloat(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                float result;
                if (float.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null; ;
            }
        }

        /// <summary>
        /// 取得double值
        /// </summary>
        public static double? GetDouble(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                double result;
                if (double.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得Guid值
        /// </summary>
        public static Guid? GetGuid(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                try
                {
                    Guid result = new Guid(obj.ToString());
                    return result;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得DateTime值
        /// </summary>
        public static DateTime? GetDateTime(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                DateTime result;
                if (DateTime.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得bool值
        /// </summary>
        public static bool? GetBool(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                bool result;
                if (bool.TryParse(obj.ToString(), out result))
                    return result;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得byte[]
        /// </summary>
        public static byte[] GetBinary(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return (byte[])obj;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得string值
        /// </summary>
        public static string GetString(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
