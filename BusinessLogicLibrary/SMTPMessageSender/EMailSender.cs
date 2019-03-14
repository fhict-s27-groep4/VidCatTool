using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    public class EMailSender
    {
        public void Send(IList<string> _mailAddresses)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("jw.player.vidcattool.pt@gmail.com");
            mail.To.Add("niek.sleddens@gmail.com");
            mail.Subject = "Spam";
            mail.Body = "This is for testing SMTP mail";
            Attachment attachment = new Attachment(@"..\..\..\..\BusinessLogicLibrary\JsonReader\VideoFeed.json");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("jw.player.vidcattool.pt@gmail.com", "Vliegende25Pinguin$");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
