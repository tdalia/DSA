using System;
using System.Collections.Generic;

/**
LeetCode - Data Structures
Easy/Medium - 53. Maximum Subarray 
Contains Duplicates I, II, III
*/

namespace DataStru {
    public class MaximumSubarray53 {

        /*
        Given an integer array nums, find the contiguous subarray (containing at least one number) 
        which has the largest sum and return its sum.
        A subarray is a contiguous part of an array.
        
        Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        Output: 6
        Explanation: [4,-1,2,1] has the largest sum = 6.
        
        Input: nums = [1]
        Output: 1

        Input: nums = [5,4,-1,7,8]
        Output: 23

        Constraints:
            1 <= nums.length <= 105
            -104 <= nums[i] <= 104
        Follow up: If you have figured out the O(n) solution, try coding another solution using 
        the divide and conquer approach, which is more subtle.

    Runtime: 224 ms, faster than 35.84% of C# online submissions for Maximum Subarray.
    Memory Usage: 47.4 MB, less than 81.66% of C# online submissions for Maximum Subarray.
        */
        // Use of Dynamic Programming approach   O(n)
        // Kadane's Algorithm https://en.wikipedia.org/wiki/Maximum_subarray_problem#Kadane's_algorithm
        public int MaxSubArray(int[] nums) {
            int maxSoFar = int.MinValue;
            int maxEnding = 0;

            for (int i=0; i < nums.Length; i++) {
                maxEnding = Math.Max(nums[i], maxEnding + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEnding);

                //Console.WriteLine($"i = {i}, num = {nums[i]}, maxSoFar = {maxSoFar}, maxEnding = {maxEnding}  ");
            }

            return maxSoFar;
        }

        // Divide and Conquer approach  O(nLog(n))
        // https://www.geeksforgeeks.org/maximum-subarray-sum-using-divide-and-conquer-algorithm/?ref=lbp
    // Runtime: 240 ms, faster than 26.29% of C# online submissions for Maximum Subarray.
    //Memory Usage: 47.5 MB, less than 81.66% of C# online submissions for Maximum Subarray.
        public int MaxSubArray_DivideConquer(int[] nums) {
            if (nums.Length == 0)
                return int.MinValue;
            return helperDivNConq(nums, 0, nums.Length - 1);
        }

        private int helperDivNConq(int[] nums, int l, int h) {
            // Only 1 element
            if (l == h)
                return nums[l];
            
            int mid = (l+h) / 2;
            int sum = 0, leftMax = int.MinValue, rightMax = int.MinValue;

            // Calc Sum of left side of array
            for (int i = mid; i >= l; i--) {
                sum += nums[i];
                if (sum > leftMax)
                    leftMax = sum;
            }

            sum = 0;
            // Calc Sum of right side of array
            for (int i = mid+1; i <= h; i++) {
                sum += nums[i];
                if (sum > rightMax)
                    rightMax = sum;
            }

            int max = Math.Max(helperDivNConq(nums, l, mid), 
                                helperDivNConq(nums, mid+1, h));
            
            return Math.Max(max, leftMax + rightMax);

        }

        /**
         * Two Sum  - https://leetcode.com/problems/two-sum/
         * 
         * Given an array of integers, return indices of the two numbers such that they add up to a specific target.
         * You may assume that each input would have exactly one solution, and you may not use the same element twice.
         * 
         * Given nums = [2, 7, 11, 15], target = 9,
         *   Because nums[0] + nums[1] = 2 + 7 = 9,
         *   return [0, 1].

            O(n)
    Runtime: 140 ms, faster than 65.36% of C# online submissions for Two Sum.
    Memory Usage: 42.9 MB, less than 14.86% of C# online submissions for Two Sum
         */
        public int[] TwoSum(int[] nums, int target)
        {
            int[] indices = new int[2] { 0, 0 };

            Dictionary<int, int> numbersDict = new Dictionary<int, int>();

            for (int i = 0, difference = 0; i < nums.Length; i++)
            {
                difference = target - nums[i];
                if (numbersDict.TryGetValue(difference, out int secondIndex))
                {
                    indices[1] = i;
                    indices[0] = secondIndex;

                    break;
                }

                if (!numbersDict.ContainsKey(nums[i]))
                {
                    numbersDict.Add(nums[i], i);
                }
            }

            numbersDict = null;
            return indices;
        }

        /**
        88. Merge Sorted Array   https://leetcode.com/problems/merge-sorted-array/
        You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, 
        and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
        
        Merge nums1 and nums2 into a single array sorted in non-decreasing order.
        
        The final sorted array should not be returned by the function, but instead be stored 
        inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m 
        elements denote the elements that should be merged, and the last n elements are set to 0 and 
        should be ignored. nums2 has a length of n.

        Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
        Output: [1,2,2,3,5,6]
        Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
        The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.

        Input: nums1 = [1], m = 1, nums2 = [], n = 0
        Output: [1]
        Explanation: The arrays we are merging are [1] and [].
        The result of the merge is [1].

    Runtime: 116 ms, faster than 93.31% of C# online submissions for Merge Sorted Array.
    Memory Usage: 41.2 MB, less than 11.17% of C# online submissions for Merge Sorted Array.
        */
        public void Merge(int[] nums1, int m, int[] nums2, int n) {
            int i = nums1.Length - 1;
            m = m-1;
            n = n-1;

            while (m >= 0 && n >= 0) {
                if (nums1[m] <= nums2[n])
                    nums1[i--] = nums2[n--];
                else
                    nums1[i--] = nums1[m--];
            }

            while (m < 0 && i >= 0)
                nums1[i--] = nums2[n--];

            Console.WriteLine("Output = " + printArray(nums1));
        }

        public void Merge_ORG(int[] nums1, int m, int[] nums2, int n) {
            // If there are no elements in nums1 & some elements in nums2
            // Assign nums2 to nums1
            if (m == 0 && n > 0) {
                nums1 = nums2;
                //Console.WriteLine("Res m == 0 = " + printArray(nums1));
                return;
            }

            // If nums2 has no elements, we don't have to do anything
            if (m > 0 && n == 0) {
                //Console.WriteLine("Res n == 0 = " + printArray(nums1));
                return;
            }

            // Both m & n are greater than 0
            m -= 1; n -= 1;
            for (int i = nums1.Length-1; i >= 0; i--) {
                if (m >= 0 && n >= 0) {
                    if (nums1[m] > nums2[n]) {
                        nums1[i] = nums1[m];
                        m--;
                    }
                    else if (nums2[n] > nums1[m]) {
                        nums1[i] = nums2[n];
                        n--;
                    } else {    // both are equal
                        nums1[i] = nums1[m];
                        nums1[--i] = nums2[n];
                        m--;
                        n--;
                    }
                } else {
                    // num2 doesn't contains any more items to be merged
                    if (n < 0) {
                        nums1[i] = nums1[m];
                        m--;
                    }
                    else if (m < 0) {
                        nums1[i] = nums2[n];
                        n--;
                    }
                }

                //Console.WriteLine("Res = " + printArray(nums1));
            }

            return;
        }

        /**
        You are given the heads of two sorted linked lists list1 and list2.

        Merge the two lists in a one sorted list. The list should be made by 
        splicing together the nodes of the first two lists.

        Return the head of the merged linked list.

        Input: list1 = [1,2,4], list2 = [1,3,4]
        Output: [1,1,2,3,4,4]

        Input: list1 = [], list2 = []       Output: []

        Input: list1 = [], list2 = [0]      Output: [0]

        Constraints:
            The number of nodes in both lists is in the range [0, 50].
            -100 <= Node.val <= 100
            Both list1 and list2 are sorted in non-decreasing order.

    Runtime: 88 ms, faster than 49.10% of C# online submissions for Merge Two Sorted Lists.
    Memory Usage: 38.8 MB, less than 67.22% of C# online submissions for Merge Two Sorted Lists.
        */
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
            ListNode merged = new ListNode();
            ListNode tail = merged;
            
            while (true) {
                if (list1 == null) {
                    tail.next = list2;
                    break;
                }

                if (list2 == null) {
                    tail.next = list1;
                    break;
                }

                if (list1.val <= list2.val) {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }

            Console.WriteLine("Before making tail as null: " + printListNode(merged));
            tail = merged;
            merged = merged.next;
            tail = null;
            list1 = null;
            list2 = null;

            return merged;
        }

    // Runtime: 84 ms, faster than 72.22% of C# online submissions for Merge Two Sorted Lists.
    // Memory Usage: 38.7 MB, less than 77.75% of C# online submissions for Merge Two Sorted Lists.
        public ListNode MergeTwoListsII(ListNode list1, ListNode list2) {
            ListNode merged = new ListNode();
            ListNode tail = merged;
            
            while(list1 != null && list2 != null) {
                if (list1.val <= list2.val) {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }

            if (list1 == null) 
                tail.next = list2;

            if (list2 == null) 
                tail.next = list1;

            Console.WriteLine("Before making tail as null: " + printListNode(merged));
            tail = merged;
            merged = merged.next;
            tail = null;
            list1 = null;
            list2 = null;

            return merged;
        }

    // Runtime: 72 ms, faster than 98.68% of C# online submissions for Merge Two Sorted Lists.
    // Memory Usage: 39.2 MB, less than 22.10% of C# online submissions for Merge Two Sorted Lists.
        public ListNode MergeTwoListsIII(ListNode list1, ListNode list2) {
            ListNode merged = null; 
            ListNode tail = merged;
            
            while(list1 != null && list2 != null) {
                if (list1.val <= list2.val) {
                    ListNode newNode = new ListNode(list1.val);
                    if (merged == null)
                        merged = newNode;
                    else 
                        tail.next = newNode;
                    tail = newNode;
                    list1 = list1.next;
                }
                else {
                    ListNode newNode = new ListNode(list2.val);
                    if (merged == null)
                        merged = newNode;
                    else 
                        tail.next = newNode;
                    tail = newNode;
                    list2 = list2.next;
                }
            }

            if (list1 != null) {
                if (merged == null)
                    merged = list1;
                else
                    tail.next = list1;
            }

            if (list2 != null) {
                if (merged == null)
                    merged = list2;
                else
                    tail.next = list2;
            }

            Console.WriteLine("Before making tail as null: " + printListNode(merged));
            tail = null;
            list1 = null;
            list2 = null;

            return merged;
        }

        internal string printArray<T>(T[] array)
        {
            string result = String.Format("[{0}]", string.Join(", ", array));

            return result;
        }

        internal string printListNode(ListNode node) {
            string result = "{ ";

            while(node != null) {
                result += node.val;
                node = node.next;
                if (node != null)
                    result += ", ";
            }
            result += " }";
            return result;
        }

    }
}