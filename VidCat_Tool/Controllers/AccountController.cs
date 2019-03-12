using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidCat_Tool.ViewModels;

namespace VidCat_Tool.Controllers
{
    public class AccountController : Controller
    {

        #region Fields

        public string key = "";
        public string hashtotal;
        private string result;

        #endregion

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            return View();
        }

        public IActionResult ResetCredentials()
        {
            return View();
        }

        /*________________________________________*/

        public IActionResult ResetCredentials(string EMail)
        {
            //Verify that address exists
            var account = "";

            //Generate link
            string error = "";
            if(account != null)
            {
                error = "Successful!";
                string resetCode = Guid.NewGuid().ToString();
                //Send password code to database.. (including boolean: isCreatedByConsole)
                if(resetCode != null) //If password is sent to database
                {
                    //Set content of email
                    string subject = "Reset password";
                    string body = "New password is: " + resetCode;

                    //SendEMail(account.EMail, subject, body); //Send email
                }

            }
            else
            {
                error = "Account not found.";
            }
            //Send error....

            return View(); //Return
        }

        /*____________________________________________________________________-*/

        [NonAction]
        public void SendEMail(string address, string title, string text)
        {
            //Variables
            var fromMail = new MailAddress("jwplayertool@gmail.com", "VidCat Tool");
            var fromMail_Password = "******"; //Replace this with the actual password
            var toMail = new MailAddress(address);

            string subject = title;
            string content = text;

            //SMTP Send
            var smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com", //The SMTP Link to send mails from
                Port = 587, //Port to send from
                EnableSsl = false, //using SSL
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromMail.Address, fromMail_Password)
            };

            //Defining Message
            using (var message = new MailMessage(fromMail, toMail)
            {
                Subject = subject,
                Body = content,
                IsBodyHtml = true
            })
            smtp.Send(message); //Finally, send it
        }

        /*________________________________________________________________*/

        #region Hasher met salt

        public void HashWithSalt(string password) // nieuw wachtwoord hashen
        {
            key = GenerateRandomCryptographicKey(64); // maak een random salt aan
            string total = password + key; // voeg salt en password samen
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(total); // zet het om naar bytes
            byte[] hash = SHA256.Create().ComputeHash(textData); // creer de hash
            hashtotal = BitConverter.ToString(hash); // zet bytes om naar string
        }
        public string checkpassword(string password, string salt) // ingevulde wachtwoord checken
        {
            string total = password + salt; // samenvoegen wachtwoord en salt ( de uit de list komt met dezelfde index als de gebruiker)
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(total); // omzetten naar bytes
            byte[] hash = SHA256.Create().ComputeHash(textData); // hashen van salt en wachtwoord
            return result = BitConverter.ToString(hash); // omzetten van bytes naar string en terugsturen om te checken
        }
        public string GenerateRandomCryptographicKey(int keyLength)
        {
            return Convert.ToBase64String(GenerateRandomCryptographicBytes(keyLength)); //lengte van key
        }
        public byte[] GenerateRandomCryptographicBytes(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider(); // aanmaken van random bytes
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return randomBytes;
        }

        #endregion
    }
}