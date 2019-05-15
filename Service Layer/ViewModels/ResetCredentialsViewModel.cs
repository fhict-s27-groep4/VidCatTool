using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class ResetCredentialsViewModel
    {
        [Required, Display(Name = "Username", Prompt = "Username"), DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
    }
}
