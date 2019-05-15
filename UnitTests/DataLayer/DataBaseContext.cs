using System.Data.Common;
using Data_Layer;

namespace UnitTests.DataLayer
{
    internal class DataBaseContext : IDBContext
    {
        public DbConnection DbConnection => throw new System.NotImplementedException();

        public DbCommand DbCommand => throw new System.NotImplementedException();

        public DbDataAdapter DataAdapter => throw new System.NotImplementedException();
    }
}