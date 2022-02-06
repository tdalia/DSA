 
 using System;
 using System.Diagnostics;

 /**
LeetCode - Data Structures I  
Day 3 - Arrays - https://leetcode.com/study-plan/data-structure/?progress=m6wxre6
*/

 namespace DataStru {
     class TestArrayDay3 {
         
        public int[] TestIntersect() {
            // Test 1
            int[] nums1 = new int[] {1, 2, 2, 1};
            int[] nums2 = new int[] {2, 4, 2, 3};

            // Test 2
            // int[] nums1 = new int[] {4, 9, 5};
            // int[] nums2 = new int[] {9, 4, 9, 8, 4};

            // int[] nums1 = new int[] {};
            // int[] nums2 = new int[] {2, 2};

            ArrayDay3 arr = new ArrayDay3();

            Stopwatch stopWatch = Stopwatch.StartNew();
            int[] result = arr.Intersect(nums1, nums2);
            stopWatch.Stop();

            // Console.WriteLine($"GC Mem : {0}", GC.GetTotalMemory(true));            
            Console.WriteLine("Time Elapsed : {0} ms", stopWatch.Elapsed.Milliseconds);
            stopWatch = null;

            Console.WriteLine("Output: " + Utils.printArray(result));

            return result;
        }

        public void TestMaxProfit() {
            // Test case 1
            // int[] prices = {7,1,5,3,6,4};
            // Test case 2
            // int[] prices = {7,6,4,3,1};

            // Test case 3
            //int[] prices = {1, 7};  // {1}; // {}

            // Test case 4
            // int[] prices = {100, 180, 260, 310, 40, 535, 695};

            ArrayDay3 arr = new ArrayDay3();
            int maxProfit = 0;
            //maxProfit = arr.MaxProfit(prices);
            //maxProfit = arr.MaxProfit_III(prices);
            //Console.WriteLine("Max Profit: " + maxProfit);

            int[] nums = {1, 2};
            System.Collections.Generic.IList<int> majorEle = arr.MajorityElement_II(nums);
            Console.WriteLine("Majority : ");
            foreach (var item in majorEle)
            {
                Console.Write(item);    
            }
            
            Console.WriteLine("\n");
            arr = null;
            return;
        }

        public void TextMatrixReshape() {
            int[][] mat = new int[2][];
            mat[0] = new int[] {1,2};
            mat[1] = new int[] {3,4};
            int r = 1; int c = 4;
            ArrayDay3 arr = new ArrayDay3();
            int[][] reshapedMatrix = arr.MatrixReshape(mat, r, c);
            Console.WriteLine("Reshaped: " + Utils.printMatrix(reshapedMatrix));
        }

        public void TestSlidingWindowMax() {
            ArrayDay3 arr = new ArrayDay3();
            int[] res;
            int[] nums = { 1,3,-1,-3,5,3,6,7 };
            nums = new int[]{ 1, -1 };
            //nums = new int[]{ 1 };
            //nums = new int[]{ 1,3,-1,-3,5 };
            nums = new int[] { 7, 2, 4 };
            int k = 3;
            k = 1;
            //k = 2;
/*
            nums = new int[] { 7, 2, 4 };   k = 2;
            int[] res = arr.MaxSlidingWindow_Optimized2(nums, k);
            Console.WriteLine(Utils.printArray(res));

            nums = new int[]{ 1 };  k = 1;
            res = arr.MaxSlidingWindow_Optimized2(nums, k);
            Console.WriteLine(Utils.printArray(res));

            nums = new int[]{ 1, -1 };  k = 1;
            res = arr.MaxSlidingWindow_Optimized2(nums, k);
            Console.WriteLine(Utils.printArray(res));

            nums = new int[]{ 1,3,-1,-3,5 };    k = 3;
            res = arr.MaxSlidingWindow_Optimized2(nums, k);
            Console.WriteLine(Utils.printArray(res));
*/
            nums = new int[] { 1,3,-1,-3,5,3,6,7 };   k = 3;
            res = arr.MaxSlidingWindow_Optimized2(nums, k);
            Console.WriteLine(Utils.printArray(res));

        }

     }
 }