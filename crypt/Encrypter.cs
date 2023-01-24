using System;
using System.IO;

namespace crypt
{
    internal class Encrypter
    {
        public const string Extention = @".crypted";

        public readonly Func<byte, byte> EncryptionAlgorithm;

        public Encrypter(Func<byte, byte> encryptionAlgorithm)
        {
            EncryptionAlgorithm = encryptionAlgorithm;
        }

        public void Encrypt(string path)
        {
            string newExtention = (Path.GetExtension(path) == Extention) ? (".decrypted") : Extention;

            using (var cryptedFileStream = File.Create(Path.ChangeExtension(path, newExtention)))
            using (var fileStream = File.OpenRead(path))
            {
                int fileByte = fileStream.ReadByte();

                while (fileByte != -1)
                {
                    cryptedFileStream.WriteByte(EncryptionAlgorithm((byte)fileByte));

                    fileByte = fileStream.ReadByte();
                }
            }
        }
    }
}
