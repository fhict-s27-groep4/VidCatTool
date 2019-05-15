using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using Model_Layer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDBContext context) : base(context)
        {

        }

        public User GetByUUID(string uid)
        {
            return context.SelectQuery<User>().Where(id => id.UserID == uid).FirstOrDefault();
        }

        public User GetUserByName(string username)
        {
            return context.SelectQuery<User>().Where(user => user.UserName == username).FirstOrDefault();
        }

        public void DisableUser(string userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@userID", userid);
            context.ExecuteStoredProcedure("DisableUser", parameters);
        }

        public void EnableUser(string userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@userID", userid);
            context.ExecuteStoredProcedure("EnableUser", parameters);
        }
    }
}
