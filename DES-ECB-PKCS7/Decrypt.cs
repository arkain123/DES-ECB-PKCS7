using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using DES_ECB_PKCS7;

internal static class Decrypt
{
    public static void DecryptData(string encryptedText, string keyBase64)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
        byte[] key = Convert.FromBase64String(keyBase64);

        using (var des = DES.Create())
        {
            // Установка параметров
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;
            des.Key = key;

            ICryptoTransform decryptor = des.CreateDecryptor();
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

            UserInterface.AlghorithmOut(decryptedBytes, key, des.BlockSize);
        }
    }
}