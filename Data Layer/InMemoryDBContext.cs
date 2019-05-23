using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Model_Layer.Interface;

namespace Data_Layer
{
    public class InMemoryDBContext : IDBContext
    {
        private SqlConnection dbConnection;
        private SqlCommand dbCommand;
        private SqlDataAdapter adapter;

        private DataSet dataSet;

        public InMemoryDBContext()
        {
            dbConnection = new SqlConnection();
            dbCommand = new SqlCommand();
            adapter = new SqlDataAdapter();

            dataSet = new DataSet("vidCatTool");
            DataTable table = new DataTable("Category");
            table.Columns.Add(new DataColumn("Name"));
            DataRow dr = table.NewRow();
            dr["Name"] = "Handsome";
            dataSet.Tables.Add(table);
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
            throw new NotImplementedException();
        }


        public void ExecuteStoredProcedure(string procedurename, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteReturnStoredProcedure<T>(string procedurename, DbParameter[] parameters)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<IObjectPair<T1, T2>> ExecuteNonObjectStoredProcedure<T1, T2>(string procedurename, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
