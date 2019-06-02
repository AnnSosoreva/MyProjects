using System;
using System.Diagnostics;

namespace Lab5
{
    class Program
    {
        static int Main()
        {
            Console.Write("Введите массив: ");
            var mas = Console.ReadLine();
            foreach (var ch in mas)
            {
                if (ch == ',' || ch == '.')
                {
                    Console.WriteLine("Неверный ввод чисел массива");
                    return 0;
                }
            }
            string[] arrS = mas.Split(' ');
            
            //СЧИТАЕМ КОЛИЧЕСТВО ЧИСЕЛ
            int a=0;
            foreach (var ch in arrS)
            {
                Console.WriteLine("{0}", ch);
                a++;
            }
            Console.WriteLine("{0}", a);

            int[] arrNew = new int[a];
            for(int i = 0; i <= (a-1); i++)
                arrNew[i] = Int32.Parse(arrS[i]);

            
            string key;
            do
            {
                Console.WriteLine("Выберите действие: 1) Быстрая сортировка; 2) Сортировка пузырьком; 3) Линейный поиск; 4) Бинарный поиск");
                string choice = Console.ReadLine();


                if (choice == "1")
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    quickSort(arrNew, 0, (arrNew.Length - 1));
                    Console.Write("Отсортированный массив:");
                    foreach (var ch in arrNew)
                        Console.Write("{0} ", ch);
                    watch.Stop();
                    var tr = Math.Log(a, 2);
                    Console.WriteLine("");
                    Console.WriteLine("Время выполнения сортировки: {0}", watch.Elapsed.ToString());
                    Console.WriteLine("Трудоемкость алгоритма равна: {0}", a*tr);
                }

                if (choice == "2")
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    BubbleSort(arrNew);
                    watch.Stop();
                    //watch.Reset();
                    Console.WriteLine("");
                    Console.WriteLine("Время выполнения сортировки: {0}", watch.Elapsed.ToString());
                    Console.WriteLine("Трудоемкость алгоритма равна: {0}", a * a); // т.к. нужно пройти двойной цикл
                }

                if (choice == "3") //ЛИНЕЙНЫЙ ПОИСК
                {
                    Console.Write("Введите число, которое искать: ");
                    var s = Console.ReadLine();
                    foreach (var ch in s)
                    {
                        if (ch == ',' || ch == '.')
                        {
                            Console.WriteLine("Неверный ввод числа");
                            return 0;
                        }
                    }
                    int n = Int32.Parse(s);
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    LineSearch(arrNew, n);
                    if (LineSearch(arrNew, n) != -1)
                    {
                        Console.WriteLine("Число {0} находится на {1} позиции", n, LineSearch(arrNew, n) + 1);
                    }
                    else if (LineSearch(arrNew, n) == -1)
                    {
                        Console.WriteLine("Элемент не найден");
                    }
                    watch.Stop();
                    //watch.Reset();
                    Console.WriteLine("");
                    Console.WriteLine("Время выполнения поиска: {0}", watch.Elapsed.ToString());
                    Console.WriteLine("Трудоемкость алгоритма равна: {0}", a); // т.к. проходим один раз по циклу и сразу ищем
                }

                if (choice == "4") //БИНАРНЫЙ ПОИСК 
                {
                    BubbleSort(arrNew);
                    Console.Write("Введите число, которое искать: ");
                    var s = Console.ReadLine();
                    foreach (var ch in s)
                    {
                        if (ch == ',' || ch == '.')
                        {
                            Console.WriteLine("Неверный ввод числа");
                            return 0;
                        }
                    }
                    int n = Int32.Parse(s);
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    BinarySearch(arrNew, n, a);
                    if (BinarySearch(arrNew, n, a) != -1)
                    {
                        Console.WriteLine("Число {0} находится на {1} позиции", n, BinarySearch(arrNew, n, a) + 1);
                    }
                    else if (BinarySearch(arrNew, n, a) == -1)
                    {
                        Console.WriteLine("Элемент не найден");
                    }
                    watch.Stop();
                    //watch.Reset();
                    var tr = Math.Log(a, 2);
                    Console.WriteLine("");
                    Console.WriteLine("Время выполнения поиска: {0}", watch.Elapsed.ToString());
                    Console.WriteLine("Трудоемкость алгоритма равна: {0}", tr);
                }
                Console.WriteLine("");
                Console.WriteLine("Хотите выйти (Да/Нет)");
                key = Console.ReadLine();
            } while (key != "Да");


            //СОРТИРОВКА ПУЗЫРЬКОМ
            void BubbleSort(int[] arr)
            {
                int temp;
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
                Console.Write("Отсортированный массив: ");
                foreach (var ch in arr)
                    Console.Write("{0} ", ch);
            }

            //ЛИНЕЙНЫЙ ПОИСК
            int LineSearch(int[] arr, int search)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == search)
                    {
                        return i;
                    }
                }
                return -1;
            }

            //БЫСТРАЯ СОРТИРОВКА
            void quickSort(int[] array, int first, int last)
            {
                var p = array[(last + first) / 2];
                int temp;
                int i = first;
                int j = last;
                do
                {
                    while (array[i] < p) i++;
                    while (array[j] > p) j--;
                    if (i <= j)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        ++i;
                        --j;
                    }
                } while (i <= j);
                if (j > first) quickSort(arrNew, first, j);
                if (i < last) quickSort(arrNew, i, last);
            }

            //БИНАРНЫЙ ПОИСК
            int BinarySearch(int[] arr, int n, int len)
            {
                int first = 0;
                int last = len-1;
                int mid = 0;
                while (first <= last)
                {
                    mid = (first + last)/2;
                    if (n < arr[mid])
                        last = mid - 1;
                    else if (n > arr[mid])
                        first = mid + 1;
                    else
                        return mid;
                }
                return -1;
            }


            return 0;
        }

        


    }
}
