using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    public class EMailSender
    {
        private SmtpClient SmtpServer;
        public EMailSender()
        {
            SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("jw.player.vidcattool.pt@gmail.com", "Vliegende25Pinguin$");
            SmtpServer.EnableSsl = true;
        }
        public void Send(IMessageMail _messageMail)
        {
            _messageMail.MailMessage.From = new MailAddress("jw.player.vidcattool.pt@gmail.com");
            SmtpServer.Send(_messageMail.MailMessage);
        }
    }
}
