using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BS bs = new BS();

            // int[] arr = {1, 2, 6, 9, 9};    // {5, 7, 7, 8, 8, 10};

            // List<int> A = new List<int>(arr);
            // int B = 2; // 8;
            // bs.CountFrequency(A, B);

            //bs.ExecuteSimpleBS();

            //bs.ExecuteSortedRotated();

            bs.ExecuteAllocateMinPages();

            bs = null;
            return;
        }
    }
}
