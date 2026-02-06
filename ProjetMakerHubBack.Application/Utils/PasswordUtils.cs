using System.Security.Cryptography;
using System.Text;

namespace ProjetMakerHubBack.Application.Utils
{
    public static class PasswordUtils
    {
        public static string Hash(string password)
        {
            Guid salt = Guid.NewGuid();
            return Hash(password, salt);
        }

        public static string Hash(string password, Guid salt)
        {
            string hash = Convert.ToBase64String(SHA512.HashData(Encoding.UTF8.GetBytes(password + salt)));

            return salt + hash;
        }

        public static bool VerifyPassword(string password, string encodedPassword)
        {
            Guid salt = new Guid(encodedPassword[..36]);

            return Hash(password, salt) == encodedPassword;
        }
    }
}
