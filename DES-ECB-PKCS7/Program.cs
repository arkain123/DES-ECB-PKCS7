using DES_ECB_PKCS7;

namespace DESECBPKCS7
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.StartMenu();
            int choice = int.Parse(Console.ReadLine());
            string[] InputArr;
            switch (choice)
            {
                case 1:
                    InputArr = UserInterface.AlghorithmIn(true);
                    Encrypt.EncryptData(InputArr[0]);
                    break;
                case 2:
                    InputArr = UserInterface.AlghorithmIn(false);
                    Decrypt.DecryptData(InputArr[0], InputArr[1]);
                    break;
                case 3:
                    UserInterface.DisplaySupportedParameters();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}
