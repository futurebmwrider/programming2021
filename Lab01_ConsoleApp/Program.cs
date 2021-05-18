using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab01_ConsoleApp
{
    class Program
    {
        public static int[] createIntRandomArray(int size, int from, int to)
        {
            int[] data = new int[size];
            var random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < size; ++i)
            {
                data[i] = random.Next(from, to);
            }
            return data;
        }
        static void Min(object ara)
        {
            int[] arr = (int[])ara;
            int result = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (result > arr[i])
                {
                    result = arr[i];
                }
            }
            Console.WriteLine("Minimum:{0} ", result);
        }
        static void Max(object ara)
        {
            int[] arr = (int[])ara;
            int result = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (result < arr[i])
                {
                    result = arr[i];
                }
            }
            Console.WriteLine("Maximum:{0} ", result);
        }
        static void Avg(object ara)
        {
            int[] arr = (int[])ara;
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }
            result = result / 10;
            Console.WriteLine("Averages:{0} ", result);
        }

        static void SortArr(int[] arr)
        {
            Console.WriteLine("-------Sorting arrays-------");
            Array.Sort(arr);
            for(int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("\n----------------------------");
        }
        static void Main(string[] args)
        {
            int[] arr = createIntRandomArray(10, 0, 100);
            
            SortArr(arr);

            Thread t1 = new Thread(new ParameterizedThreadStart(Min));
            t1.Start(arr);
            Thread.Sleep(1000);
            
            Thread t2 = new Thread(new ParameterizedThreadStart(Avg));
            t2.Start(arr);
            Thread.Sleep(1000);

            Thread t3 = new Thread(new ParameterizedThreadStart(Max));
            t3.Start(arr);
            Thread.Sleep(1000);

            Console.ReadKey();
        }
    }
}
