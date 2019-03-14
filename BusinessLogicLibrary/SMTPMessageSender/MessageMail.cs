﻿using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    class MessageMail
    {
        private MailMessage mailMessage;
        public MessageMail(MailMessage _mailMessage)
        {
            mailMessage = _mailMessage;
        }

        public MailMessage MailMessage
        {
            get { return mailMessage; }
        }

        public void AddMailAddress(string _address)
        {
            mailMessage.To.Add(_address);
        }

        public void SetSubject(string _subject)
        {
            mailMessage.Subject = _subject;
        }

        public void SetMessageContent(string _content)
        {
            mailMessage.Body = _content;
        }

        public void SetMessageAttachment(string _filePath)
        {
            mailMessage.Attachments.Add(InstanceFactory.GetNewMailAttachement(_filePath));
        }
    }
}
