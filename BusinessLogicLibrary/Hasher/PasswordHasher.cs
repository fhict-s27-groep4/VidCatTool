using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BusinessLogicLibrary.Hasher
{
    public class PasswordHasher
    {

        #region Fields

        private string key = "";
        private string hashtotal;
        private string result;

        #endregion

        #region Methodes

        public void HashWithSalt(string password) // nieuw wachtwoord hashen
        {
            key = GenerateRandomCryptographicKey(64); // maak een random salt aan
            string total = password + key; // voeg salt en password samen
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(total); // zet het om naar bytes
            byte[] hash = SHA256.Create().ComputeHash(textData); // creer de hash
            hashtotal = BitConverter.ToString(hash); // zet bytes om naar string
        }
        public string CheckPassword(string password, string salt) // ingevulde wachtwoord checken
        {
            string total = password + salt; // samenvoegen wachtwoord en salt ( de uit de list komt met dezelfde index als de gebruiker)
            byte[] textData = System.Text.Encoding.UTF8.GetBytes(total); // omzetten naar bytes
            byte[] hash = SHA256.Create().ComputeHash(textData); // hashen van salt en wachtwoord
            return result = BitConverter.ToString(hash); // omzetten van bytes naar string en terugsturen om te checken
        }
        private string GenerateRandomCryptographicKey(int keyLength)
        {
            return Convert.ToBase64String(GenerateRandomCryptographicBytes(keyLength)); //lengte van key
        }
        private byte[] GenerateRandomCryptographicBytes(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider(); // aanmaken van random bytes
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return randomBytes;
        }

        public string Returnkey()
        {
            return key;
        }
        public string GetHashTotal()
        {
            return hashtotal;
        }

        #endregion
    }
}
