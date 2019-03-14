using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    public class EMailSender
    {
        public void Send(IMessageMail _messageMail)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            _messageMail.MailMessage.From = new MailAddress("jw.player.vidcattool.pt@gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("jw.player.vidcattool.pt@gmail.com", "Vliegende25Pinguin$");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(_messageMail.MailMessage);
        }
    }
}
