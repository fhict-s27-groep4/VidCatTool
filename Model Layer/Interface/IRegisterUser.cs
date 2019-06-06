using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface IRegisterUser : IUser
    {
        string PassWord { get; set; }
        string PassWordSalt { get; set; }
        bool IsAdmin { get; set; }
    }
}
