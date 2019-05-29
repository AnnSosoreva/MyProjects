using System;


namespace Lab3
{
    class Program
    {
        static int Main()
        {
            string key;
            do
            {
                Console.WriteLine("Из какой системы счисления переводить?");
                var isystema = Console.ReadLine();
                int isystema_;
                isystema_ = Int32.Parse(isystema);

                Console.WriteLine("В какую систему счисления переводить?");
                var vsystema = Console.ReadLine();
                int vsystema_;
                vsystema_ = Int32.Parse(vsystema);

                Console.Write("Введите число: ");
                var numb = Console.ReadLine();
                string result = " ";
                int numb_ = 0;
                int flag = 0;
                foreach (var ch in numb)
                {
                    if ((int)ch > 57) // 57- код 9
                    {
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    numb_ = Convert.ToInt32(numb);
                }

                //ПРОВЕРКИ НА ВВОД ЧИСЛА
                if (flag > 0)
                {
                    foreach (var ch in numb)
                    {
                        int a = isystema_ - 11;
                        int b = a + 65;
                        if (ch == ' ' || (int)ch > b)
                        {
                            Console.WriteLine("Неверный ввод числа");
                            return 0;
                        }
                    }
                }
                if (flag == 0)
                {
                    foreach (var ch in numb)
                    {
                        if (ch == '-' || (ch - 48) >= isystema_ || ch == ' ')
                        {
                            Console.WriteLine("Неверный ввод числа");
                            return 0;
                        }
                    }
                }

                int temp = 0;
                int res = 0;

                //ФУНКЦИЯ ПЕРЕВОДА ИЗ 10 СИСТЕМЫ В ЛЮБУЮ
                string ConvertIz10(int chislo, int osnov)
                {
                    if (chislo > 0)
                    {
                        while (chislo >= (osnov - 1))
                        {
                            temp = chislo % osnov;
                            chislo = (chislo - temp) / osnov;
                            if (temp > 9)
                            {
                                temp = temp + 55; // ПОЛУЧИТСЯ КОД БУКВЫ
                                result = Convert.ToChar(temp) + result;
                            }
                            else if (temp <= 9)
                            {
                                result = temp + result;
                            }
                        }
                        if (chislo > 9)
                        {
                            chislo = chislo + 55;
                            result = Convert.ToChar(chislo) + result;
                            return result;
                        }
                    }
                    result = chislo + result;
                    return result;
                }

                //ФУНКЦИЯ ИЗ ЛЮБОЙ В 10
                int ConvertV10(string chislo, int osnov)
                {
                    int j = 0;
                    for (int i = (chislo.Length - 1); i >= 0; i--)
                    {
                        if (chislo[i] >= 'A' && chislo[i] <= 'Z')
                        {
                            res = (int)(res + Convert.ToInt32((chislo[i] - 55) * Math.Pow(osnov, j)));
                        }
                        else
                        {
                            res = (int)(res + (chislo[i] - 48) * Math.Pow(osnov, j));
                        }
                        j++;
                    }
                    return res;
                }

                if (vsystema_ == 10)
                {
                    ConvertV10(numb, isystema_);
                    if (flag == 0)
                        Console.WriteLine("Число {0} в {1}-чной системе счисления равно {2}", numb_, vsystema_, res);
                    else if (flag > 0)
                        Console.WriteLine("Число {0} в {1}-чной системе счисления равно {2}", numb, vsystema_, res);
                }

                if (isystema_ == 10)
                {
                    ConvertIz10(numb_, vsystema_);
                    if (flag == 0)
                        Console.WriteLine("Число {0} в {1}-чной системе счисления равно {2}", numb_, vsystema_, result);
                    else if (flag > 0)
                        Console.WriteLine("Число {0} в {1}-чной системе счисления равно {2}", numb, vsystema_, result);
                }

                if (vsystema_ != 10 && isystema_ != 10)
                {
                    ConvertV10(numb, isystema_);
                    ConvertIz10(res, vsystema_);
                    if (flag == 0)
                        Console.WriteLine("Число {0} в {1}-чной системе счисления равно {2}", numb_, vsystema_, result);
                    else if (flag > 0)
                        Console.WriteLine("Число {0} в {1}-чной системе счисления равно {2}", numb, vsystema_, result);
                }
                Console.WriteLine("Хотите завершить работу? (Да / Нет)");
                key = Console.ReadLine();
            } while (key != "Да");
            return 0;
        }
    }
}
