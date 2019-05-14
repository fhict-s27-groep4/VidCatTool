﻿using Model_Layer.Models;
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
    }
}
