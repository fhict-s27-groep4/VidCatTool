using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class UserManagementViewModel
    {
        public IReadOnlyCollection<IUser> AllUsers { get; set; }
    }
}
