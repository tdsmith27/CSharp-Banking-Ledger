using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace bankingLedger
{
    public class Hash
    {
        public static string Create(string password, string salt)
        {
            Byte[] bytes = KeyDerivation.Pbkdf2(
                            password: password,
                            salt: Encoding.UTF8.GetBytes(salt),
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8);

            return Convert.ToBase64String(bytes);
        }

        public static bool Authenticate(string password, string salt, string hash)
        {
            return Create(password, salt) == hash;
        }        
    }
}
