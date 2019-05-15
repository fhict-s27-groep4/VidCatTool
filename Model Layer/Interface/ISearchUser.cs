using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer.Interface
{
    public interface ISearchUser : IUser
    {
        string UserID { get; }
        bool IsDisabled { get; }
        int TotalViews { get; }
        int DivergentRate { get; }
    }
}
