using System;

namespace DataStru {
    class SortingAlgo {

        // MergeSort using another array to store the results
        // Space: O(N), Time: O(N)
        // Calls recursively
        public int[] MergeSort(int[] arr) {
            // Base case
            if (arr.Length <= 1) {
                return arr;
            }

            // Create arrays for left & right subarrays
            int mid = (arr.Length % 2 == 0) ? (arr.Length / 2) : (arr.Length / 2) + 1;
            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];
            int[] result = new int[arr.Length];

            int i;
            // Populate subarrays
            for (i = 0; i < mid; i++) {
                left[i] = arr[i];
            }
            i = mid;
            for (int j = 0; i < arr.Length; j++, i++) {
                right[j] = arr[i];
            }

            Console.WriteLine("Left Arr -> " + Utils.printArray(left));
            Console.WriteLine("Right Arr -> " + Utils.printArray(right));

            // Recursively divide the left & right subarray
            left = MergeSort(left);
            right = MergeSort(right);
            result = Merge(left, right);

            Console.WriteLine("Result Arr -> " + Utils.printArray(result));

            return result;
        }

        // Combine the divided subarrays
        private int[] Merge(int[] left, int[] right) {
            int resultLength = left.Length + right.Length;
            int[] result = new int[resultLength];

            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            // while either array has an element
            while (leftIndex < left.Length || rightIndex < right.Length) {
                // If both arrays have elements
                if (leftIndex < left.Length && rightIndex < right.Length) {
                    // If item on left is less, add that to the result, else add item on right
                    if (left[leftIndex] < right[rightIndex]) {
                        result[resultIndex] = left[leftIndex];
                        leftIndex++;
                    } else {
                        result[resultIndex] = right[rightIndex];
                        rightIndex++;
                    }
                    resultIndex++;
                }
                // If there are items in left[], but not in right[]
                else if (leftIndex < left.Length) {
                    result[resultIndex++] = left[leftIndex++];
                }
                // If there are items in right[], but not in left[]
                else if (rightIndex < right.Length) {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            return result;

        }

        // MergeSort using in-place passing the values of left & right indexes, 
        // so no need to have another array to store the results
        // Space: O(1), Time: O(N)
        // Call recursively
        public void MergeSortInPlace(int[] arr, int left, int right) {
            // Base case
            if (left < right) {
                // Find the middle point
                int mid = (left + (right - 1)) / 2;

                // Divide & Sort the halves
                MergeSortInPlace(arr, left, mid);                
                MergeSortInPlace(arr, mid+1, right);                                
                // Create, Sort & Merge the left & right indices
                MergeInPlace(arr, left, mid, right);
            }

            return;
        }

        private void MergeInPlace(int[] arr, int left, int mid, int right) {
            // Find the sizes of 2 subarrays to be merged
            int leftLen = mid - left + 1;
            int rightLen = right - mid;

            // Create temp arrays
            int[] LA = new int[leftLen];
            int[] RA = new int[rightLen];

            // Populate subarrays
            int i = 0, j = 0;
            for (; i < leftLen; i++ ) {
                LA[i] = arr[left + i];
            }
            for (; j < rightLen; j++) {
                RA[j] = arr[mid + 1 + j];
            }

            Console.WriteLine("Left Arr -> " + Utils.printArray(LA));
            Console.WriteLine("Right Arr -> " + Utils.printArray(RA));

            // Merge 2 subarrays 
            int leftIndex = 0, rightIndex = 0, resultIndex = left;

            // while there are elements in both the arrays
            while (leftIndex < leftLen && rightIndex < rightLen) {
                // If ele at left[] is smaller than that of right[]
                if (LA[leftIndex] < RA[rightIndex]) {
                    arr[resultIndex] = LA[leftIndex];
                    leftIndex++;
                } else {
                    arr[resultIndex] = RA[rightIndex];
                    rightIndex++;
                }
                resultIndex++;
            }

            // Copy the elements in left, if remaining
            while (leftIndex < leftLen) {
                arr[resultIndex++] = LA[leftIndex++];
            }

            // If there are elements in right[], copy that to arr
            while (rightIndex < rightLen) {
                arr[resultIndex++] = RA[rightIndex++];
            }

            Console.WriteLine("Merged Sorted -> " + Utils.printArray(arr));

            return;
        }
    }
}