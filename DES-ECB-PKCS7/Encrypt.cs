using System.Security.Cryptography;
using System.Text;
using DES_ECB_PKCS7;

internal static class Encrypt
{
    public static void EncryptData(string plaintext)
    {
        using (var des = DES.Create())
        {
            // Установка параметров
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            des.GenerateKey();
            byte[] key = des.Key;

            if (DES.IsWeakKey(key))
            {
                Console.WriteLine("Сгенерирован слабый ключ. Повторите попытку.");
                return;
            }

            ICryptoTransform encryptor = des.CreateEncryptor();
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);

            UserInterface.AlghorithmOut(encryptedBytes, key, des.BlockSize, true);
        }
    }
}
