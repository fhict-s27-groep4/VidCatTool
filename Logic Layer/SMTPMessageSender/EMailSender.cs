using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Logic_Layer.SMTPMessageSender
{
    public class EMailSender
    {
        private SmtpClient smtpServer;
        public EMailSender(SmtpClient client)
        {
            smtpServer = client;
        }
        public void Send(IMessageMail _messageMail, MailAddress _fromAddress, NetworkCredential credentials, bool ssl, int port)
        {
            _messageMail.MailMessage.From = _fromAddress;
            smtpServer.Credentials = credentials;
            smtpServer.EnableSsl = ssl;
            smtpServer.Port = port;
            smtpServer.Send(_messageMail.MailMessage);
        }
    }
}
