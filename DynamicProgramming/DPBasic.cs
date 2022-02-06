using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class DPBasic
    {
        // Coin Change 
        /*
        We have coins of $ 1, 5, & 7, we need to make total of $18 from these 3 values of coins.
        Minimum how many coins we would need to nake $18.
        */
        public void ExecuteMinCoins() {
            int n = 18;
            int[] a = new int[] {7, 5, 1};
            int[] dp = new int[n+1];
            Array.Fill(dp, -1);
            dp[0] = 0;

            int ans = minCoins(n, a, dp);
            Console.WriteLine(ans);
            foreach (var item in dp)
            {
                Console.Write(item + " ");
            }
        }

        // n -> Total count ot make ($18)
        // a[] -> Values of coins we have (1, 5, 7)
        // dp[] -> Stores the count of coins reqd with combinations (size = 18+1)
        public int minCoins(int n, int[] a, int[] dp)
        {
            // Base case 
            if (n == 0)
                return 0;

            int ans = Int32.MaxValue;

            for (int i = 0; i < a.Length; i++) {
                if (n - a[i] >= 0) {
                    int subAns = 0;
                    int newNVal = n - a[i];
                    // Check if ans exists in dp
                    if (dp[newNVal] != -1) {
                        subAns = dp[newNVal];
                    } 
                    else {
                        subAns = minCoins(n - a[i], a, dp);                        
                    }

                    if (subAns != Int32.MaxValue && subAns + 1 < ans) {
                        ans = subAns + 1;
                    }
                }
            }

            // Save the ans (count) of n into dp[n]
            dp[n] = ans;
            return ans;
        }

        /*
        We have a bag that can hold max 10kgs. We have some items that weigh 
        certain weight & have respectives values worthful. Like 4 items weighing 
        {1, 3, 4, 6} & worth {20, 30, 10, 50}. 
        We need to find which items should we have in the bag that would be max worthful
        and also maintains it's 10kg weigh capacity, using Dynamic Programming (i.e. use of extra space
        to make the operation easy & reduce time complexity widely.)

        Since this is a Knapsack solution, we can either include an item or exclude it, but not take 
        it partly or include it multiple times.
        */
        public void Execute_01KnapsackProblem() {
            int maxCapacity = 10;
            int[] weights = { 1, 3, 4, 6};
            int[] values = {20, 30, 10, 50};

            MaxWorthBag(maxCapacity, weights, values);

        }

        /*
        EXECUTION of the function:
        Max Value = 100
        0	0	0	0	0	0	0	0	0	0	0
        0	20	20	20	20	20	20	20	20	20	20
        0	20	20	30	50	50	50	50	50	50	50
        0	20	20	30	50	50	50	50	60	60	60
        0	20	20	30	50	50	50	70	70	80	100
        The program '[23024] DynamicProgramming.dll' has exited with code 0 (0x0).
        */
        public void MaxWorthBag(int maxCapacity, int[] weights, int[] values) {

            int n = weights.Length + 1;
            int w = maxCapacity + 1;
            // Create a matrix - weights.length rows * maxCapacity cols
            int[,] matrix = new int[weights.Length + 1, maxCapacity + 1];

            // Populate base cases - the row 0 have no items, so all it's maxValue will be 0
            // Likewise, 0 weight capacity, can't carry anything, so make it 0
            for (int i = 0; i < w; i++) {
                matrix[0, i] = 0;
            }
            for (int i = 0; i < n; i++) {
                matrix[i, 0] = 0;
            }

            /*
            To calc the maxValue that we can obtain with item i, we 1st compare the 
            weight of item i with knalsnap's weight capacity (j). If item i weighs less than j, 
            then only we should add it if the maxValue turns greater than previous i of the same col. 
            */
            // If u r on i weight & j is your maxWeight, then how much can you carry
            // that value will be calculated & stored in each cell. 
            for(int item = 1; item <= weights.Length; item++) {
                for (int capacity = 1; capacity <= maxCapacity; capacity++) {
                    // Get the value of previous item of same capacity
                    int maxValueWithoutCurr = matrix[item-1, capacity];
                    int maxValueWithCurr = 0;

                    // Get the weight value of item index
                    int wtOfCurr = weights[item-1];
                    
                    // If capacity is greater than weight, then only we can add it
                    if (capacity >= wtOfCurr) {
                        // Get the value of current item
                        maxValueWithCurr = values[item - 1];

                        int remainingCapcaity = capacity - wtOfCurr; // remainingCapacity must be at least 0
                        // Add the maximum value obtainable with the remaining capacity
                        maxValueWithCurr += matrix[item - 1, remainingCapcaity];
                    }

                    // Pick one with max value & set that
                    matrix[item, capacity] = Math.Max(maxValueWithoutCurr, maxValueWithCurr);
                }
            }

            Console.WriteLine($"Max Value = {matrix[weights.Length, maxCapacity]} ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }
            return;
        }

        /*
        Given a list containing future price predictions of two different stocks for the next n–days, 
        find the maximum profit earned by selling the stocks with a constraint that the second stock can be sold, 
        only if no transaction happened on the previous day for any of the stock.
        Shown below 3 versions of this solution - Recursion, DP, & Efficient DP.
        Source: https://www.techiedelight.com/find-maximum-profit-that-can-be-earned-by-selling-stocks/
        */
        public void ExecuteMaxProfit() {

            int[] stockX = {5, 3, 4, 6, 3};
            int[] stockY = {8, 4, 3, 5, 10};
            int nDays = stockX.Length - 1;
            int maxProfit = 0;

            //maxProfit = findMaxProfitForNDays_Recursion(stockX, stockY, nDays);
            //maxProfit = findMaxProfitForNDays_DP(stockX, stockY);
            maxProfit = findMaxProfitForNDays_DP_Efficient(stockX, stockY);

            Console.WriteLine($"The Max Profit earned is {maxProfit}");

        }

        /*
        Time Complexity of Recursion solution is exponential, b'coz for every n, the code calls
        for n-1 & n-2 that many times. So the code is doing lot of reduntant code.
        */
        public int findMaxProfitForNDays_Recursion(int[] stockX, int[] stockY, int nDays) {
            
            // base case 
            if (nDays < 0)
                return 0;
            
            int profit = 0;
            // Sell the 1st stock for n'th day & recur n-1
            profit = Math.Max(profit, stockX[nDays] + findMaxProfitForNDays_Recursion(stockX, stockY, nDays - 1));

            // Sell the 2nd stock on n'th day & recur for n-2 b'coz no transaction can be made on n-1 day
            profit = Math.Max(profit, stockY[nDays] + findMaxProfitForNDays_Recursion(stockX, stockY, nDays - 2));

            return profit;
        }

        /*
        Time Complexity of above problem, can be solved by using dynamic programming DP.
        Idea is to cache/store each time the result of T(i) subproblem is solved. If we 
        ask to compute it again, it will chekc if it has a value, it won't compute & retrieve
        the stored value for that computation. Logic:
        1. Sell the first stock on the i'th day, and add the profit to the maximum earnings till the (i-1)'th day.
        2. Sell the second stock on the i'th day, and add the profit to the maximum earnings till the (i-2)'th day.

        Time Complexity : O(n)  Space: O(N) - n = number of days
        Results of T[]:
        0	8	11	15	21	25	
        The Max Profit earned is 25

        */
        public int findMaxProfitForNDays_DP(int[] stockX, int[] stockY) {

            // base case 
            if (stockX.Length == 0)
                return 0;

            int n = stockX.Length;

            // Create an [] to store solutions to subproblems
            // T stores max earnings till day 'i
            int[] T = new int[n + 1];

            // Base Cases
            T[0] = 0;
            T[1] = Math.Max(stockX[0], stockY[0]);

            // Fill the T[] in a bottom-up manner - going top to bottom
            for (int i = 2; i <= n; i++) {
                T[i] = Math.Max(stockX[i - 1] + T[i - 1], stockY[i - 1] + T[i - 2]);
            }

            for (int j = 0; j <= n; j++)
            {
                Console.Write(T[j] + "\t");
            }
            // T[n] stores the max
            return T[n];
        }

        /*
        In the above DP solution, the T[n] takes n # of space. This can be reduced to O(1).
        Since T[n] is calculated based on values of T[n-1] & T[n-2], we can store just these 2 values
        int variables, & can compute in O(1) Space complexity.
        
        */
        public int findMaxProfitForNDays_DP_Efficient(int[] stockX, int[] stockY) {

            // Base case
            if (stockX.Length < 0)
                return 0;

            int n = stockX.Length;
            int prevOfPrev = 0;
            int prev = Math.Max(stockX[0], stockY[0]);

            // Find max profit in bottom-up manner - top to bottom
            for (int i = 1; i < n; i++) {
                // Find max for current i 
                int curr = Math.Max(stockX[i] + prev, stockY[i] + prevOfPrev);
                // Swap 
                prevOfPrev = prev;
                prev = curr;
            }

            //'prev' stores max profit gained till n'th day
            return prev;
        }

        /*
        Longest Alternating Subarray Problem
        Given an array containing positive and negative elements, find a subarray with 
        alternating positive and negative elements, and in which the subarray is as long as possible.
        { 1, -2, 6, 4, -3, 2, -4, -3 }. The longest alternating subarray is { 4, -3, 2, -4 }
        */
        public void ExecuteLongestSubArray() {
            int[] arr = { 1, -2, 6, 4, -3, 2, -4, -3 };
            findLongestSubArray(arr);
        }

        public void findLongestSubArray(int[] arr) {
            // Base
            if (arr == null || arr.Length == 0)
                return;

            // Stores longest length found so far
            int maxLen = 1;
            int endIndex = 0;   // Stores ending Index of subArr found so far
            int currLen = 1;    // Stores length of alternating subArr at curr position

            // Starting from 1, traverse all elements
            for (int i =1; i < arr.Length; i++) {

                // Find if the sign of previous & current element is different
                // -2 * 1 == -2, -2 * -1 == 2 => '-' * '-' will result positive only '+' * '-' will be negative 
                if (arr[i] * arr[i - 1] < 0) {
                    // Increment the current length
                    currLen++;

                    // update
                    if (currLen > maxLen) {
                        maxLen = currLen;
                        endIndex = i;
                    } 
                } else {
                    // reset currLen to 1
                    currLen = 1;                    
                }
            }

            int start = (endIndex - maxLen + 1);
            int end = endIndex + 1;

            Console.Write("\n [");
            for (int k = start; k < end; k++) {
                Console.Write(arr[k] + ", ");
            }
            Console.WriteLine("]");

            return;
        }

        /*
         Fibonacci’s sequence is characterized by the fact that every number after 
         the first two is the sum of the two preceding ones. For example, consider 
         the following series:

        0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, … and so on.
        F(n)   = F(n - 1) + F(n - 2) + + F(n - 3)+ F(n - 4)......
        Fib(5) = Fib(4) + Fib(3) + Fib(2) + Fib(1) + Fib(0)
        */
        public void ExecuteFibonacci() {
            int n = 50;
            int result = Fibonacci(n);
            Console.WriteLine($"Fibonacci of {n} is {result}");
        }

        public int Fibonacci(int n) {

            if (n <= 1)
                return n;
            
            int prevFib = 0, currFib = 1;

            for (int i = 0; i < n-1; i++) {
                int newFib = prevFib + currFib;
                Console.Write(newFib + "\t");
                // Swap
                prevFib = currFib;
                currFib = newFib;
            }

            return currFib;
        }

        public void ExeNumberOfPaths() {
            int a = 3, b = 4;
            int result = NumberOfPath(a, b);
            Console.WriteLine($"Possible number of paths from (0, 0) cell to the last ({a}, {b}) cell is {result}");

        }

        public int NumberOfPath(int a, int b)
        {
            //Your code here
            int[,] dp = new int [a, b];
            // Fill 0'th row values as 1 - there is only 1 position to go from 1st row cell to itself
            for (int i = 0; i< a; i++) {
                dp[i, 0] = 1;
            }
            // Fill 0'th col values as 1 - there is only 1 position to go from 1st col cell to itself
            for (int j = 0; j < b; j++) {
                dp[0, j] = 1;
            }
            
            // Fill 
            for (int i = 1; i < a; i++) {
                for (int j = 1; j < b; j++) {
                    int countPrevRowSameCol = dp[i-1, j];
                    int countSameRowPrevCol = dp[i, j-1];
                    
                    dp[i, j] = countPrevRowSameCol + countSameRowPrevCol;
                    // dp[i-1, j] + dp[i, j-1];
                }
            }
            
            Console.WriteLine($"Possible # of Paths = {dp[a-1, b-1]} ");
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    Console.Write(dp[i,j] + "\t");
                }
                Console.WriteLine();
            }

            // Return the last cell value 
            return dp[a-1, b-1];
        }

        /*
        You are climbing a stair case and it takes A steps to reach to the top.
        Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
        Source: https://www.interviewbit.com/problems/stairs/
        */
        public void ExeClimbStairs() {
            int A = 1;
            int res = climbStairs(A);
            Console.WriteLine("resilt = " + res);
        }

        public int climbStairs(int A) {
            if (A == 0)
                return 0;
            if (A == 1)
                return 1;
            if (A == 2)
                return 2;
            if (A == 3)
                return 3;

            // Since I want only prev 2 results, no need of array & use only 2 vars
            // Optimize Space with O(1)
            int prevOfPrev = 2;
            int prev = 3;
            for (int i = 4; i <= A; i++) {
                int curr = prev + prevOfPrev;
                // Swap
                prevOfPrev = prev;
                prev = curr;
            }

            return prev;

            /*
            // DP Solution using [A] => Space: O(N)

            int[] dp = new int[A+1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 3;

            for (int i = 4; i <= A; i++) {
                dp[i] = dp[i-1] + dp[i-2];
            }

            return dp[A];
            */
        }

        public void  ExeFlipArray() {
            int[] arr = {15, 10, 6};
            arr = new int[] { 10, 22, 9, 33, 21, 50, 41, 60 };
            
            List<int> A = new List<int>(arr);
            
            int result = FlipArray(A);
            Console.WriteLine("Result  = " + result);
        }

        public int FlipArray(List<int> A) {
            int sum = 0;
            int n = A.Count;

            // Get the sum of all elements
            for (int i = 0; i < n; i++)
                sum += A[i];

            // Create an array of half the sum size & assign Int.MaxValue to each element
            sum = sum / 2;
            int[] dp = new int[sum + 1];
            Array.Fill(dp, Int32.MaxValue);
            dp[0] = 0;

            // Iterate thru all elements
            for (int i = 0; i < n; i++) {
                // Starting from sum, iterate till the value of A[i]
                for (int j = sum; j >= A[i]; j--) {
                    int ind = j - A[i];
                    if (dp[ind] != Int32.MaxValue) {
                        // Get the min val of dp[j] & (dp[ind] + 1) & save it in dp[j]
                        dp[j] = Math.Min(dp[j], dp[ind] + 1);
                    }
                }
            }

            // Print dp[]
            for (int i = 0; i < dp.Length; i++) {
                Console.Write(dp[i] + "\t");
            }

            for (int i = sum; i >= 0; i--) {
                if (dp[i] != Int32.MaxValue) {
                    return dp[i];
                }
            }

            return dp[0];  
        }
    }
}
