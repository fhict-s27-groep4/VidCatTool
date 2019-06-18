using Service_Layer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.ServiceLayer.ViewModelTests
{
    public class AlgoritmSettingsTest
    {
        SettingsModel model;
        public AlgoritmSettingsTest()
        {
            model = new SettingsModel();
        }
        [Fact]
        public void CheckGetSetEqualAlgoritmeSettings()
        {
            model.AlgoritmSettings.BiggestPercentIAB = 2.11;
            model.AlgoritmSettings.IabToleranceTier1 = 2.97;
            model.AlgoritmSettings.IabToleranceTier2 = 4.79;
            model.AlgoritmSettings.MaximumRatings = 80;
            model.AlgoritmSettings.PadTolerance = 3.56;
            Assert.Equal(2.11, model.AlgoritmSettings.BiggestPercentIAB);
            Assert.Equal(2.97, model.AlgoritmSettings.IabToleranceTier1);
            Assert.Equal(4.79, model.AlgoritmSettings.IabToleranceTier2);
            Assert.Equal(80, model.AlgoritmSettings.MaximumRatings);
            Assert.Equal(3.56, model.AlgoritmSettings.PadTolerance);
        }
        [Fact]
        public void CheckGetSetNotEqualAlgoritmeSettings()
        {
            model.AlgoritmSettings.BiggestPercentIAB = 2.71;
            model.AlgoritmSettings.IabToleranceTier1 = 2.87;
            model.AlgoritmSettings.IabToleranceTier2 = 4.72;
            model.AlgoritmSettings.MaximumRatings = 81;
            model.AlgoritmSettings.PadTolerance = 3.66;
            Assert.NotEqual(2.11, model.AlgoritmSettings.BiggestPercentIAB);
            Assert.NotEqual(2.97, model.AlgoritmSettings.IabToleranceTier1);
            Assert.NotEqual(4.79, model.AlgoritmSettings.IabToleranceTier2);
            Assert.NotEqual(80, model.AlgoritmSettings.MaximumRatings);
            Assert.NotEqual(3.56, model.AlgoritmSettings.PadTolerance);
        }
        [Fact]
        public void CheckGetSetEqualMailSettings()
        {
            model.MailSettings.Client = "test134";
            model.MailSettings.FromAddress = "testadress@gmail.com";

            Assert.Equal("test134", model.MailSettings.Client);
            Assert.Equal("testadress@gmail.com", model.MailSettings.FromAddress);
        }
        [Fact]
        public void CheckGetSetNotEqualMailSettings()
        {
            model.MailSettings.Client = "test1234";
            model.MailSettings.FromAddress = "testadresss@gmail.com";

            Assert.NotEqual("test134", model.MailSettings.Client);
            Assert.NotEqual("testadress@gmail.com", model.MailSettings.FromAddress);
        }
        [Fact]
        public void CheckGetSetEqualNewUserMailSettings()
        {
            model.NewUser.Content = "UWU,content";
            model.NewUser.Subject = "Well then";

            Assert.Equal("UWU,content", model.NewUser.Content);
            Assert.Equal("Well then", model.NewUser.Subject);
        }
        [Fact]
        public void CheckGetSetNotEqualNewUserMailSettings()
        {
            model.NewUser.Content = "OWO,content";
            model.NewUser.Subject = "Well rip then";

            Assert.NotEqual("UWU,content", model.NewUser.Content);
            Assert.NotEqual("Well then", model.NewUser.Subject);
        }
        [Fact]
        public void CheckGetSetEqualResetPasswordMailSettings()
        {
            model.ResetPassword.Content = "OWO,content";
            model.ResetPassword.Subject = "Well rip then";

            Assert.NotEqual("OWO,content", model.ResetPassword.Content);
            Assert.NotEqual("Well rip then", model.ResetPassword.Subject);
        }
        [Fact]
        public void CheckGetSetNotEqualResetPasswordMailSettings()
        {
            model.ResetPassword.Content = "OWO,content";
            model.ResetPassword.Subject = "Well rip then";

            Assert.NotEqual("UWU,content", model.ResetPassword.Content);
            Assert.NotEqual("Well then", model.ResetPassword.Subject);
        }
    }
}
