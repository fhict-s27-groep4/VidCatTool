using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data_Layer
{
    public interface IDBContext
    {
        IEnumerable<T> SelectQuery<T>();
        void ExecuteStoredProcedure(string procedurename, DbParameter[] parameters);
        IEnumerable<T> ExecuteReturnStoredProcedure<T>(string procedurename, DbParameter[] parameters);
        IEnumerable<Tuple<int, string>> ExecuteNonObjectStoredProcedure(string procedurename, DbParameter[] parameters);
    }
}
