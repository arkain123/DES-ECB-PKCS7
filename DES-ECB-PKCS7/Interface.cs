using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DES_ECB_PKCS7
{
    internal class UserInterface
    {
        public static void StartMenu()
        {
            Console.WriteLine("Консольное приложение для шифрования и расшифрования с использованием алгоритма DES (ECB).");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Шифрование");
            Console.WriteLine("2 - Расшифрование");
            Console.WriteLine("3 - Вывести поддерживаемые параметры");
        }

        public static void DisplaySupportedParameters()
        {
            Console.WriteLine("Поддерживаемые параметры алгоритма DES:");
            Console.WriteLine(" Допустимые размеры ключей: 64 бит (8 байт)");
            Console.WriteLine(" Допустимые размеры блоков: 64 бит");
            Console.WriteLine(" Способы заполнения: PKCS7");
            Console.WriteLine(" Допустимые режимы шифрования: ECB");
        }

        public static void AlghorithmOut(byte[] inputBytes, byte[] key, int BlockSize, bool isEncrypting = false)
        {
            if (isEncrypting)
                Console.WriteLine("Зашифрованный текст (в Base64): " + Convert.ToBase64String(inputBytes));
            else
                Console.WriteLine("Расшифрованный текст: " + Encoding.UTF8.GetString(inputBytes));

            Console.WriteLine("Используемый ключ: " + Convert.ToBase64String(key));
            Console.WriteLine("Режим шифрования: ECB");
            Console.WriteLine("Размер ключа: " + (key.Length * 8) + " бит");
            Console.WriteLine("Размер блока: " + BlockSize + " бит");
            Console.WriteLine("Способ заполнения: PKCS7");
        }

        public static string[] AlghorithmIn(bool isEncrypting = false)
        {
            if (isEncrypting)
            {
                Console.WriteLine("Введите текст для шифрования:");
                string plaintext = Console.ReadLine();
                return [plaintext];
            } else
            {
                Console.WriteLine("Введите зашифрованный текст (в Base64):");
                string encryptedText = Console.ReadLine();
                Console.WriteLine("Введите ключ (в Base64):");
                string keyBase64 = Console.ReadLine();
                return [encryptedText, keyBase64];
            }
        }
    }
}
