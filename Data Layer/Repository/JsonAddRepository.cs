using Data_Layer.Interface;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repository
{
    public class JsonAddRepository : Repository<string>, IJsonAddRepository
    {
        public JsonAddRepository(IDBContext context) : base(context)
        {

        }

        public void AddJsonVideos(IEnumerable<string> ids)
        {
            foreach (string id in ids)
            {
                MySqlParameter[] parameters = new MySqlParameter[1];
                parameters[0] = new MySqlParameter("@VidID", id);
                context.ExecuteStoredProcedure("AddJson", parameters);
            }
        }
    }
}
