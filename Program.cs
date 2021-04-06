using System;
using System.Threading;


namespace equalizer
{
    class Program
    {
        static string ChosingOption()
        {
            Console.WriteLine("Choose option: for encryption type 0, fore decryption type 1");
            var option = Console.ReadLine();
            switch (option)
            {
                case "0":
                    return "0";
                case "1":
                    return "1";
                case "exit":
                    return "exit";
                default:
                    Console.WriteLine($"{option} is not in command list");
                    return "";
            }
        }

        static string Encryption(string[] characters, string code)
        {
            Console.WriteLine("Enter the password you want to encrypt: ");
            string passForEncrypt = Console.ReadLine();
            string result = "";

            foreach (char character in passForEncrypt)
            {
                foreach (string alphabetChar in characters)
                {
                    if (character == char.Parse(alphabetChar))
                    {
                        // вычислячем индекс в массиве encryptedCharacters (наш алфавит по сути) в котором находится очередной символ
                        var alphabetIndex = Array.IndexOf(characters, alphabetChar);
                        var encryptedPassw0rdChar = code.Substring(alphabetIndex * 3, 3);
                        result += encryptedPassw0rdChar;
                    }
                }
            }
            return result;


        }

        static string Decryption(string[] characters, string code)
        {
            Console.WriteLine("Enter value to decrypt: ");
            string stringForDecrypt = Console.ReadLine();
            string result = "";

            if (stringForDecrypt.Length % 3 != 0)
            {
                return null;

            }
            else
            {
                for (int i = 0; i < stringForDecrypt.Length; i += 3)
                {
                    string element = stringForDecrypt.Substring(i, 3);
                    var codeIndex = code.IndexOf(element);
                    if (codeIndex > -1)
                    {
                        var decoded = characters[codeIndex / 3];
                        result += decoded;
                    }
                    else { Console.WriteLine("Incorrect value"); }

                }
            }
            return result;
        }

        static void Main()
        {
            string[] encryptedCharacters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
                "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "/", "!", "@", "#", "$", "%",
                ":", ";", "&", "?", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string encryptionCode = @"PX8@\;R9n1=XjJa|))JR|jeFEi-j@f-8AL#z;#)gFT-PxH[aFuO95uO0z;.B=A&wKFM%j9Uvpok)-+=lNJ!$%>v.#fS\yiior*($#28r*$U*($#UR$34131ewWewW+*/+wq-Uc?N5{K93^#:[wW8gU<cSXv%q&KzGP\@GzM]WB`uF\6}2JpXt(Y4x@s_Bx$pyU%Ka[Hjg];%8sC\Z#S<4EEd";

            while (true)
            {
                var chosedOption = ChosingOption();
                if (chosedOption == "0")
                {
                    string result = Encryption(encryptedCharacters, encryptionCode);
                    Console.WriteLine(result);
                }
                else if (chosedOption == "1")
                {
                    string result = Decryption(encryptedCharacters, encryptionCode);
                    Console.WriteLine(result);
                }
                else if (chosedOption == "exit")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }


        }

    }
}