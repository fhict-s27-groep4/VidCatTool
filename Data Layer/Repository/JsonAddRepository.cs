using Data_Layer.Interface;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Repository
{
    public class JsonAddRepository : Repository<AddJson>, IJsonAddRepository
    {
        public JsonAddRepository(IDBContext context) : base(context)
        {

        }

        public void AddJsonVideos(IEnumerable<AddJson> ids)
        {
            foreach (AddJson json in ids)
            {
                MySqlParameter[] parameters = new MySqlParameter[1];
                parameters[0] = new MySqlParameter("@VidID", json.VidID);
                context.ExecuteStoredProcedure("AddJson", parameters);
            }
        }
    }
}
