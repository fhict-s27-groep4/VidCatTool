using System.Net.Mail;

namespace Logic_Layer.SMTPMessageSender
{
    public interface IMessageSettableMail : IMessageMail
    {
        void AddMailAddress(string _address);
        void SetMessageContent(string _content);
        void SetSubject(string _subject);
    }
}