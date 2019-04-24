using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _1_Even_Numbers_Thread
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var startNumber = int.Parse(Console.ReadLine());
            var endNumber = int.Parse(Console.ReadLine());

            Thread evens = new Thread(() => PrintEvwnNumbers(startNumber, endNumber));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvwnNumbers(int startNumber, int endNumber)
        {
            var numbers = Enumerable.Range(startNumber, endNumber);
            var evenNumbersCollection = new List<int>();


            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    evenNumbersCollection.Add(num);
                }
            }

            Console.WriteLine(string.Join("\n", evenNumbersCollection));
        }
    }
}
