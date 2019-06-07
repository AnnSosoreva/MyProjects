using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static int Main()
        {
            string Key = "";
            do
            {
                Console.WriteLine("Выберете действие:");
                Console.WriteLine("1 - Зашифровать");
                Console.WriteLine("2 - Расшифровать");
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Encryption();
                    Console.WriteLine("");
                    Console.WriteLine("Хотите продолжить? (Да/Нет)");
                    Key = Console.ReadLine();
                    if (Key == "Нет" || Key == "нет" || Key == "НЕТ")
                        return 0;
                }
                else if (choice == "2")
                {
                    Decryption();
                    Console.WriteLine("");
                    Console.WriteLine("Хотите продолжить? (Да/Нет)");
                    Key = Console.ReadLine();
                    if (Key == "Нет" || Key == "нет" || Key == "НЕТ")
                        return 0;
                }
            } while (Key != "Нет" || Key != "нет");
            return 0;
        }

        static void Encryption()
        {
            Console.Write("Введите сообщение: ");
            var s = Console.ReadLine();
            s = s.Replace(" ", "");
            if (s == "")
            {
                Console.WriteLine("Пустое сообщение");
                return;
            }

            int len = s.Length;
            char[] symbols = new char[1000];
            for (int i = 0; i < len; i++)
                symbols[i] = s[i];


            Console.Write("Введите ключ: ");
            var key = Console.ReadLine();
            for (int i = 0; i < key.Length; i++)
            {
                string key_new = key;
                key_new = key.Remove(i); // удаляет символы с указанной позиции
                if (key_new.IndexOf(key[i]) != -1)
                {
                    Console.WriteLine("Неверный ввод ключа(повторяются символы)");
                    return;
                }
            }
            if (key.Length <= 0)
            {
                Console.WriteLine("Ключ не может быть пустым");
                return;
            }

            int stolb = key.Length;
            //ЗАПОЛНЕНИЕ МАССИВА
            string[] arr = new string[stolb];
            int k = 0;
            for (int i = 0; i < len; i++)
            {
                arr[k++] += s[i];
                if (k == stolb)
                {
                    k = 0;
                }
            }



            string[] arr_new = new string[stolb];
            for (int i = 0; i < stolb; i++)
            {
                arr_new[position(key, key[i])] = arr[i];
            }

            string zashifr = "";
            for (int i = 0; i < stolb; i++)
            {
                //Console.WriteLine(arr[i]);
                zashifr += arr_new[i];
            }
            k = 0;
            Console.Write("Зашифрованное сообщение: ");
            for (int i = 0; i < zashifr.Length; i++)
            {
                Console.Write(zashifr[i]);
                //Console.Write(Char.ToUpper(zashifr[i]));
                k++;
                if (k == 5 && i != zashifr.Length - 1)
                {
                    Console.Write(" ");
                    k = 0;
                }
            }
        }



        static int position(string key, char symb)
        {
            int result = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (key[i] < symb)
                {
                    result++;
                }
            }
            return result;
        }

        static void Decryption()
        {
            Console.Write("Введите сообщение: ");
            var s = Console.ReadLine();
            s = s.Replace(" ", "");
            if (s == "")
            {
                Console.WriteLine("Пустое сообщение");
                return;
            }

            int len = s.Length;
            char[] symbols = new char[1000];
            for (int i = 0; i < len; i++)
                symbols[i] = s[i];


            Console.Write("Введите ключ: ");
            var key = Console.ReadLine();
            for (int i = 0; i < key.Length; i++)
            {
                string key_new = key;
                key_new = key.Remove(i); // удаляет символы с указанной позиции
                if (key_new.IndexOf(key[i]) != -1)
                {
                    Console.WriteLine("Неверный ввод ключа(повторяются символы)");
                    return;
                }
            }
            if (key.Length <= 0)
            {
                Console.WriteLine("Ключ не может быть пустым");
                return;
            }
            int stolb = key.Length;
            int a = len / stolb; 
            int b = len % stolb;

            //определяем количество строк
            int[] arr_count = new int[stolb];
            for (int i = 0; i < stolb; i++)
            {
                int cols = position(key, key[i]);
                arr_count[cols] = a;
                if (b > 0)
                {
                    b--;
                    arr_count[cols]++;
                }
            }

            string[] strs = new string[stolb];
            string[] str_New = new string[100];
            int count = 0;
            for (int i = 0; i < stolb; i++)
            {
                int symb_in_str = arr_count[i];
                for (int j = count; j < count + symb_in_str; j++)
                {
                    strs[i] += s[j];
                }
                count += symb_in_str;
            }
            Console.Write("Расшифрованное сообщение: ");
            for (int i = 0; i < stolb; i++)
            {
                int col = position(key, key[i]);
                str_New[i] = strs[col];
                //Console.WriteLine(str_New[i]);
            }
            int posit = len - a * stolb;
            string decrypt = "";
            while (str_New[0] != "")
            {
                posit--;
                posit += stolb;
                posit %= stolb;
                decrypt += str_New[posit][str_New[posit].Length - 1];
                str_New[posit] = str_New[posit].Remove(str_New[posit].Length - 1);
            }
            decrypt = new string(decrypt.ToCharArray().Reverse().ToArray());
            Console.WriteLine(decrypt);
        }
    }
}

