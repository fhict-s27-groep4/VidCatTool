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

        public ILoginUser GetByUUID(string uid)
        {
            return context.SelectQuery<User>().Where(id => id.UserID == uid).FirstOrDefault();
        }

        public ILoginUser GetUserByName(string username)
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
            MySqlParameter[] parameters = new MySqlParameter[12];
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
            parameters[11] = new MySqlParameter("@isadmin", user.IsAdmin);
            context.ExecuteStoredProcedure("AddUser", parameters);
        }

        public IEnumerable<IObjectPair<long, string>> GetRatingCountFromAllUsers()
        {
            return context.ExecuteNonObjectStoredProcedure<long, string>("GetRatingCountFromAllUsers", null);
        }
        public IEnumerable<IObjectPair<long, string>> GetDivergentIABRatingsFromAllUser()
        {
            return context.ExecuteNonObjectStoredProcedure<long, string>("GetDivergentRatingsFromAllUser", null);
        }
        public IEnumerable<IObjectPair<long, string>> GetDivergentPADRatingsFromAllUser()
        {
            return context.ExecuteNonObjectStoredProcedure<long, string>("GetPADDivergentPerUser", null);
        }

        public void UpdatePassword(string userid, string password, string passwordsalt)
        {
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@userID", userid);
            parameters[1] = new MySqlParameter("@pword", password);
            parameters[2] = new MySqlParameter("@passwordsalt", passwordsalt);
            context.ExecuteStoredProcedure("UpdatePassword", parameters);
        }
        public void MakeUserAdmin(int userid)
        {
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@userID", userid);
            context.ExecuteStoredProcedure("MakeAdmin", parameters);
            throw new NotImplementedException();
            // check naam van stored procedure "MakeAdmin"
        }
    }
}
