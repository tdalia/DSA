using System;

namespace DataStru {
    class TestSortingAlgo {

        public void TestMergeSort() {
            SortingAlgo sa = new SortingAlgo();

            int[] arr = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            // sa.MergeSort(arr);

            arr = new int[] { 12, 11, 13, 5 };
            sa.MergeSortInPlace(arr, 0, arr.Length-1);

            sa = null;
            return;
        }

        public void TestBubble_InsertSort() {
            SortingAlgo sa = new SortingAlgo();

            int[] arr = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};

            // Bublbe Sort
            Console.WriteLine("*** Bubble Sort  [O(n ^ 2)]");
            Console.WriteLine("Original Arr -> " + Utils.printArray(arr));
            int[] res = sa.BubbleSort(arr);
            Console.WriteLine("Sorted Arr => " + Utils.printArray(res));

            // Insertion Sort
            arr = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            Console.WriteLine("\n*** Insertion Sort  [O(n ^ 2)]");
            Console.WriteLine("Original Arr -> " + Utils.printArray(arr));
            res = sa.InsertionSort(arr);
            Console.WriteLine("Sorted Arr => " + Utils.printArray(res));


            // Selection Sort
            arr = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            Console.WriteLine("\n*** SelectionSort Sort  [O(n ^ 2)]");
            Console.WriteLine("Original Arr -> " + Utils.printArray(arr));
            res = sa.SelectionSort(arr);
            Console.WriteLine("Sorted Arr => " + Utils.printArray(res));

            
            sa = null;
            return;
            
        }

        public void TestShellSort() {
            SortingAlgo sa = new SortingAlgo();

            int[] arr = new int[] {35, 33, 42, 10, 14, 19, 27, 44};
            int[] res;
            
            // Shell Sort
            /*
            Console.WriteLine("*** Shell Sort  [O(n)]");
            Console.WriteLine("Original Arr -> " + Utils.printArray(arr));
            res = sa.ShellSort(arr);
            Console.WriteLine("Sorted Arr => " + Utils.printArray(res));
            */

            // Quick Sort            
            Console.WriteLine("*** Quick Sort  [O(n)]");
            arr = new int[] {35, 33, 42, 10, 14, 19, 27, 44};
            arr = new int[] {4, 6, 3, 2, 1, 9, 7};
            Console.WriteLine("Original Arr -> " + Utils.printArray(arr));
            res = sa.QuickSort(arr, 0, arr.Length-1);
            Console.WriteLine("Sorted Arr => " + Utils.printArray(res));

            sa = null;
            return;            
        }
    }
}