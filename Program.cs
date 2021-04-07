using System;


namespace PasswordHasher
{
    class Program
    {
        // Шифрующий метод. Принимает в качестве параметров строку для шифровки, массив алфавита и шифр-строку
        static string Encryption(string charsForEncrypt, string[] characters, string code)
        {
            string result = "";
            // для каждого символа из введенной строки подбираем символ из алфавита и далее =>
            foreach (char character in charsForEncrypt)
            {
                var index = Array.IndexOf(characters, character.ToString());
                if (index <= -1)
                    throw new Exception($"Character {character} doesn't exist in the alphabet");
                var encryptedPassw0rdChar = code.Substring(index * 3, 3);
                result += encryptedPassw0rdChar;

                //foreach (string alphabetChar in characters)
                //{
                   

                //    if (character == char.Parse(alphabetChar))
                //    {
                //        // => вычислячем индекс в массиве encryptedCharacters (наш алфавит по сути) в котором находится очередной символ
                //        var alphabetIndex = Array.IndexOf(characters, alphabetChar);
                //        // получаем зашифрованный символ путем вычисления его позиции в кодовой строке с прибавлением трех последующих символов из кодовой строки и конкатенируем в результат при каждой итеррации
                //        var encryptedPassw0rdChar = code.Substring(alphabetIndex * 3, 3);
                //        result += encryptedPassw0rdChar;
                //    }

                //}
            }
            return result;
        }

        // Дешифрующий метод. Принимает в качестве параметров строку для дешифровки, массив алфавита и шифр-строку
        static string Decryption(string charsForDecrypt, string[] characters, string code)
        {
            string result = "";
            // сначала проверяем длину строки. Если при делениии по модулю остаток отличный от 0, тогда распознание не удастся, значит ошибка 
            if (charsForDecrypt.Length % 3 != 0)
            {
                throw new Exception("Incorrect value");
            }
            // для каждого i+3-его элемента в массиве длиной меньше stringForDecrypt
            for (int i = 0; i < charsForDecrypt.Length; i += 3)
            {
                // выделяем строку из 3 символов
                string element = charsForDecrypt.Substring(i, 3);
                // получаем индекс элемента в массиве
                var codeIndex = code.IndexOf(element);
                // если значение не найдено (индекс меньше=-1)
                if (codeIndex <= -1)
                    throw new Exception($"Incorrect value [{element}]");
                // получаем из алфавита значение сомвола по индексу из зашифрованного кода и конкатенируем в результат
                var decoded = characters[codeIndex / 3];
                result += decoded;
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
                Console.WriteLine("Choose option: for encryption type 0, fore decryption type 1");
                string inputValue = Console.ReadLine().Trim();
                string[] splitValue = inputValue.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (splitValue[0])
                    {
                        case "0":
                            Console.WriteLine("Enter the password you want to encrypt: ");
                            string passForEncrypt = Console.ReadLine();
                            string resultEncrypt = Encryption(passForEncrypt, encryptedCharacters, encryptionCode);
                            Console.WriteLine($"Encrypted value is: {resultEncrypt}");
                            break;
                        case "1":
                            Console.WriteLine("Enter value to decrypt: ");
                            string stringForDecrypt = Console.ReadLine();
                            string resultDecrypt = Decryption(stringForDecrypt, encryptedCharacters, encryptionCode);
                            Console.WriteLine($"Decrypted value is: {resultDecrypt}");
                            break;
                        case "-e":
                            if (splitValue.Length != 2)
                                throw new Exception("Incorrect value. One parameter required for command -e");
                            string resultEncryptWithParam = Encryption(splitValue[1], encryptedCharacters, encryptionCode);
                            Console.WriteLine($"Encrypted value is: {resultEncryptWithParam}");
                            break;
                        case "-d":
                            if (splitValue.Length != 2)
                                throw new Exception("Incorrect value. One parameter required for command -d");
                            string resultDecryptWithParams = Decryption(splitValue[1], encryptedCharacters, encryptionCode);
                            Console.WriteLine($"Decrypted value is: {resultDecryptWithParams}");
                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "exit":
                            return;
                        default:
                            Console.WriteLine($"[{splitValue[0]}] is not in command list");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }


            }
        }

    }
}