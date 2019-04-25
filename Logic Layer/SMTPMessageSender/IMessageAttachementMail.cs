namespace Logic_Layer.SMTPMessageSender
{
    public interface IMessageAttachementMail : IMessageSettableMail
    {
        void SetMessageAttachment(string _filePath);
    }
}