using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data_Layer
{
    public class MySQLDBContext : IDBContext
    {
        private DbConnection dbConnection;
        private DbCommand dbCommand;
        private DbDataAdapter adapter;

        private string connectionString;

        public MySQLDBContext()
        {
            connectionString = "Server=blackmania.phy.sx;Port=3306;Database=blackman_VidCatTool;Uid=blackman_vidcattooluser;Pwd=]2T5~s&w(JD&";
        }


        public DbConnection DbConnection
        {
            get
            {
                if (dbConnection == null)
                {
                    dbConnection = new MySqlConnection(connectionString);
                }
                return dbConnection;
            }
            set
            {
                dbConnection = value;
            }
        }
        public DbCommand DbCommand
        {
            get
            {
                if (dbCommand == null)
                {
                    dbCommand = new MySqlCommand();
                    dbCommand.Connection = DbConnection;
                }
                return dbCommand;
            }
            set
            {
                dbCommand = value;
            }
        }

        public DbDataAdapter DataAdapter
        {
            get
            {
                if (adapter == null)
                {
                    adapter = new MySqlDataAdapter();
                }
                return adapter;
            }
            set
            {
                adapter = value;
            }
        }
    }
}
