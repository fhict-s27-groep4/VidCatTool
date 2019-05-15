using Logic_Layer;
using Logic_Layer.Hasher;
using Logic_Layer.Interfaces;
using Logic_Layer.SMTPMessageSender;
using Model_Layer.Interface;
using Model_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Logic_Layer.Handlers
{
    public class AccountHandler : ILogin, IRegister
    {
        public AccountHandler()
        {
        }

        public bool ValidateUser(string username, string password, ILoginUser queryUser)
        {
            PasswordHasher hasher = new PasswordHasher();
            
            if (queryUser.PassWord == hasher.CheckPassword(password, queryUser.PassWordSalt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // NOG VERANDEREN NAAR INTERFACE DIE NOG GEMAAKT MOET WORDEN 
        public IUser CreateUser(IEnumerable<User> allUsers, string firstname, string lastname, string email, string phonenumber = null, string country = null, string city = null, string streetaddress = null, string zipcode = null)
        {
            PasswordHasher hasher = new PasswordHasher();
            string generatedPassword = PasswordGenerator.GeneratePassword(true, true, true, true, false, 12);

            User newUser = new User();
            newUser.UserName = GenerateUsername(firstname, lastname, allUsers);
            newUser.FirstName = firstname;
            newUser.LastName = lastname;
            newUser.Email = email;
            newUser.PassWord = hasher.HashWithSalt(generatedPassword);
            newUser.PassWordSalt = hasher.Key;
            if (phonenumber != null) newUser.PhoneNumber = phonenumber;
            if (country != null) newUser.Country = country;
            if (city != null) newUser.City = city;
            if (streetaddress != null) newUser.StreetAddress = streetaddress;
            if (zipcode != null) newUser.ZipCode = zipcode;


            EMailSender eMailer = new EMailSender();
            IMessageSettableMail mail = new MessageMail(new System.Net.Mail.MailMessage());
            mail.MakeMail("Account Verification", String.Format("Dear Sir/Madam, \n\n An account has been created with this specific e-mail address. Please login with the following credentials: \n Username: {0} \n Password: {1} \n\n Kind regards, \n The staff of JWPlayer", newUser.UserName, generatedPassword), email);
            eMailer.Send(mail);

            return newUser;
        }

        // Need changing to not use database
        private string GenerateUsername(string firstname, string lastname, IEnumerable<User> allUsers)
        {
            string generatedUsername = string.Empty;
            generatedUsername = firstname.Substring(0, 1).ToLower() + "." + lastname.ToLower();
            if (allUsers.Where(u => u.UserName == generatedUsername).Any())
            {
                int count = allUsers.Where(u => u.UserName.Contains(generatedUsername)).Count() + 1;
                generatedUsername += count;
            }
            return generatedUsername;
        }

        public bool ValidateAccountDisabled(ILoginUser queryUser)
        {
            return queryUser.IsDisabled;
            
        }
    }
}