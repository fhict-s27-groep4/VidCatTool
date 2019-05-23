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
            ProcentIABDivergent = 0;
            ProcentPADDivergent = 0;
        }

        public ISearchUser User { get; set; }
        public int RatingCount { get; set; }
        public int ProcentIABDivergent { get; set; }
        public int ProcentPADDivergent { get; set; }
    }
}
