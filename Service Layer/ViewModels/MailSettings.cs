using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class MailSettings
    {
        [Required, Display(Name = "Client", Prompt = "Client")]
        public string Client { get; set; }
        [Required, Display(Name = "FromAddress", Prompt = "FromAddress")]
        public string FromAddress { get; set; }
    }
}
