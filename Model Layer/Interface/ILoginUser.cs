using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface ILoginUser : IUser
    {
        string UserID { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
        bool IsAdmin { get; set; }
        bool IsDisabled { get; set; }
    }
}
