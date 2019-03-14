﻿using Data_Layer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Layer.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetUserByID(int id);
    }
}