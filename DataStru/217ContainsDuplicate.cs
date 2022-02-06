using System;
using System.Collections.Generic;

/**
LeetCode - Data Structures
Easy/Medium - Contains Duplicates I, II, III
*/

namespace DataStru
{
    public class ContainsDuplicate217 {

        /**
        Contains Duplicates I - https://leetcode.com/problems/contains-duplicate/
        Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

        Example 1:
            Input: nums = [1,2,3,1]
            Output: true
        Example 2:
            Input: nums = [1,2,3,4]
            Output: false
        Example 3:
            Input: nums = [1,1,1,3,3,4,3,2,4,2]
            Output: true
        
        Constraints:
            1 <= nums.length <= 105
            -109 <= nums[i] <= 109
        */
        public bool ContainsDuplicate(int[] nums) {           
            bool contains = false;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach(int num in nums) {
                if (dict.ContainsKey(num)) 
                {
                    contains = true;
                    break;
                } 
                else 
                    dict.Add(num, 1);

            }

            dict = null;
            return contains;
        }

        /*
        Contains Duplicates II - https://leetcode.com/problems/contains-duplicate-ii/
        Given an integer array nums and an integer k, return true if there are two distinct 
        indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.

        Input: nums = [1,2,3,1], k = 3
        Output: true  for # 1 => i = 0, j=3 abs(i-j) == 3 <= k i.e. 3
        Input: nums = [1,0,1,1], k = 1
        Output: true   nums[0] == nums[2] abs(0-2) =2
                       nums[2] == nums[3] abs(2-3) = 1  & k == 1
        Input: nums = [1,2,3,1,2,3], k = 2
        Output: false   nums[0] == nums[3] (3-0) = 3 => false, k = 2
                        nums[1] == nums[4] (4-1) = 3 => false
                        nums[2] == nums[5] (5-2) = 3 => false

Runtime: 212 ms, faster than 95.39% of C# online submissions for Contains Duplicate II.
Memory Usage: 50.9 MB, less than 39.63% of C# online submissions for Contains Duplicate II.                        
        */
        public bool ContainsNearbyDuplicate(int[] nums, int k) {
            bool contains = false;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i=0; i < nums.Length; i++) {
                int num = nums[i];
                int j= -1;
                // Try to get the value
                if (dict.TryGetValue(num, out j)) {
                    if (Math.Abs(i-j) <= k) {
                        contains = true;
                        break;
                    } 
                    dict[num] = i;
                } else {
                    // Add to dictionary
                    dict.Add(num, i);
                }
            }

            dict = null;
            return contains;
        }

/**
220. Contains Duplicate III    MEDIUM  https://leetcode.com/problems/contains-duplicate-iii/
Given an integer array nums and two integers k and t, return true if there are two distinct 
indices i and j in the array such that abs(nums[i] - nums[j]) <= t and abs(i - j) <= k.

Input: nums = [1,2,3,1], k = 3, t = 0
Output: true    abs(num[0] - nums[3]) == 0  i.e. <= 0 (t) 
                abs(0-3) <= 3
Input: nums = [1,0,1,1], k = 1, t = 2
Output: true    nums[0] - nums[2] <= 2   (1-1) == 0 <= 2  BUT    abs(0-2) = 2 NOT <= 1 So Invalid
                nums[0] - nums[3] <= 2   (1-1) == 0 <= 2  abs(0-3) = 3 NOT <= 1 So Invalid
                nums[2] - nums[3] <= 2   (1-1) == 0 <= 2  abs(2-3) = 1 <= 1  VALID
Input: nums = [1,5,9,1,5,9], k = 2, t = 3
Output: false

Constraints:
    1 <= nums.length <= 2 * 104
    -231 <= nums[i] <= 231 - 1
    0 <= k <= 104
    0 <= t <= 231 - 1

Runtime: 112 ms, faster than 94.29% of C# online submissions for Contains Duplicate III.
Memory Usage: 44.5 MB, less than 60.00% of C# online submissions for Contains Duplicate III.
*/
        public bool ContainsNearbyAlmostDuplicateIII(int[] nums, int k, int t) {
            if (k == 0)
                return false;
            bool contains = false;

            Dictionary<long, long> dict = new Dictionary<long, long>();

            for (int i=0; i < nums.Length; i++) {
                int num = nums[i];
                int key = (int) Math.Floor((double)num / (t + 1));

                if ( (dict.ContainsKey(key) && Math.Abs(dict[key] - num) <= t) ||
                    (dict.ContainsKey(key - 1) && Math.Abs(dict[key - 1] - num) <= t) ||
                    (dict.ContainsKey(key + 1) && Math.Abs(dict[key + 1] - num) <= t) )
                    return true;
                
                if (i >= k)
                    dict.Remove((int)Math.Floor((double)nums[i - k] / (t + 1)));

                dict[key] = num;
            }

            dict = null;
            return contains;
        }

    }

}