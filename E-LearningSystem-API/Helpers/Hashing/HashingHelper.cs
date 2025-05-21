using System.Security.Cryptography;
using System.Text;

namespace E_LearningSystem_API.Helpers.Hashing
{
    public static class HashingHelper
    {
        public static string HashValue(string input)
        {
            var inputByte=Encoding.UTF8.GetBytes(input);

            var hasher = SHA3_384.Create();

            var hashedByte = hasher.ComputeHash(inputByte);

            return BitConverter.ToString(hashedByte).ToString().Replace("-", "").ToLower();

        }
    }
}
