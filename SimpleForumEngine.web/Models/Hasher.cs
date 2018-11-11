using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SimpleForumEngine.web.Models
{
   public static class Hasher
    {
        private static int SaltSize = 32;
        public static byte[] GenarateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public static byte[] SHA256(byte[] data, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                return hmac.ComputeHash(data);
            }
        }
        public static string getPasswordString(byte[] password, byte[] salt)
        {
            return ToString(password) + "salt:" + ToString(salt);
        }
        public static IEnumerable<byte> ToByte(string str)
        {
            foreach(char s in str)
            {
                yield return Convert.ToByte(s);
            }
        }
        public static string ToString(byte[] message)
        {
            StringBuilder builder = new StringBuilder();
            foreach(var b in message)
            {
                builder.Append(Convert.ToChar(b));
            }
            return builder.ToString();
        }
        public static bool CompareStrings(string comparePassword, string paswordAndSalt)
        {
            int index = paswordAndSalt.IndexOf("salt:");
            string passwordStr = paswordAndSalt.Substring(0, index);
            string saltStr = paswordAndSalt.Substring(index + "salt:".Length);

            byte[] salt = ToByte(saltStr).ToArray();
            byte[] pass = ToByte(comparePassword).ToArray();
            byte[] password = SHA256(pass, salt);
            string resPasswordStr = ToString(password);
            if (passwordStr.Equals(resPasswordStr))
                return true;
            else
                return false;
        }
    }
}