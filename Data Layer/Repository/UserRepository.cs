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
        public UserRepository(VidCatToolContext context) : base(context)
        {

        }

        public User GetUserByName(string username)
        {
            return _context.User.Where(user => user.Username == username).FirstOrDefault();
        }

        public User GetByUUID(string uid)
        {
            return _context.User.Where(user => user.UserID == uid).FirstOrDefault();
        }
    }
}
