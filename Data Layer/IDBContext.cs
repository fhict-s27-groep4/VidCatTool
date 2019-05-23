using Model_Layer.Interface;
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
        IEnumerable<IObjectPair<T1, T2>> ExecuteNonObjectStoredProcedure<T1, T2>(string procedurename, DbParameter[] parameters);
    }
}
