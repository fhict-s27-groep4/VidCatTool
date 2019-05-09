using Model_Layer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model_Layer.Models
{
    public class Video : IVideo
    {
        public string UrlIdentity { get; set; }
        public bool Finished { get; set; }
    }
}
