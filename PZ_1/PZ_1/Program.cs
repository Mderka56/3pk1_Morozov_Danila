using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] array = new int[5000];
            List<int> list = new List<int>();
            Hashtable hash = new Hashtable();
            
            for (int i = 0; i < array.Length; i++)
            {
                int random = rand.Next(1, 1000);
                hash.Add(i, random);
                array[i] = random;
                list.Add(random);

            }

            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine($"Искомое число:");
            int target = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Прямой способ");
            Console.WriteLine("------------------");

            stopWatch.Start();

            int index = 0;

            while (index < array.Length && array[index] != target)
            {
                index++;
                if (index < array.Length)
                {
                    Console.WriteLine($"Число {target} найдено в массиве");
                    break;
                }
                else
                {
                    Console.WriteLine($"Число {target} не найдено в массиве");
                    break;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Время Поиска: {stopWatch.Elapsed}");

            stopWatch.Reset();
            stopWatch.Start();

            index = 0;
            while (index < list.Count && list[index] != target)
            {
                index++;
                if (index < list.Count)
                {
                    Console.WriteLine($"Число {target} найдено в списке");
                    break;
                }
                else
                {
                    Console.WriteLine($"Число {target} не найдено в списке");
                    break;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Stopwatch: {stopWatch.Elapsed}");

            stopWatch.Reset();
            stopWatch.Start();

            index = 0;
            while (index < hash.Count && Convert.ToInt32(hash[index]) != target)
            {
                index++;
                if (index < hash.Count)
                {
                    Console.WriteLine($"Число {target} найдено в хэш таблице");
                    break;
                }
                else
                {
                    Console.WriteLine($"Число {target} не найдено в хэш таблице");
                    break;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Stopwatch: {stopWatch.Elapsed}");

            Console.WriteLine("------------------");
            Console.WriteLine("Бинарный поиск");
            
            stopWatch.Reset();
            stopWatch.Start();

            Array.Sort(array);
            int middle, left = 0, right = array.Length - 1;
            middle = (left + right) / 2;
            if (target > array.Length)
                left = middle + 1;
            else
                right = middle - 1;
            while ((array[middle] != target) && (left <= right))
            {
                if (array[middle] == target)
                {
                    Console.WriteLine($"Число {target} найдено в массиве");
                    break;
                }
                else
                {
                    Console.WriteLine($"Число {target} не найдено в массиве");
                    break;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Stopwatch: {stopWatch.Elapsed}");

            stopWatch.Reset();
            stopWatch.Start();


            left = 0;
            right = list.Count - 1;
            middle = (left + right) / 2;
            if (target > list.Count)
                left = middle + 1;
            else
                right = middle - 1;
            while ((list[middle] != target) && (left <= right))
            {
                if (list[middle] == target)
                {
                    Console.WriteLine($"Число {target} найдено в списке");
                    break;
                }
                else
                {
                    Console.WriteLine($"Число {target} не найдено в списке");
                    break;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Stopwatch: {stopWatch.Elapsed}");

            stopWatch.Reset();
            stopWatch.Start();


            
            left = 0;
            right = hash.Count - 1;
            middle = (left + right) / 2;
            if (target > hash.Count)
                left = middle + 1;
            else
                right = middle - 1;
            while ((Convert.ToInt32(hash[middle]) != target) && (left <= right))
            {
                if (Convert.ToInt32(hash[middle]) == target)
                {
                    Console.WriteLine($"Число {target} найдено в массиве");
                    break;
                }
                else
                {
                    Console.WriteLine($"Число {target} не найдено В массиве");
                    break;
                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Stopwatch: {stopWatch.Elapsed}");
        }
    }
}
