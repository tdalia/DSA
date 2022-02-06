 
 using System;
 using System.Collections.Generic;

 /**
LeetCode - Data Structures I  
Day 3 - Arrays - https://leetcode.com/study-plan/data-structure/?progress=m6wxre6
*/

 namespace DataStru {
     class ArrayDay3 {

    /**
         350. Intersection of Two Arrays II  https://leetcode.com/problems/intersection-of-two-arrays-ii/

         Given two integer arrays nums1 and nums2, return an array of their intersection. 
         Each element in the result must appear as many times as it shows in both arrays 
         and you may return the result in any order.

        Input: nums1 = [1,2,2,1], nums2 = [2,2]
        Output: [2,2]

        Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        Output: [4,9]
        Explanation: [9,4] is also accepted.

        Constraints:
            1 <= nums1.length, nums2.length <= 1000
            0 <= nums1[i], nums2[i] <= 1000

        Follow up:
    What if the given array is already sorted? How would you optimize your algorithm?
    What if nums1's size is small compared to nums2's size? Which algorithm is better?
    What if elements of nums2 are stored on disk, and the memory is limited such that 
        you cannot load all elements into the memory at once?

    Runtime: 124 ms, faster than 75.21% of C# online submissions for Intersection of Two Arrays II.
    Memory Usage: 41.7 MB, less than 24.24% of C# online submissions for Intersection of Two Arrays II.
         */
        public int[] Intersect(int[] nums1, int[] nums2) {

            List<int> result = new List<int>();
            int[] smallArr;  // Other array to work on
            int[] bigArr;

            // Assign the bigArr & arr based on size of arrays
            if (nums1.Length >= nums2.Length) {
                bigArr = nums1;
                smallArr = nums2;
            } else {
                bigArr = nums2;
                smallArr = nums1;
            }

            // Add elements of bigArr array in the dictionary &
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach(int num in bigArr) {
                if (dict.ContainsKey(num)) {
                    dict[num] = dict[num] + 1;
                } else
                    dict.Add(num, 1);
            }

            // Iterate thru smallArr
            int val = 0;
            foreach (int num in smallArr) {
                if (dict.TryGetValue(num, out val) && val > 0) {
                    dict[num] = --val;
                    result.Add(num);
                }
            }
            
            bigArr = null;  smallArr = null;    dict = null;

            return result.ToArray();
        }

        /**
        121. Best Time to Buy and Sell Stock    https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        You are given an array prices where prices[i] is the price of a given stock 
        on the ith day.

        You want to maximize your profit by choosing a single day to buy one stock 
        and choosing a different day in the future to sell that stock.

        Return the maximum profit you can achieve from this transaction. If you cannot
        achieve any profit, return 0.

        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.

        Constraints:
            1 <= prices.length <= 105
            0 <= prices[i] <= 104

[7,1,5,3,6,4]                   [7,6,4,3,1]
P   i   Sorted  P   i           P   i       Sorted  P   i
7   0           1   1           7   0               1   4
1   1           3   3           6   1               3   3
5   2           4   5           4   2               4   2
3   3           5   2           3   3               6   1
6   4           6   4           1   4               7   0
4   5           7   0

start = 0, end = prices.Length
start == end
    return 0;

i[start] > i[end]: (1 > 0)          (4 > 0), (4 > 1), (4>2), (4 > 3)
    end--;                              end--
else:   (1 <= 4)                     (0 <= 4)
    profit = p[end] - p[start]          profit = p[end] - p[start]  (7-1 == 6)          
    break

// Usigin Math
Runtime: 256 ms, faster than 55.41% of C# online submissions for Best Time to Buy and Sell Stock.
Memory Usage: 46.9 MB, less than 12.40% of C# online submissions for Best Time to Buy and Sell Stock.
// WITHOUT Using Math
Runtime: 248 ms, faster than 81.37% of C# online submissions for Best Time to Buy and Sell Stock.
Memory Usage: 46.6 MB, less than 64.71% of C# online submissions for Best Time to Buy and Sell Stock.
        */
        public int MaxProfit(int[] prices) {
            // If the prices has max of 1 element, return 0
            if (prices.Length <= 1)
                return 0;

            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 0; i < prices.Length; i++) {
                // minPrice = Math.Min(minPrice, prices[i]);
                minPrice = (minPrice < prices[i]) ? minPrice : prices[i];
                // maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
                int diff = prices[i] - minPrice;
                maxProfit = (maxProfit < diff) ? diff : maxProfit;
            }

            return maxProfit;
        }

    /*
    122. Best Time to Buy and Sell Stock II:
        https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        Given an integer array prices  of a given stock on the ith day.

        On each day, you may decide to buy and/or sell the stock. You can only hold at most one share of the stock at 
        any time. However, you can buy it then immediately sell it on the same day.

        Find and return the maximum profit you can achieve.

        Example 1:
            Input: prices = [7,1,5,3,6,4]
            Output: 7
            Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
            Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
            Total profit is 4 + 3 = 7.
        Example 2:
            Input: prices = [1,2,3,4,5]
            Output: 4
            Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
            Total profit is 4.
        Example 3:
            Input: prices = [7,6,4,3,1]
            Output: 0
            Explanation: There is no way to make a positive profit, so we never buy the stock to achieve the maximum profit of 0.
        Constraints:
            1 <= prices.length <= 3 * 104
            0 <= prices[i] <= 104
    */
        public int MaxProfit_II(int[] prices) { 
            // If the prices has max of 1 element, return 0
            if (prices.Length <= 1)
                return 0;
            
            int maxProfit = 0;
            for (int i=1; i < prices.Length; i++) {
                if (prices[i] > prices[i-1])
                    maxProfit += prices[i] - prices[i-1];
            }

            return maxProfit;
        }

    /*
    Buy & Sell at most 2 times
    123. Best Time to Buy and Sell Stock III https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iii/
        Buy & Sell at most 2 times
        You are given an array prices where prices[i] is the price of a given stock on the ith day.

        Find the maximum profit you can achieve. You may complete at most two transactions.

        Note: You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before you buy again).

        Example 1:
            Input: prices = [3,3,5,0,0,3,1,4]
            Output: 6
            Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
            Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
        Example 2:
            Input: prices = [1,2,3,4,5]
            Output: 4
            Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
            Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are engaging multiple transactions at the same time. You must sell before buying again.
        Example 3:
            Input: prices = [7,6,4,3,1]
            Output: 0
            Explanation: In this case, no transaction is done, i.e. max profit = 0.      
        Constraints:
            1 <= prices.length <= 105
            0 <= prices[i] <= 105
    */
        public int MaxProfit_III(int[] prices) {
            // If the prices has max of 1 element, return 0
            if (prices.Length <= 1)
                return 0;
            
            int first_buy = int.MinValue;
            int first_sell = 0;
            int second_buy = int.MinValue;
            int second_sell = 0;

            for (int i=0; i < prices.Length; i++) {

                first_buy = Math.Max(first_buy, -prices[i]);
                first_sell = Math.Max(first_sell, first_buy + prices[i]);
                second_buy = Math.Max(second_buy, first_sell - prices[i]);
                second_sell = Math.Max(second_sell, second_buy + prices[i]);
            }

            return second_sell;
        }


    /**
    566. Reshape the Matrix https://leetcode.com/problems/reshape-the-matrix/
        In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one 
        with a different size r x c keeping its original data.

        You are given an m x n matrix mat and two integers r and c representing the number of rows and the 
        number of columns of the wanted reshaped matrix.

        The reshaped matrix should be filled with all the elements of the original matrix in the same 
        row-traversing order as they were.

        If the reshape operation with given parameters is possible and legal, output the new reshaped matrix; 
        Otherwise, output the original matrix.

        Input: mat = [[1,2],[3,4]], r = 1, c = 4
        Output: [[1,2,3,4]]

        Input: mat = [[1,2],[3,4]], r = 2, c = 4
        Output: [[1,2],[3,4]]

        Constraints:
            m == mat.length
            n == mat[i].length
            1 <= m, n <= 100
            -1000 <= mat[i][j] <= 1000
            1 <= r, c <= 300

    Runtime: 148 ms, faster than 14.29% of C# online submissions for Reshape the Matrix.
    Memory Usage: 42.8 MB, less than 98.70% of C# online submissions for Reshape the Matrix.            
        */
        public int[][] MatrixReshapeI(int[][] mat, int r, int c) {

            // Check the validity of sizes to reshape the matrix
            // If invalid, return the mat
            int m = mat.Length; int n = mat[0].Length;
            if ((m * n) != (r * c))
                return mat;

            int[][] matrix = new int[r][];
            
            // Store all mat elements in a single dimen arr
            int[] temp = new int[m*n];
            int k = 0;            
            for(int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    temp[k++] = mat[i][j];
                }
            }

            // Shape the temp arr into new dimensions            
            k = 0;
            for(int i = 0; i < r; i++) {
                matrix[i] = new int[c];
                for (int j = 0; j < c; j++) {
                    matrix[i][j] = temp[k++];
                }
            }

            return matrix;
        }
 
    // Runtime: 132 ms, faster than 82.34% of C# online submissions for Reshape the Matrix.
    // Memory Usage: 43 MB, less than 85.45% of C# online submissions for Reshape the Matrix.
        public int[][] MatrixReshape(int[][] mat, int r, int c) {

            // Check the validity of sizes to reshape the matrix
            // If invalid, return the mat
            int m = mat.Length; 
            int n = mat[0].Length;
            if ((m * n) != (r * c))
                return mat;

            int[][] matrix = new int[r][];
            

            /*
            // Store all mat elements in a single dimen arr
            int[] temp = new int[m*n];
            int k = 0;            
            for(int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    temp[k++] = mat[i][j];
                }
            }*/

            // Shape the temp arr into new dimensions            
            int x = 0, y = 0;
            for(int i = 0; i < r; i++) {
                matrix[i] = new int[c];
                for (int j = 0; j < c; j++) {
                    matrix[i][j] = mat[x][y];
                    y++;

                    if (y == n) {
                        y =0;
                        x++;
                    }
                }
            }

            return matrix;
        }

    /*
    169. Majority Element I   https://leetcode.com/problems/majority-element/
        Given an array nums of size n, return the majority element.

        The majority element is the element that appears more than ⌊n / 2⌋ times. 
        You may assume that the majority element always exists in the array.

        Example 1:
            Input: nums = [3,2,3]
            Output: 3
        Example 2:
            Input: nums = [2,2,1,1,1,2,2]
            Output: 2
        Constraints:
            n == nums.length
            1 <= n <= 5 * 104
            -231 <= nums[i] <= 231 - 1
        
        TIME TOOK: 17:57 - 18:10 = 13 mins
        Runtime: 112 ms, faster than 51.03% of C# online submissions for Majority Element.
        Memory Usage: 42.5 MB, less than 58.06% of C# online submissions for Majority Element.
    */
        public int MajorityElement_I(int[] nums) 
        {
            if (nums.Length == 1) 
                return nums[0];
            
            Dictionary<int, int> countElements = new Dictionary<int, int>();
            foreach (int item in nums)            
            {
                if (countElements.ContainsKey(item)) {
                    int count = countElements[item];
                    countElements[item] = ++count;
                } else {
                    countElements.Add(item, 1);
                }
            }

            int k = nums.Length / 2;
            int maxCountSoFar = 0;
            int majorityEle = 0;
            foreach(var key in countElements.Keys) {
                int val = countElements[key];
                if (val > k && val > maxCountSoFar) {
                    maxCountSoFar = val;
                    majorityEle = key;
                }                    
            }

            return majorityEle;
        }

    /*
    229. Majority Element II  https://leetcode.com/problems/majority-element-ii/
        Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

        Example 1:
            Input: nums = [3,2,3]
            Output: [3]
        Example 2:
            Input: nums = [1]
            Output: [1]
        Example 3:
            Input: nums = [1,2]
            Output: [1,2]
        
        Constraints:
            1 <= nums.length <= 5 * 104
            -109 <= nums[i] <= 109
        DURATION: 10 mins
    Runtime: 186 ms, faster than 25.13% of C# online submissions for Majority Element II.
    Memory Usage: 42.5 MB, less than 83.96% of C# online submissions for Majority Element II.
    */
        public IList<int> MajorityElement_II(int[] nums) 
        {
            List<int> majorityEleList = new List<int>();
            if (nums.Length == 1) {
                majorityEleList.Add(nums[0]);
                return majorityEleList;
            }
            
            Dictionary<int, int> countElements = new Dictionary<int, int>();
            foreach (int item in nums)            
            {
                if (countElements.ContainsKey(item)) {
                    int count = countElements[item];
                    countElements[item] = ++count;
                } else {
                    countElements.Add(item, 1);
                }
            }

            int k = nums.Length / 3;
            

            foreach(var key in countElements.Keys) {
                int count = countElements[key];
                if (count > k) 
                    majorityEleList.Add(key);
            }


            return majorityEleList;
        }

    /*
    239. Sliding Window Maximum https://leetcode.com/problems/sliding-window-maximum/
        You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.

        Return the max sliding window.

        Example 1:
            Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
            Output: [3,3,5,5,6,7]
            Explanation: 
            Window position                Max
            ---------------               -----
            [1  3  -1] -3  5  3  6  7       3
            1 [3  -1  -3] 5  3  6  7       3
            1  3 [-1  -3  5] 3  6  7       5
            1  3  -1 [-3  5  3] 6  7       5
            1  3  -1  -3 [5  3  6] 7       6
            1  3  -1  -3  5 [3  6  7]      7
        Example 2:
            Input: nums = [1], k = 1
            Output: [1]
        
        Constraints:
            1 <= nums.length <= 105
            -104 <= nums[i] <= 104
            1 <= k <= nums.length

            11:25 - 11:57 -> Runtime error
    */
        // Working but, TIME LIMIT EXCEEDED
        public int[] MaxSlidingWindow(int[] nums, int k) {
            if (nums.Length == 1)
                return nums;
            if (k == 1)
                return nums;
                
            Queue<int> maxQ = new Queue<int>();
            int[] subArr = new int[k];
            
            int j = 0;  // to handle subArr index
            int i = 0;  // handle nums index
            int subMax = 0;
            while(i < nums.Length - 1) {
                subArr = new int[k];
                j = 0;
                int tempPtr = i+1;
                subMax = int.MinValue;
                subArr[j] = nums[i];
                subMax = Math.Max(subMax, subArr[j]);
                j++;

                while (j < k) {                    
                    //if (tempPtr > nums.Length - 1)
                    //    break;

                    subArr[j] = nums[tempPtr];
                    subMax = Math.Max(subMax, subArr[j]);
                    j++;
                    tempPtr++;
                }

                maxQ.Enqueue(subMax);
                i++;
                if ( (i + (k-1)) > nums.Length - 1)
                    break;
            }

            return maxQ.ToArray();

        }

    /*

        We will have N - k + 1 sliding windows
        */
        public int[] MaxSlidingWindow_Optimized(int[] nums, int k) {
            int n = nums.Length;

            if (n == 1)
                return nums;
            if (k == 1)
                return nums;
            if (n * k == 0)
                return new int[0];

            int[] output = new int[n - k + 1];
            int l = 0;   // Track of left & right Index for window
            int[] subArr = new int[k];

            for (int i = 0; i < output.Length; i++)
            {
                subArr = new int[k];
                // Create subArr for k elements
                Array.Copy(nums, l, subArr, 0, k );
                output[i] = GetMax(subArr);
                l++;
            }

            return output;

        }

        private int GetMax(int[] arr) {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
            }
            return max;
        }

    // Runtime: 456 ms, faster than 71.43% of C# online submissions for Sliding Window Maximum.
    // Memory Usage: 53 MB, less than 40.88% of C# online submissions for Sliding Window Maximum.
        public int[] MaxSlidingWindow_Optimized2(int[] nums, int k)  {
            int n = nums.Length;

            if (n == 1)
                return nums;
            if (k == 1)
                return nums;
            if (n * k == 0)
                return new int[0];

            // init deque and output
            int [] output = new int[n - k + 1];
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < n; i++) {
                
                // 1. remove element from head until first number within window
                if (list.Count > 0 && list.First.Value + k <= i ) {
                    list.RemoveFirst();
                }

                // 2. before inserting i into queue, remove from the tail of the
                // queue indices with smaller value then array[i]
                while(list.Count > 0 && nums[list.Last.Value] <= nums[i]) {
                    list.RemoveLast();
                }
                list.AddLast(i);
                
                // 3. set the max value in the window (always the top number in queue
                int index = i + 1 - k;
                if (index >= 0) {
                    output[index] = nums[list.First.Value];
                }
            }

            return output;
        }

    

     }
 }