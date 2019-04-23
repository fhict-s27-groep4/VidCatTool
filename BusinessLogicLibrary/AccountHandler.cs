using BusinessLogicLibrary.Hasher;
using BusinessLogicLibrary.SMTPMessageSender;
using Data_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogicLibrary
{
    public class AccountHandler
    {
        private readonly IUserRepository _userRepo;

        public AccountHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool ValidateUser(string username, string password)
        {
            PasswordHasher hasher = new PasswordHasher();

            var users = _userRepo.GetAll();
            var loginUser = users.Where(u => u.Username == username).FirstOrDefault();

            if (loginUser.Password == hasher.CheckPassword(password, loginUser.PasswordSalt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateUser(string firstname, string lastname, string email, string phonenumber = null, string country = null, string city = null, string streetaddress = null, string zipcode = null)
        {
            PasswordHasher hasher = new PasswordHasher();
            string generatedPassword = PasswordGenerator.GeneratePassword(true, true, true, true, false, 12);

            User newUser = new User();
            newUser.Username = GenerateUsername(firstname, lastname);
            newUser.Firstname = firstname;
            newUser.Lastname = lastname;
            newUser.Email = email;
            newUser.Password = hasher.HashWithSalt(generatedPassword);
            newUser.PasswordSalt = hasher.GetKey();
            if (phonenumber != null) newUser.Phonenumber = phonenumber;
            if (country != null) newUser.Country = country;
            if (city != null) newUser.City = city;
            if (streetaddress != null) newUser.Streetaddress = streetaddress;
            if (zipcode != null) newUser.Zipcode = zipcode;


            EMailSender eMailer = InstanceFactory.GetNewEMailSender();
            IMessageAttachementMail mail = InstanceFactory.GetNewMessageAttachementmail();
            mail.SetSubject("Account Verification");
            mail.SetMessageContent(string.Format("Dear Sir/Madam, \n\n An account has been created with this specific e-mail address. Please login with the following credentials: \n Username: {0} \n Password: {1} \n\n Kind regards, \n The staff of JWPlayer", GenerateUsername(firstname, lastname), generatedPassword));
            mail.AddMailAddress(email);
            eMailer.Send(mail);

            _userRepo.Create(ConvertHandler.ConvertTo<Data_Layer.Model.User>(newUser));
            return true;
        }

        private string GenerateUsername(string firstname, string lastname)
        {
            string generatedUsername = string.Empty;
            generatedUsername = firstname.Substring(0, 1).ToLower() + "." + lastname.ToLower();
            if (_userRepo.GetAll().Where(u => u.Username == generatedUsername).Any())
            {
                int count = _userRepo.GetAll().Where(u => u.Username.Contains(generatedUsername)).Count() + 1;
                generatedUsername += count;
            }
            return generatedUsername;
        }
    }
}

