using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data_Layer
{
    public interface IDBContext
    {
        DbConnection DbConnection { get; }
        DbCommand DbCommand { get; }
        DbDataAdapter DataAdapter { get; }

        
    }
}
