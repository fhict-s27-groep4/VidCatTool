using System.Net.Mail;

namespace Logic_Layer.SMTPMessageSender
{
    class MessageSettableMail : IMessageSettableMail
    {
        private MailMessage mailMessage;
        public MessageSettableMail(MailMessage _mailMessage)
        {
            mailMessage = _mailMessage;
        }

        public MailMessage MailMessage
        {
            get { return mailMessage; }
        }

        public void AddMailAddress(string _address)
        {
            mailMessage.To.Add(_address);
        }

        public void SetSubject(string _subject)
        {
            mailMessage.Subject = _subject;
        }

        public void SetMessageContent(string _content)
        {
            mailMessage.Body = _content;
        }
    }
}