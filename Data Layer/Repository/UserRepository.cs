using Data_Layer.Interface;
using Microsoft.EntityFrameworkCore;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Layer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public User GetByUUID(string uid)
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
