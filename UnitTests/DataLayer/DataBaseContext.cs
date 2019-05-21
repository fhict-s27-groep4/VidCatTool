using System;
using System.Collections.Generic;
using System.Data.Common;
using Data_Layer;

namespace UnitTests.DataLayer
{
    internal class DataBaseContext : IDBContext
    {
        public DbConnection DbConnection => throw new System.NotImplementedException();

        public DbCommand DbCommand => throw new System.NotImplementedException();

        public DbDataAdapter DataAdapter => throw new System.NotImplementedException();

        public IEnumerable<Tuple<int, string>> ExecuteNonObjectStoredProcedure(string procedurename, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteReturnStoredProcedure<T>(string procedurename, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public void ExecuteStoredProcedure(string procedurename, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SelectQuery<T>()
        {
            throw new NotImplementedException();
        }
    }
}