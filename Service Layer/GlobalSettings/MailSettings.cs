using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Service_Layer.GlobalSettings
{
    public static class MailSettings
    {
        private static string newUserContent;
        private static string newUserSubject;
        private static string resetContent;
        private static string resetSubject;
        private static SmtpClient smtpClient;
        private static MailAddress noReplyAddress;

        public static SmtpClient Client { get { return smtpClient ?? new SmtpClient() { Host = "No host set" }; } }
        public static MailAddress NoReplyAdress { get { return noReplyAddress ?? new MailAddress("youremail@yourhost.nl"); } }
        public static string ResetSubject { get { return resetSubject ?? ""; } }
        public static string ResetContent { get { return resetContent ?? ""; } }
        public static string NewUserSubject { get { return newUserSubject ?? ""; } }
        public static string NewUserContent { get { return newUserContent ?? ""; } }

        public static void SetUserContent(string content)
        {
            newUserContent = content;
        }
        public static void SetUserSubject(string subject)
        {
            newUserSubject = subject;
        }
        public static void SetResetContent(string content)
        {
            resetContent = content;
        }
        public static void SetResetSubject(string subject)
        {
            resetSubject = subject;
        }

        public static void SetSMTPClient(string host)
        {
            smtpClient = new SmtpClient()
            {
                Host = host,
            };
        }

        public static void SetMailAddress(string email)
        {
            noReplyAddress = new MailAddress(email);
        }
    }
}
