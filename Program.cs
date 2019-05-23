using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите сообщение: ");
            var s = Console.ReadLine();
            int len = s.Length;
            char[] symbols = new char[1000];
            for (int i = 0; i < len; i++)
            {
                symbols[i] = s[i];
            }

            Console.Write("Введите количество строк: ");
            var a = Console.ReadLine();
            int a1;
            a1 = Int32.Parse(a);
            Console.Write("Введите количество столбцов: ");
            var b = Console.ReadLine();
            int b1;
            b1 = Int32.Parse(b);
            var arr = new char[a1, b1];

            if (a1 * b1 < len)
            {
                Console.WriteLine("Недостаточное количество места (слишком маленький массив)");
                return;
            }

            else if (a1 * b1 == len)
            {
                //ЗАПОЛНЕНИЕ ПРОБЕЛАМИ
                for (int i = 0; i < a1; i++)
                {
                    for (int j = 0; j < b1; j++)
                    {
                        arr[i, j] = ' ';
                    }
                }
                //ЗАПОЛНЕНИЕ МАССИВА
                for (int i = 0; i < a1; i++)
                {
                    for (int j = 0; j < b1; j++)
                    {
                        arr[i, j] = symbols[i * b1 + j];
                    }
                }

                Console.Write("Зашифрованное сообщение: ");
                for (int i = 0; i < b1; i++)
                {
                    for (int j = 0; j < a1; j++)
                    {
                        Console.Write("{0}", arr[j, i]);
                    }
                }

                Console.WriteLine();
                Console.Write("Расшифрованное сообщение: ");
                for (int i = 0; i < a1; i++)
                {
                    for (int j = 0; j < b1; j++)
                    {
                        Console.Write("{0}", arr[i, j]);
                    }
                }
            }


            else if (a1 * b1 > len)
            {

                //ЗАПОЛНЕНИЕ ПРОБЕЛАМИ
                for (int i = 0; i < a1; i++)
                {
                    for (int j = 0; j < b1; j++)
                    {
                        arr[i, j] = ' ';
                    }
                }
                //ЗАПОЛНЕНИЕ МАССИВА
                for (int i = 0; i < a1; i++)
                {
                    for (int j = 0; j < b1; j++)
                    {
                        if (symbols[i * b1 + j] == '\0')
                        {
                            arr[i, j] = ' ';
                        }
                        arr[i, j] = symbols[i * b1 + j];
                    }
                }

                Console.Write("Зашифрованное сообщение: ");
                for (int i = 0; i < b1; i++)
                {
                    for (int j = 0; j < a1; j++)
                    {
                        Console.Write("{0}", arr[j, i]);
                    }
                }

                Console.WriteLine();
                Console.Write("Расшифрованное сообщение: ");
                for (int i = 0; i < a1; i++)
                {
                    for (int j = 0; j < b1; j++)
                    {
                        Console.Write("{0}", arr[i, j]);
                    }
                }
            }
        }
    }
}

