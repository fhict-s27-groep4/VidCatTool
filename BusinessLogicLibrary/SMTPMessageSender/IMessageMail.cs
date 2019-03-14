using System.Net.Mail;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    public interface IMessageMail
    {
        MailMessage MailMessage { get; }
    }
}