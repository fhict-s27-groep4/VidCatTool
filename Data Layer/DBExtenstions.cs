using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace Data_Layer
{
    public static class DBExtenstions
    {
        private static IDBContext OpenConnection(this IDBContext context)
        {
            try
            {
                context.DbConnection.Open();
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return context;
        }

        private static IDBContext CloseConnection(this IDBContext context)
        {
            try
            {
                context.DbConnection.Close();
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return context;
        }

        public static IEnumerable<T> SelectQuery<T>(this IDBContext context)
        {
            Type type = typeof(T);

            string query = "SELECT * FROM " + type.Name;
            IEnumerable<T> result = new List<T>();
            DataSet dataSet = new DataSet();
            context.DbCommand.CommandText = query;
            context.DbCommand.CommandType = CommandType.Text;
            context.DbCommand.Parameters.Clear();
            try
            {
                context.OpenConnection();
                context.DataAdapter.SelectCommand = context.DbCommand;
                context.DataAdapter.Fill(dataSet, type.Name);
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                context.CloseConnection();
            }

            result = Converter.ConvertDatasetToModel<T>(dataSet);
            return result;
        }

        public static void AddEntity<T>(T entity)
        {

        }

        // Specifiek voor MySQL. Werkt niet voor andere databases
        public static void ExecuteStoredProcedure(this IDBContext context, string procedurename, MySqlParameter[] parameters)
        {
            context.DbCommand.CommandText = procedurename;
            context.DbCommand.CommandType = CommandType.StoredProcedure;
            context.DbCommand.Parameters.Clear();
            foreach (MySqlParameter parameter in parameters)
            {
                context.DbCommand.Parameters.Add(parameter);
            }

            try
            {
                context.OpenConnection();
                context.DbCommand.ExecuteNonQuery();
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                context.CloseConnection();
            }
        }

        public static IEnumerable<T> ExecuteReturnStoredProcedure<T>(this IDBContext context, string procedurename, MySqlParameter[] parameters)
        {
            Type type = typeof(T);
            context.DbCommand.CommandText = procedurename;
            context.DbCommand.CommandType = CommandType.StoredProcedure;
            context.DataAdapter.SelectCommand = context.DbCommand;
            context.DbCommand.Parameters.Clear();
            foreach (MySqlParameter parameter in parameters)
            {
                context.DbCommand.Parameters.Add(parameter);
            }
            DataSet dbSet = new DataSet();

            try
            {
                context.OpenConnection();
                context.DataAdapter.Fill(dbSet, type.Name);
            }
            catch(DbException exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                context.CloseConnection();
            }

            return Converter.ConvertDatasetToModel<T>(dbSet);
        }
    }
}
