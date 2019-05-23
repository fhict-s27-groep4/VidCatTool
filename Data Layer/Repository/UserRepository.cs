using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using Model_Layer.Interface;
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

        public void AddUser(IRegisterUser user)
        {
            MySqlParameter[] parameters = new MySqlParameter[11];
            parameters[0] = new MySqlParameter("@username", user.UserName);
            parameters[1] = new MySqlParameter("@pass", user.PassWord);
            parameters[2] = new MySqlParameter("@passwordsalt", user.PassWordSalt);
            parameters[3] = new MySqlParameter("@email", user.Email);
            parameters[4] = new MySqlParameter("@firstname", user.FirstName);
            parameters[5] = new MySqlParameter("@lastname", user.LastName);
            parameters[6] = new MySqlParameter("@phonenumber", user.PhoneNumber);
            parameters[7] = new MySqlParameter("@country", user.Country);
            parameters[8] = new MySqlParameter("@city", user.City);
            parameters[9] = new MySqlParameter("@streetaddress", user.StreetAddress);
            parameters[10] = new MySqlParameter("@zipcode", user.ZipCode);
            context.ExecuteStoredProcedure("AddUser", parameters);
        }

        public IEnumerable<IObjectPair<int, string>> GetRatingCountFromAllUsers()
        {
            return context.ExecuteNonObjectStoredProcedure<int, string>("GetRatingCountFromAllUsers", null);
        }
        public IEnumerable<IObjectPair<int, string>> GetDivergentIABRatingsFromAllUser()
        {
            return context.ExecuteNonObjectStoredProcedure<int, string>("GetDivergentRatingsFromAllUser", null);
        }
        public IEnumerable<IObjectPair<int, string>> GetDivergentPADRatingsFromAllUser()
        {
            return context.ExecuteNonObjectStoredProcedure<int, string>("GetPADDivergentPerUser", null);
        }

        public void UpdatePassword(string userid, string password, string passwordsalt)
        {
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@userID", userid);
            parameters[1] = new MySqlParameter("@pword", password);
            parameters[2] = new MySqlParameter("@passwordsalt", passwordsalt);
            context.ExecuteStoredProcedure("UpdatePassword", parameters);
        }
    }
}
