using Data_Layer.Interface;
using Data_Layer.Model;
using Microsoft.EntityFrameworkCore;
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
    }
}
