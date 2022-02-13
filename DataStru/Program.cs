using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStru
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine("Hello World!");
            // prg.TestContainsDuplicateI();
            //prg.TestContainsNearByDuplicate();
            //prg.Test_ContainsNearbyAlmostDuplicate();

            //prg.Test_MaxSubArray();

            // prg.Test_TwoSum();

            //prg.Test_Merge();

            // prg.Test_MergeTwoLists();

            //TestArrayDay3 testArr = new TestArrayDay3();
            // testArr.TestIntersect();
            //testArr.TestMaxProfit();
            //testArr.TextMatrixReshape();
            //testArr.TestSlidingWindowMax();

            prg.Test_BST();

            //int[] arr = new int[] {10, 10, 10, 10, 10, 10};
            //prg.largestAndSecondLargest(arr, 6);

            // Sort the array
            // int[,] array2Da = new int[4, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            /*int[][] intervals = new int[4][] { 
                new int[]{1,3},
                new int[] {8,6},
                new int[] {2,10}, new int[]{15,18}};
            prg.MergeIntervals(intervals);
            */

            // prg.TestLinkedList();

            // prg.TestGraph();

            // prg.TestSorting();
        }

        private void TestContainsDuplicateI() {
            ContainsDuplicate217 containsDuplicate = new ContainsDuplicate217();
            int[] num = new int[] {1, 2, 3};
            Console.WriteLine(containsDuplicate.ContainsDuplicate(num));

            num = new int[] {1, 2, 3, 1};
            Console.WriteLine(containsDuplicate.ContainsDuplicate(num));

            num = new int[] {1, 2, 3, 4};
            Console.WriteLine(containsDuplicate.ContainsDuplicate(num));

            num = new int[] {1, 1, 1, 3, 2, 4, 3, 2, 2, 3};
            Console.WriteLine(containsDuplicate.ContainsDuplicate(num));

            containsDuplicate = null;
            return;
        } 

        private void TestContainsNearByDuplicate() {
            ContainsDuplicate217 containsDuplicate = new ContainsDuplicate217();

            // Test 1
            int[] num = new int[] {1, 2, 3, 1};
            int k = 3;
            Console.WriteLine("Test 1: " + containsDuplicate.ContainsNearbyDuplicate(num, k));

            // Test 2
            num = new int[] {1, 0, 1, 1};
            k = 1;
            Console.WriteLine("Test 2: " + containsDuplicate.ContainsNearbyDuplicate(num, k));

            // Test 3
            num = new int[] {1, 2, 3, 1, 2, 3};
            k = 2;
            Console.WriteLine("Test 3 : " + containsDuplicate.ContainsNearbyDuplicate(num, k));

            containsDuplicate = null;
            return;
        }

        private void Test_ContainsNearbyAlmostDuplicate() {
            ContainsDuplicate217 containsDuplicate = new ContainsDuplicate217();

            // Test 1
            int[] num = new int[] {1, 2, 3, 1};
            int k = 3; int t = 0;
            //Console.WriteLine("Test 1: " + containsDuplicate.ContainsNearbyAlmostDuplicate(num, k, t));

            // Test 2
            num = new int[] {1, 0, 1, 1};
            k = 1; t = 2;
            //Console.WriteLine("Test 2: " + containsDuplicate.ContainsNearbyAlmostDuplicate(num, k, t));

            // Test 2
            num = new int[] {1, 5, 9, 1, 5, 9};
            k = 2; t = 3;
            //Console.WriteLine("Test 3: " + containsDuplicate.ContainsNearbyAlmostDuplicate(num, k, t));

            // Test 4
            num = new int[] {8,7,15,1,6,1,9,15};
            k = 1; t = 3;  // Expected True
            //Console.WriteLine("Test 4: " + containsDuplicate.ContainsNearbyAlmostDuplicateIII(num, k, t));

            // Test 5
            num = new int[] {2147483647,-1,2147483647};
            k = 1; t = 2147483647;
            Console.WriteLine("Test 5: " + containsDuplicate.ContainsNearbyAlmostDuplicateIII(num, k, t));

            containsDuplicate = null;
            return;
        }

        private void Test_MaxSubArray() {
            MaximumSubarray53 max = new MaximumSubarray53();
            int[] nums;
            //nums = new int[] {-2, -3, 4, -1, -2, 1, 5, -3};  // 7
            nums = new int[] {-4, -2, -3, -4, -5};  // -2
            //nums = new int[] {-1};  // -1
            //nums = new int[] {}; // int.MinValue == -2147483648
            //nums = new int[] {-5, 1, -3, 7, -1, 2, 1, -4, 6}; // 11

            Console.WriteLine("Maximum contigous sum DP = " +  max.MaxSubArray(nums));
            Console.WriteLine("Maximum contigous sum D&C = " +  max.MaxSubArray_DivideConquer(nums));

            return;
        }

        private void Test_TwoSum() {
            MaximumSubarray53 max = new MaximumSubarray53();
            //int[] nums = {2,7,11,15};
            //int target = 9;

            //int[] nums = {3, 2, 4};
            //int target = 6;

            int[] nums = {3, 3};
            int target = 6;
            int[] indices = max.TwoSum(nums, target);

            Console.WriteLine($"Output: [{indices[0]}, {indices[1]}]");
            Console.WriteLine( nums[indices[0]] + " + " +  nums[indices[1]] + " == " + target);        }

        private void Test_Merge() {
            MaximumSubarray53 max = new MaximumSubarray53();

            // Test case 1
            int[] nums1 = {1, 2, 3, 0, 0, 0};
            int[] nums2 = {2, 5, 6};
            int m = 3;
            int n = 3;

            // Test case 2
            // nums1 = new int[] {1};
            // nums2 = new int[] {};
            // m = 1; n = 0;

            // Test case 3
            // nums1 = new int[] {0};
            // nums2 = new int[] {1};
            // m = 0; n = 1;

            // Test case 4
            // nums1 = new int[] {2, 6, 7, 0, 0};
            // nums2 = new int[] {1, 5};
            // m = 3; n = 2;

            max.Merge(nums1, m, nums2, n);

            return;
        }

        private void Test_MergeTwoLists() {
            // Test case 1
            // ListNode list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            // ListNode list2 = new ListNode(1, new ListNode(3, new ListNode(4)));

            // Test case 2
            // ListNode list1 = null;
            // ListNode list2 = null;

            // Test case 3
            // ListNode list1 = null;
            // ListNode list2 = new ListNode(0);

            // Test case 5
            // ListNode list1 = new ListNode(1);
            // ListNode list2 = new ListNode(0, new ListNode(2));

            // Test case 4
            // ListNode list1 = new ListNode(1);
            // ListNode list2 = null;

            // Test case 5
            ListNode list1 = new ListNode(0, new ListNode(2)); 
            ListNode list2 = new ListNode(1);

            MaximumSubarray53 max = new MaximumSubarray53();

            ListNode result = max.MergeTwoListsIII(list1, list2);
            Console.WriteLine("Output: " + max.printListNode(result));

            result = null;
            list1 = null;
            list2 = null;
            max = null;
            return;
        }

        private void Test_BST() {
            TestBST_AVL bst = new TestBST_AVL();
            bst.BSTOperations();

            bst = null;
            return;
        }

        public int[] largestAndSecondLargest(int[] A,int N)
        {
            int max = int.MinValue;
            int secondMax = int.MinValue;
            //Your code here
            
            for (int i=0; i < A.Length; i++) {
                /*
                 i > both max
                    max = i
                    2ndMax = max
                 else i < max && i > 2nd
                    2ndMax = i
                */    
                if (A[i] > max && A[i] > secondMax) {
                    secondMax = max;
                    max = A[i];
                }
                else if (A[i] < max && A[i] > secondMax) {
                    secondMax = A[i];
                }
            }
            
            if (secondMax == int.MinValue)
                secondMax = -1;
            
            int[] maxs = new int[]{max, secondMax};
            return maxs;
        }

        public int[][] MergeIntervals(int[][] intervals) {
            
            // Sort the array
            //Array.Sort(intervals, (a, b) => Int32.CompareTo(a[0], b[0]));
            Sort<int>(intervals, 0); 

            Stack stack = new Stack();
            stack.Push(intervals[0]);
        
            for(int i=1; i < intervals.Length; i++) {
                int[] top = (int[])stack.Peek();
                
                if (top[1] < intervals[i][0])
                    stack.Push(intervals[i]);
                else if (top[1] < intervals[i][1]) {
                    top[1] = intervals[i][1];
                    stack.Pop();
                    stack.Push(top);
                }            
            }
            
            int[][] merged = new int[stack.Count][];
            int j= 0;
            while(stack.Count != 0) {
                //int[] top = (int[]) stack.Peek();
                //merged[j] = new int[top.Length];
                merged[j] = (int[]) stack.Pop();
                j++;
            }
            
            return merged;
        }
    
        private void Sort<T>(T[][] data, int col) 
        { 
            Comparer<T> comparer = Comparer<T>.Default;
            Array.Sort<T[]>(data, (x,y) => comparer.Compare(x[col],y[col])); 
        } 
  
        public void TestLinkedList() {
            TestLinkedList testLL = new TestLinkedList();

            //testLL.Operations();

            //testLL.HasCycle();

            // testLL.TestStack();

            //testLL.TestBalanceParentheses();

            //testLL.TestTrapRainWater();

            testLL.TestNumPairsDivisibleBy60();

            testLL = null;
            return;
        }

        public void TestGraph() {
            TestMyGraph tg = new TestMyGraph();
            tg.Operations();

            tg = null;
            return;
        }

        private void TestSorting() {
            TestSortingAlgo tsa = new TestSortingAlgo();
            tsa.TestMergeSort();

            tsa = null;
            return;
        }

    }


}
