using System;

namespace DataStru {
    class SortingAlgo {

        /// MergeSort using another array to store the results
        /// Space: O(N), Time: O(N)
        /// Calls recursively
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

        /// Combine the divided subarrays
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

        /// MergeSort using in-place passing the values of left & right indexes, 
        /// so no need to have another array to store the results
        /// Space: O(1), Time: O(N)
        /// Call recursively
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

        /// Bubble Sort - In-Place
        /// Space: O(1), Time: O(N ^ 2)
        public int[] BubbleSort(int[] arr) {

            int n = arr.Length;
            if (n <= 1)
                return arr;

            n = n - 1;
            bool swapped = false;   // flag to check if any items are swapped or not, if not, mean arr is sorted

            int temp;
            for (int i = 0 ; i < n; i++) {

                // Since the highest ele is placed in the last position(s),
                // we can shorten the execution of j loop for j < n-i instead of j < n
                for (int j = 0; j < n-i; j++) {
                    if (arr[j] > arr[j+1]) {
                        // Swap items
                        temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;

                        swapped = true;
                    }
                }

                if (! swapped) {
                    break;  // arr is sorted, that's why no swaps are done
                }
            }

            return arr;
        }

        /// Insertion Sort - In-Place, Suitable for large data sets
        /// Space: O(1), Time: O(N ^ 2)
        public int[] InsertionSort(int[] arr) {

            int holePosition, valueToInsert;
            int n = arr.Length;
            if (n < 2)
                return arr;
            
            //n = n - 1;
            for (int i = 1; i < n; i++) {
                // Select value to insert
                valueToInsert = arr[i];
                holePosition = i;

                // locate holeposition for the value to be inserted
                while (holePosition > 0 && arr[holePosition - 1] > valueToInsert) {
                    arr[holePosition] = arr[holePosition - 1];
                    holePosition = holePosition - 1;
                }

                // insert value at holeposition
                arr[holePosition] = valueToInsert;
            }

            return arr;
        }

        /// Selection Sort - In-Place, NOT Suitable for large data sets
        /// Finds the smallest element and places it in the sorted area of the array
        /// Space: O(1), Time: O(N ^ 2)
        public int[] SelectionSort(int[] arr) {

            int n = arr.Length;
            if (n < 2)
                return arr;
            
            //n = n - 1;
            int lowest, lowIndex;
            for (int i = 0; i < n; i++) {
                // Set the lowest value 
                lowest = arr[i];
                lowIndex = i;

                // find the element loest than the lowest
                for (int j = i+1; j < n; j++) {
                    // Compare the value of lowIndex with j of the arr
                    if (arr[j] < arr[lowIndex])
                        lowIndex = j;
                }

                // If lowIndex has changed (from i), the swap the items
                if (lowIndex != i) {
                    int temp = arr[lowIndex];
                    arr[lowIndex] = arr[i];
                    arr[i] = temp;
                }
            }

            return arr;
        }

        /// Shell Sort 
        /// Highly efficient on mid-sized data, based on insertion Sort. 
        /// Divides the data into intervals using Knuth's Formula :
        /// interval = interval * 3 + 1     (initial value of interval is 1)
        /// Due to intervaling, needs less swaps
        /// Space: O(1), Time: O(N)
        public int[] ShellSort(int[] arr) {

            int inner, outer, valueToInsert;
            int interval = 1;
            int n = arr.Length;
            int i = 0;

            // Find the interval of elements for the array
            while (interval <= n/3 ) {
                interval = interval * 3 + 1;
            }

            while (interval > 0) {
                Console.WriteLine($"Iteration:  {i}, Interval Size: {interval} ");
                Console.WriteLine("Arr -> " + Utils.printArray(arr));

                for (outer = interval; outer < n; outer++) {
                    valueToInsert = arr[outer];
                    inner = outer;

                    while (inner > interval - 1 && arr[inner - interval] >= valueToInsert) {
                        arr[inner] = arr[inner - interval];
                        inner -= interval;
                        Console.WriteLine($"Item moved {arr[inner]} ");
                    }

                    arr[inner] = valueToInsert;
                    Console.WriteLine($"Item inserted {valueToInsert} at position {inner} ");
                }

                interval = (interval - 1) / 3;
                i++;
            }

            return arr;
        }

        /// QuickSort - Highly efficient
        /// Based on partinioning array into smaller arrays 
        public int[] QuickSort(int[] arr, int left, int right) {

            if (right - left <= 0) {
                return arr;
            } else {
                // Mark the last element as the pivot
                int pivot = arr[right];
                int partitionPoint = partition_QS(arr, left, right, pivot);
                QuickSort(arr, left, partitionPoint - 1);
                QuickSort(arr, partitionPoint + 1, right);
            }

            return arr;
        }

        private int partition_QS(int[] arr, int left, int right, int pivot) {
            int leftPointer = left - 1;
            int rightPointer = right;
            int temp;   // for swapping

            while(true) {
                while(arr[++leftPointer] < pivot) {
                    // do nothing
                }

                while (rightPointer > 0 && arr[--rightPointer] > pivot) {
                    // do nothing
                }

                if (leftPointer >= rightPointer) {
                    break;
                } else {
                    // Swap items
                    Console.WriteLine($"Items swaped: {arr[leftPointer]}, {arr[rightPointer]} ");
                    temp = arr[leftPointer];
                    arr[leftPointer] = arr[rightPointer];
                    arr[rightPointer] = temp;
                }
            }

            Console.WriteLine($"Pivot swaped: {arr[leftPointer]}, {arr[right]} ");
            temp = arr[leftPointer];
            arr[leftPointer] = arr[right];
            arr[right] = temp;

            Console.WriteLine("Updated Arr -> " + Utils.printArray(arr));
            return leftPointer;
        }

    }
}