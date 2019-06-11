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
        public EMailSender()
        {
            smtpServer = new SmtpClient("mailrelay.fhict.local");
        }
        public void Send(IMessageMail _messageMail)
        {
            _messageMail.MailMessage.From = new MailAddress("i413747@hera.fhict.nl");
            smtpServer.Send(_messageMail.MailMessage);
        }
    }
}
