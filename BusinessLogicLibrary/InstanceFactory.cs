﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public static class InstanceFactory
    {
        public static System.Net.Mail.MailMessage GetNewMailMessage()
        {
            return new System.Net.Mail.MailMessage();
        }

        public static System.Net.Mail.Attachment GetNewMailAttachement(string _filePath)
        {
            return new System.Net.Mail.Attachment(_filePath);
        }
    }
}
