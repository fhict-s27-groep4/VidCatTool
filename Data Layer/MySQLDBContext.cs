using Model_Layer.Interface;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Data_Layer
{
    public class MySQLDBContext : IDBContext
    {
        private MySqlConnection dbConnection;
        private MySqlCommand dbCommand;
        private MySqlDataAdapter adapter;

        private string connectionString;

        public MySQLDBContext()
        {
            connectionString = "Server=blackmania.phy.sx;Port=3306;Database=blackman_VidCatTool;Uid=blackman_vidcattooluser;Pwd=]2T5~s&w(JD&";
            dbCommand = new MySqlCommand();
            dbConnection = new MySqlConnection(connectionString);
            adapter = new MySqlDataAdapter();
        }

        private void OpenConnection()
        {
            try
            {
                dbConnection.Open();
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private void CloseConnection()
        {
            try
            {
                dbConnection.Close();
            }
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
            }
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
            catch (DbException exception)
            {
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
            catch (DbException exception)
            {
                Console.WriteLine(exception.Message);
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
            catch (DbException exc)
            {
                Console.WriteLine(exc.Message);
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
            catch (DbException exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                CloseConnection();
            }

            return items;
        }
    }

    
}
