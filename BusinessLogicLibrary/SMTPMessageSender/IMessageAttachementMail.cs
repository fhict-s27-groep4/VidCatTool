namespace BusinessLogicLibrary.SMTPMessageSender
{
    public interface IMessageAttachementMail : IMessageSettableMail
    {
        void SetMessageAttachment(string _filePath);
    }
}