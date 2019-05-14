using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class ReviewViewModelGet
    {
        public IEnumerable<ICategory> Categories { get; set; }
    }
}
