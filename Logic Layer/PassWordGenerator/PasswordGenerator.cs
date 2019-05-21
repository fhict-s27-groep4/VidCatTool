using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_Layer.PassWordGenerator
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword(bool includelower, bool includeupper, bool includenumeric, bool includespecial, bool includespaces, int length)
        {
            const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMERIC_CHARACTERS = "0123456789";
            const string SPECIAL_CHARACTERS = @"!#$%&*@\";
            const string SPACE_CHARACTER = " ";
            const int PASSWORD_LENGTH_MIN = 8;
            const int PASSWORD_LENGTH_MAX = 50;

            if (length < PASSWORD_LENGTH_MIN || length > PASSWORD_LENGTH_MAX)
            {
                throw new ArgumentException("The length of the password must be between 8 - 50 characters");
            }

            string passwordset = string.Empty;

            if (includelower) passwordset += LOWERCASE_CHARACTERS;
            if (includeupper) passwordset += UPPERCASE_CHARACTERS;
            if (includenumeric) passwordset += NUMERIC_CHARACTERS;
            if (includespecial) passwordset += SPECIAL_CHARACTERS;
            if (includespaces) passwordset += SPACE_CHARACTER;

            char[] password = new char[length];
            int passwordSetLength = passwordset.Length;

            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                password[i] = passwordset[random.Next(passwordset.Length - 1)];
            }

            return string.Join(null, password);
        }
    }
}