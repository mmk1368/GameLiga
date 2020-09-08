using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace GameLiga.Core.Validations
{
    public static class Validations
    {
        public static bool IsPhoneNumber(this string number)
        {
            if (Regex.Match(number, @"^(\+[0-9]{12})$").Success)
            {
                return true;
            }
            else if (Regex.Match(number, @"^09[0-9]{9}").Success)
            {
                return true;
            }
            return false;

        }

        public static bool IsValidEmail(this string email)
        {
            try
            {
                string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
        + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
        + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidatePassword(this string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            bool isValidated =
                 //hasNumber.IsMatch(password)
                 // && hasUpperChar.IsMatch(password)
                 hasMinimum8Chars.IsMatch(password);
            return isValidated;
        }

        public static bool IsValidateUsername(this string username)
        {
            string pattern = @"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(username);
        }
        public static string HashPassword(this string password, ref byte[] hasSalt)
        {
            if (hasSalt == null)
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }

                hasSalt = salt;
            }
            // generate a 128-bit salt using a secure PRNG

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: hasSalt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }
    }
}
