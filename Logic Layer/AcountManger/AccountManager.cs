using Logic_Layer;
using Logic_Layer.Hasher;
using Logic_Layer.Interfaces;
using Logic_Layer.PassWordGenerator;
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
    public class AccountManager : ILogin, IRegister
    {
        IPasswordHasher hasher;
        public AccountManager(IPasswordHasher passwordHasher)
        {
            hasher = passwordHasher;
        }

        public bool ValidateUser(string password, ILoginUser queryUser)
        {
            if (queryUser.PassWord == hasher.CheckPassword(password, queryUser.PassWordSalt))
            {
                return true;
            }
            return false;
        }
        
        public IObjectPair<IRegisterUser, string> CreateUser(IEnumerable<IUser> allUsers, string firstname, string lastname, string email, bool isAdmin, string phonenumber = null, string country = null, string city = null, string streetaddress = null, string zipcode = null)
        {
            IPasswordGenerator gen = new PasswordGenerator();
            string generatedPassword = gen.GeneratePassword(true, true, true, true, false, 12);

            IRegisterUser newUser = new User();
            newUser.UserName = GenerateUsername(firstname, lastname, allUsers);
            newUser.FirstName = firstname;
            newUser.LastName = lastname;
            newUser.Email = email;
            newUser.IsAdmin = isAdmin;
            newUser.PassWord = hasher.HashWithSalt(generatedPassword);
            newUser.PassWordSalt = hasher.Key;
            if (phonenumber != null) newUser.PhoneNumber = phonenumber;
            if (country != null) newUser.Country = country;
            if (city != null) newUser.City = city;
            if (streetaddress != null) newUser.StreetAddress = streetaddress;
            if (zipcode != null) newUser.ZipCode = zipcode;
            return new ObjectPair<IRegisterUser, string>() { Object1 = newUser, Object2 = generatedPassword };
        }

        // Need changing to not use database
        private string GenerateUsername(string firstname, string lastname, IEnumerable<IUser> allUsers)
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
    }
}