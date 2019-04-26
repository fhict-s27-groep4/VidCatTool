using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class ResetCredentialsViewModel
    {
        [Required, Display(Name = "EMail", Prompt = "EMail"), DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [Required, Display(Name = "ResetType", Prompt = "ResetType")]
        public string ResetType { get; set; }
    }
}
