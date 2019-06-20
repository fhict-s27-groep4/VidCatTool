using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Service_Layer.ViewModels
{
    public class SettingsModel
    {
        public AlgoritmSettingsModel AlgoritmSettings { get; set; }
        public MailSettings MailSettings { get; set; }
        public MailContent NewUser { get; set; }
        public MailContent ResetPassword { get; set; }
        public NetworkCredential NetworkCredentials { get; set; }
        public bool EnableSSL { get; set; }
        public int Port { get; set; }

    }
}
