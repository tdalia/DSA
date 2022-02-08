using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
    class BS
    {

        public void ExecuteSimpleBS() {
            int[] arr = {-4, -1, 3, 7, 10, 11};
            //findKey_Iterative(arr, 8, 0, arr.Length - 1);

            int key = -1;
            int ans = findKey_Recursive(arr, key, 0, arr.Length);
            Console.WriteLine($"Target {key} is found at index {ans}");

        }

        // Time = O(log n), Space = O(1)
        public int findKey_Iterative(int[] arr, int key, int start, int end) {
            int index = -1;

            while (start <= end ) {
                int mid = (start + end) / 2;

                if (arr[mid] == key) {
                    index = mid;
                    break;
                    //return mid;
                }     

                if (key < arr[mid]) {
                    end = mid - 1;
                }
                else {
                    start = mid +1;
                }
            }

            Console.WriteLine($"Target {key} is found at index {index}");
            return index;
        }

        // Recursive takes auxilary space for number of times it is being called
        // Time = Space == O(log n)
        private int findKey_Recursive(int[] arr, int key, int low, int high) {
            if (low > high )
                return -1;
            
            int mid = (low + high) / 2;
            if (key == arr[mid])
                return mid;

            if (key > arr[mid])
                return findKey_Recursive(arr, key, mid + 1, high);
            else
                return findKey_Recursive(arr, key, low, mid - 1);
        }

        /*
        Given a sorted array of integers, find the number of occurrences of a given target value.
        Your algorithm’s runtime complexity must be in the order of O(log n).
        If the target is not found in the array, return 0
        **Example : **
            Given [5, 7, 7, 8, 8, 10] and target value 8,
            return 2.
        https://www.interviewbit.com/problems/count-element-occurence/
        */
        public int CountFrequency(List<int> A, int target)
        {
            int count = 0;
            int n = A.Count;
            // Stores the 1st & last index occurences of the targer
            int firstIndex = 0, lastIndex = 0;
            
            if (n <= 0) {
                Console.WriteLine($"The target {target} CANNOT be found in the given array");
                return 0;
            }

            firstIndex = first(A, 0, n-1, target, n);

            if (firstIndex == -1) {
                Console.WriteLine("FistIndex is -1");
                return firstIndex;
            }
            lastIndex = last(A, firstIndex, n-1, target, n);
            count = lastIndex - firstIndex + 1;
              

            Console.WriteLine($"{firstIndex}, {lastIndex}, {count}");
            Console.WriteLine($"The target {target} is found {count} times in the given array");
            return count;
        }

        // If target is present in List, returns 1st index of target, else -1
        private int first(List<int> A, int start, int end, int target, int n) {
            if (end >= start) {
                int mid = (start + end) / 2;
                if ( (mid == 0 || target > A[mid-1]) && A[mid] == target )
                    return mid;
                else if (target > A[mid])
                    return first(A, (mid + 1), end, target, n);
                else 
                    return first(A, start, (mid - 1), target, n);
            }

            return -1;
        }

        // If target is present in List, returns last index of target, else -1
        private int last(List<int> A, int start, int end, int target, int n) {
            if (end >= start) {
                int mid = (start + end) / 2;
                if ( (mid == n-1 || target < A[mid+1]) && A[mid] == target)
                    return mid;
                else if (target < A[mid])
                    return last(A, start, (mid - 1), target, n);
                else 
                    return last(A, (mid + 1), end, target, n);
            }

            return -1;
        }

        /*
        Find an element in an infinite sorted array. Find solution in O(log n)
        We don't know the length of the array, so we can't find the low & high indexes.
        Without that, using Ninary Search we can get the results in O(log n).
        */
        private int findKeyInInfiniteArray(int[] arr, int key) {
            int low = 0, high = 1;

            // Loop until arr[high] is less than key
            while (arr[high] < key) {
                // Prepare a range where the key is possible there
                low = high;
                // Increase the high 2 times
                high = 2 * high;
            }

            // Now, we got our low & high indexes, 
            // We can perform binary search using these 
            return findKey_Iterative(arr, key, low, high);
        }

        //   Sorted & Rotated array - IMP Q
        /*
        An array is sorted, but is rotated some elements. Find if the index of the key 
        Eg: int[] = {20, 30, 40, 50, 60, 5, 10}
        Explaination - https://www.youtube.com/watch?v=Le8bc8aHgBA
        https://www.interviewbit.com/problems/rotated-sorted-array-search/
        */
        public void ExecuteSortedRotated() {
            int[] a = {20, 30, 40, 50, 60, 5, 10};
            int key = 20;
            int index = bsOn_SortedRotated(a, key);
            Console.WriteLine($"Key {key} is found at {index} index of the array.");
        }

        /*
        Logic:
        Get the middle index. 
        if value at low is less than at high, means left side is sorted.
        Find if the key is present between low & high values
        */
        private int bsOn_SortedRotated(int[] a, int key) {
            int low = 0, high = a.Length - 1;

            while (low <= high) {
                int mid = (low + high) / 2;

                if (key == a[mid]) {
                    return mid;
                }

                // If the left part is sorted
                if (a[low] < a[mid]) {
                    // Check if key is in the left part 
                    if (key >= a[low] && key < a[mid])
                        high = mid - 1;
                    else    
                        low = mid + 1;
                }
                // Left part is not sorted, so Right side is Sorted
                else {
                    if (key > a[mid] && key <= a[high])
                        low = mid + 1;
                    else
                        high = mid - 1;
                }
            }
            return -1;
        }


        // Binary Search for continous allocation
        /*
        Allocate Minimum pages
        Minimise the maximum number of pages read by a student
        An unsorted array is given with number of pages in each book. And number of students is given.

A = [5, 17, 100, 11]
    B = 4   Output - 100

A = [12, 34, 67, 90]
    B = 2
Output 1:
    113



        */
        public void ExecuteAllocateMinPages() {
            int[] a = {10, 5, 20};
            int k = 2;
            int pages = minPages(a, k);
            Console.WriteLine($"Min pages allocated to {k} students is {pages}");

            return;
        }

        private int minPages(int[] a, int k) {
            if (a == null || a.Length == 0) {
                return -1;
            }
            if (k == 0 || k > a.Length) {
                return -1;
            }

            // min = Find the maximum element in array
            // max = Find the sum of all elements in the array

            // Can use LINQ to get the Max ele & Sum of an array
                // That would iterate the array for each function == 2 times O(N)
            //int min = a.Max();  
            //int max = a.Sum(); 
            int min = a[0], max = a[0];
            for (int i =1; i < a.Length; i++) {
                max += a[i];
                if (a[i] > min)
                    min = a[i];
            }

            int res = 0;

            // If k is 1, then we can return the max, no need to do any further operations
            if (k == 1) {
                return max;
            }

            while (min <= max) {
                // Replace /2 by >> 1 - bitwise is much faster & same results
                int mid = (min + max) >> 1; // (min + max) / 2;

                // Check if array ele can be distributed among k
                if (isFeasible(a, k, mid)) {
                    // If feasible, then try to find the min allocation 
                    res = mid;
                    max = mid - 1;
                }
                else {
                    // We definitely need more 
                    min = mid + 1;
                }
            }

            return res;
        }

        private bool isFeasible(int[] a, int k, int res) {
            int students = 1, sum = 0;

            for (int i =0; i < a.Length; i++) {
                // Try to add the ele in sum, if it results greater than res
                if ( (sum + a[i]) > res) {
                    // Increment # of students;
                    students++;
                    sum = a[i];
                } else {
                    sum += a[i];
                }
            }

            return students <= k;
        }


    }
}