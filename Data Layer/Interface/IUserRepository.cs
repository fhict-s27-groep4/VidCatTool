using Model_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByName(string username);
        User GetByUUID(string uid);
        void DisableUser(string userid);
        void EnableUser(string userid);
        void AddUser(IRegisterUser user);
        IEnumerable<IObjectPair<long, string>> GetRatingCountFromAllUsers();
        IEnumerable<IObjectPair<long, string>> GetDivergentIABRatingsFromAllUser();
        IEnumerable<IObjectPair<long, string>> GetDivergentPADRatingsFromAllUser();
        void UpdatePassword(string userid, string password, string passwordsalt);

    }
}
