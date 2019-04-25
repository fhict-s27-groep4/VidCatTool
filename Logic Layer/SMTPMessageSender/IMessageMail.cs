using System.Net.Mail;

namespace Logic_Layer.SMTPMessageSender
{
    public interface IMessageMail
    {
        MailMessage MailMessage { get; }
    }
}