using BusinessLogicLibrary.SMTPMessageSender;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.SMTPMessageSender
{
    public class EMailSenderTests
    {
        [Fact]
        public void EMailSendTest()
        {
            IList<string> spamTheseEMails = new List<string>();
            spamTheseEMails.Add("vincentmuijtjens@ziggo.nl");
            spamTheseEMails.Add("duncanschoenmakers@hotmail.com");
            EMailSender eMailSender = new EMailSender();
            eMailSender.Send(spamTheseEMails);
        }
    }
}
