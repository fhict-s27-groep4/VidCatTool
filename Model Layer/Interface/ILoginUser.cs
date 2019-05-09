using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface ILoginUser : IUser
    {
        string UserID { get; set; }
        string PassWord { get; set; }
        string PassWordSalt { get; set; }
        bool IsAdmin { get; set; }
        bool IsDisabled { get; set; }
    }
}
