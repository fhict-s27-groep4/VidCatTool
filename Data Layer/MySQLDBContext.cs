﻿using Data_Layer.ErrorLog;
using Model_Layer.Interface;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class MySQLDBContext : IDBContext
    {
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
        private MySqlDataAdapter adapter;
        private IDataBaseErrorLogger errorLogger;

        private readonly string connectionString;

        public MySQLDBContext(string connectionstring)
        {
            connectionString = connectionstring;
            dbCommand = new MySqlCommand();
            dbConnection = new MySqlConnection(connectionString);
            adapter = new MySqlDataAdapter();
            errorLogger = new JSonLogger();
        }

        private void OpenConnection()
        {
            dbConnection.Open();
        }

        private void CloseConnection()
        {
            dbConnection.Close();
        }

        public IEnumerable<T> SelectQuery<T>()
        {
            Type type = typeof(T);

            string query = "SELECT * FROM " + type.Name;
            dbCommand = new MySqlCommand(query, dbConnection);
            IEnumerable<T> result = new List<T>();
            DataSet dataSet = new DataSet();
            dbCommand.CommandText = query;
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Parameters.Clear();
            try
            {
                dbConnection.CreateCommand();
                OpenConnection();
                adapter.SelectCommand = dbCommand;
                adapter.Fill(dataSet, type.Name);
            }
            catch (Exception exception)
            {
                Task.Run(() => errorLogger.LogDataBaseError(dbCommand.CommandText, exception.Message, exception.StackTrace, DateTime.Now.ToString()));
                Console.WriteLine(exception.Message);
            }
            finally
            {
                CloseConnection();
            }

            result = Converter.ConvertDatasetToModel<T>(dataSet);
            return result;
        }


        public void ExecuteStoredProcedure(string procedurename, DbParameter[] parameters)
        {
            dbCommand.CommandText = procedurename;
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Connection = dbConnection;
            dbCommand.Parameters.Clear();
            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    dbCommand.Parameters.Add(parameter);
                }
            }

            try
            {
                OpenConnection();
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Task.Run(() => errorLogger.LogDataBaseError(dbCommand.CommandText, exception.Message, exception.StackTrace, DateTime.Now.ToString()));
                Console.WriteLine(exception.Message);
                throw exception;
            }
            finally
            {
                CloseConnection();
            }
        }

        public IEnumerable<T> ExecuteReturnStoredProcedure<T>(string procedurename, DbParameter[] parameters)
        {
            Type type = typeof(T);
            dbCommand.CommandText = procedurename;
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Connection = dbConnection;
            adapter.SelectCommand = dbCommand;
            dbCommand.Parameters.Clear();
            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    dbCommand.Parameters.Add(parameter);
                }
            }
            DataSet dbSet = new DataSet();

            try
            {
                OpenConnection();
                adapter.Fill(dbSet, type.Name);
            }
            catch (Exception exception)
            {
                Task.Run(() => errorLogger.LogDataBaseError(dbCommand.CommandText, exception.Message, exception.StackTrace, DateTime.Now.ToString()));
                Console.WriteLine(exception.Message);
            }
            finally
            {
                CloseConnection();
            }

            return Converter.ConvertDatasetToModel<T>(dbSet);
        }

        public IEnumerable<IObjectPair<T1, T2>> ExecuteNonObjectStoredProcedure<T1, T2>(string procedurename, DbParameter[] parameters)
        {
            IList<IObjectPair<T1, T2>> items = new List<IObjectPair<T1, T2>>();
            dbCommand.CommandText = procedurename;
            dbCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = dbCommand;
            dbCommand.Connection = dbConnection;
            dbCommand.Parameters.Clear();
            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    dbCommand.Parameters.Add(parameter);
                }
            }

            try
            {
                OpenConnection();
                DbDataReader reader = dbCommand.ExecuteReader();
                while (reader.Read())
                {
                    items.Add(new ObjectPair<T1, T2>() { Object1 = (T1)reader.GetValue(0), Object2 = (T2)reader.GetValue(1) });
                }

            }
            catch (Exception exception)
            {
                Task.Run(() => errorLogger.LogDataBaseError(dbCommand.CommandText, exception.Message, exception.StackTrace, DateTime.Now.ToString()));
                Console.WriteLine(exception.Message);
            }
            finally
            {
                CloseConnection();
            }

            return items;
        }
    }


}
