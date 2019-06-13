﻿using Logic_Layer.SMTPMessageSender;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.LogicLayer.SMTPMessageSender
{
    public class EMailSenderTests
    {
        //[Fact]
        //public void EMailFullSendTest()
        //{
        //    string subject = "Retarded Unit Test";
        //    string content = "Dear Sir/Madam, \n\nI believe this report meet you in a very good present state of mind and health. \n\nI am Mark George a United Kingdom Attorney.A deceased client of mine, that shares same last name with you, died as a result of a heart - related condition on March 12th 2007.His heart condition leading to his death was due to death of all members of his Family in tsunami disaster in Sumatra, **blank**\n\nI have been unsuccessful in locating the relatives for over last 9 years now so i decided to trace his last name to locate any member of his family.Since his death I have made several inquiries to embassy to locate any of my clients extended relatives this has also proved unsuccessful.Hence I contacted you to seek your consent in presenting you as the next of kin to the deceased since you have the same last same so that the proceeds of this deposit valued sum can be handed over to you.\n\nYour earliest response to this mail will be highly appreciated.Do get back to me as i will not contact anybody till i read from you and if you are not interested do let me know by replying back to me.You can Reach me on(**Blank**) for more information as my late client left Behind a deposit of £ 11, 800, 000, 00 GBP(Eleven million Eight hundred thousand Pounds)\n\nBest Regards,\n\nMark George Solicitors\n\nAddress: 483 Green Lanes,\n\nLondon N13 4BS, United Kingdom\n\nUnit testen zijn echt retarded, weg met die handel, oohwja dit wordt gemarkeerd als spam.";
        //    string Attachment = @"..\..\..\..\Logic Layer\JsonReader\VideoFeed.json";
        //    string MailAddress = "uncanschoenmakers@hotmail.com";
        //    EMailSender eMailer = new EMailSender();
        //    IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
        //    mail.MakeMail(subject, content, MailAddress, Attachment);
        //    eMailer.Send(mail);
        //}
        //[Fact]
        //public void EMailSendTest()
        //{
        //    string subject = "Retarded Unit Test";
        //    string content = "Dear Sir/Madam, \n\nI believe this report meet you in a very good present state of mind and health. \n\nI am Mark George a United Kingdom Attorney.A deceased client of mine, that shares same last name with you, died as a result of a heart - related condition on March 12th 2007.His heart condition leading to his death was due to death of all members of his Family in tsunami disaster in Sumatra, **blank**\n\nI have been unsuccessful in locating the relatives for over last 9 years now so i decided to trace his last name to locate any member of his family.Since his death I have made several inquiries to embassy to locate any of my clients extended relatives this has also proved unsuccessful.Hence I contacted you to seek your consent in presenting you as the next of kin to the deceased since you have the same last same so that the proceeds of this deposit valued sum can be handed over to you.\n\nYour earliest response to this mail will be highly appreciated.Do get back to me as i will not contact anybody till i read from you and if you are not interested do let me know by replying back to me.You can Reach me on(**Blank**) for more information as my late client left Behind a deposit of £ 11, 800, 000, 00 GBP(Eleven million Eight hundred thousand Pounds)\n\nBest Regards,\n\nMark George Solicitors\n\nAddress: 483 Green Lanes,\n\nLondon N13 4BS, United Kingdom\n\nUnit testen zijn echt retarded, weg met die handel, oohwja dit wordt gemarkeerd als spam.";
        //    string MailAddress2 = "iek.sleddens@gmail.com";
        //    string MailAddress1 = "incentmuijtjens@ziggo.nl";
        //    List<string> emails = new List<string>();
        //    emails.Add(MailAddress1);
        //    emails.Add(MailAddress2);
        //    IEnumerable<string> emailss = emails;
        //    EMailSender eMailer = new EMailSender();
        //    IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
        //    mail.MakeMail(subject, content, emailss);
        //    eMailer.Send(mail);
        //}
        //[Fact]
        //public void EmailSendMoreAttachmentTest()
        //{
        //    //string _subject, string _content, IEnumerable< string > _addresses, IEnumerable<string> _attachmentPath
        //    string subject = "Retarded Unit Test";
        //    string content = "Dear Sir/Madam, \n\nI believe this report meet you in a very good present state of mind and health. \n\nI am Mark George a United Kingdom Attorney.A deceased client of mine, that shares same last name with you, died as a result of a heart - related condition on March 12th 2007.His heart condition leading to his death was due to death of all members of his Family in tsunami disaster in Sumatra, **blank**\n\nI have been unsuccessful in locating the relatives for over last 9 years now so i decided to trace his last name to locate any member of his family.Since his death I have made several inquiries to embassy to locate any of my clients extended relatives this has also proved unsuccessful.Hence I contacted you to seek your consent in presenting you as the next of kin to the deceased since you have the same last same so that the proceeds of this deposit valued sum can be handed over to you.\n\nYour earliest response to this mail will be highly appreciated.Do get back to me as i will not contact anybody till i read from you and if you are not interested do let me know by replying back to me.You can Reach me on(**Blank**) for more information as my late client left Behind a deposit of £ 11, 800, 000, 00 GBP(Eleven million Eight hundred thousand Pounds)\n\nBest Regards,\n\nMark George Solicitors\n\nAddress: 483 Green Lanes,\n\nLondon N13 4BS, United Kingdom\n\nUnit testen zijn echt retarded, weg met die handel, oohwja dit wordt gemarkeerd als spam.";
        //    string MailAddress2 = "iek.sleddens@gmail.com";
        //    string MailAddress1 = "incentmuijtjens@ziggo.nl";
        //    string Attachment1 = @"..\..\..\..\Logic Layer\JsonReader\VideoFeed.json";
        //    string Attachment2 = @"..\..\..\..\Logic Layer\JsonReader\VideoFeed.json";
        //    List<string> emails = new List<string>();
        //    List<string> attachments = new List<string>();
        //    attachments.Add(Attachment1);
        //    attachments.Add(Attachment2);
        //    emails.Add(MailAddress1);
        //    emails.Add(MailAddress2);
        //    IEnumerable<string> emailss = emails;
        //    IEnumerable<string> attachmentss = attachments;
        //    EMailSender eMailer = new EMailSender();
        //    IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
        //    mail.MakeMail(subject, content, emailss, attachmentss);
        //    eMailer.Send(mail);
        //}
    }
}
