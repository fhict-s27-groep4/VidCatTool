using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class UserManagementViewModel
    {
        public UserManagementViewModel()
        {
            RatingCount = 0;
            ProcentDivergent = "More ratings needed";
        }

        public ISearchUser User { get; set; }
        public int RatingCount { get; set; }
        public string ProcentDivergent { get; set; }
    }
}
