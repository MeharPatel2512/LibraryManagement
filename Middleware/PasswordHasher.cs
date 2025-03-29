using System.Security.Cryptography;
using Microsoft.SqlServer.Server;

namespace Library.Middleware
{
    public class PasswordHasher
    {
        private const int saltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        public static string HashPassword(string password){
            
            byte[] salt = new byte[saltSize];
            using(var rng = RandomNumberGenerator.Create()){
                rng.GetBytes(salt);
            }

            using(var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256)){
                byte[] hash = pbkdf2.GetBytes(HashSize);

                byte[] hashBytes = new byte[saltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, saltSize);
                Array.Copy(hash, 0, hashBytes, saltSize, HashSize);

                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedHash){
            try{
                byte[] hashBytes = Convert.FromBase64String(storedHash.Trim());

                byte[] salt = new byte[saltSize];
                Array.Copy(hashBytes, 0, salt, 0, saltSize);

                using(var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256)){
                    byte[] hash = pbkdf2.GetBytes(HashSize);

                    for(int i = 0; i < HashSize; i++){
                        if(hashBytes[i + saltSize] != hash[i])
                            return false;
                    }
                }
                return true;
            }
            catch(FormatException ex){
                Console.WriteLine("Error: The stored hash is not a valid Base64 string.");
                Console.WriteLine($"Exception Message: {ex.Message}");
                return false;
            }
        }
    }
}