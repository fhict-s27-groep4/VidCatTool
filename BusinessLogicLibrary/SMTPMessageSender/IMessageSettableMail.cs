using System.Net.Mail;

namespace BusinessLogicLibrary.SMTPMessageSender
{
    public interface IMessageSettableMail : IMessageMail
    {
        void AddMailAddress(string _address);
        void SetMessageContent(string _content);
        void SetSubject(string _subject);
    }
}