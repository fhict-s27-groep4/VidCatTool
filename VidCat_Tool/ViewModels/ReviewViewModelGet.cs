using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VidCat_Tool.ViewModels
{
    public class ReviewViewModelGet
    {
        public string VideoIdentity { get; set; }
        public string Videolink { get; set; }

        // Object moet veranderd worden naar Category wanneer deze in de business laag is aangemaakt. 
        // public IEnumerable<object> Categories { get; set; }
    }
}
