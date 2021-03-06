﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class MailSettings
    {
        [Required, Display(Name = "SMTP Server", Prompt = "SMTP Server")]
        public string Client { get; set; }
        [Required, Display(Name = "Address", Prompt = "Address")]
        public string FromAddress { get; set; }
    }
}
