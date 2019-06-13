using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Service_Layer.ViewModels
{
    public class SettingsModel
    {
        public AlgoritmSettingsModel AlgoritmSettings { get; set; }
        public MailSettings MailSettings { get; set; }
        public MailContent NewUser { get; set; }
        public MailContent ResetPassword { get; set; }
    }
}
