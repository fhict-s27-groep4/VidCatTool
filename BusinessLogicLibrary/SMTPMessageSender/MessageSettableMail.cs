using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    public class MessageMail : IMessageSettableMail
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

        public void MakeMail(string _subject, string _content, string _address)
        {
            mailMessage.Subject = _subject;
            mailMessage.Body = _content;
            mailMessage.To.Add(_address);
        }

        public void MakeMail(string _subject, string _content, IEnumerable<string> _addresses)
        {
            string addresses = String.Empty;
            foreach (string s in _addresses)
            {
                if (addresses != String.Empty)
                {
                    addresses += ",";
                }
                addresses += s;
            }
            MakeMail(_subject, _content, addresses);
        }

        public void MakeMail(string _subject, string _content, string _address, string _attachmentPath)
        {
            MailMessage.Attachments.Add(InstanceFactory.GetNewMailAttachement(_attachmentPath));
            MakeMail(_subject, _content, _address);
        }

        public void MakeMail(string _subject, string _content, IEnumerable<string> _addresses, IEnumerable<string> _attachmentPaths)
        {
            foreach (string s in _attachmentPaths)
            {
                mailMessage.Attachments.Add(InstanceFactory.GetNewMailAttachement(s));
            }
            MakeMail(_subject, _content, _addresses);
        }
    }
}