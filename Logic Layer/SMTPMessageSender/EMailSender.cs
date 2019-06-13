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
        public EMailSender(string client)
        {
            smtpServer = new SmtpClient(client);
        }
        public void Send(IMessageMail _messageMail, MailAddress _fromAddress)
        {
            _messageMail.MailMessage.From = _fromAddress;
            smtpServer.Send(_messageMail.MailMessage);
        }
    }
}
