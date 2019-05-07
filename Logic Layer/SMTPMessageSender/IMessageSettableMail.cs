using System.Collections.Generic;

namespace Logic_Layer.SMTPMessageSender
{
    public interface IMessageSettableMail : IMessageMail
    {
        void MakeMail(string _subject, string _content, string _address);
        void MakeMail(string _subject, string _content, IEnumerable<string> _addresses);
        void MakeMail(string _subject, string _content, string _address, string _attachmentPath);
        void MakeMail(string _subject, string _content, IEnumerable<string> _addresses, IEnumerable<string> _attachmentPaths);
    }
}