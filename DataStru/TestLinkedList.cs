using System;
using System.Collections.Generic;

namespace DataStru {
    class TestLinkedList {

    /*
    707. Design Linked List     https://leetcode.com/problems/design-linked-list/
        Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
        A node in a singly linked list should have two attributes: val and next. val is the value of the current node, and next is a pointer/reference to the next node.
        If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. Assume all nodes in the linked list are 0-indexed.

        Implement the MyLinkedList class:

        MyLinkedList() Initializes the MyLinkedList object.
        int get(int index) Get the value of the indexth node in the linked list. If the index is invalid, return -1.
        void addAtHead(int val) Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
        void addAtTail(int val) Append a node of value val as the last element of the linked list.
        void addAtIndex(int index, int val) Add a node of value val before the indexth node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
        void deleteAtIndex(int index) Delete the indexth node in the linked list, if the index is valid.
    Runtime: 195 ms, faster than 12.94% of C# online submissions for Design Linked List.
    Memory Usage: 43.6 MB, less than 86.12% of C# online submissions for Design Linked List.
    */
        public void Operations() {
            MyLinkedList ll = new MyLinkedList();

            ll.AddAtHead(2);
            ll.DeleteAtIndex(1);
            Console.Write(Utils.printListNode(ll.GetHead()) + " Count: " + ll.GetCount() + "\n");

            ll.AddAtHead(2);
            ll.AddAtHead(7);
            Console.Write(Utils.printListNode(ll.GetHead()) + " Count: " + ll.GetCount() + "\n");
            ll.AddAtHead(3);
            ll.AddAtHead(2);
            ll.AddAtHead(5);
            Console.Write(Utils.printListNode(ll.GetHead()) + " Count: " + ll.GetCount() + "\n");

            ll.AddAtTail(5);
            Console.Write(Utils.printListNode(ll.GetHead()) + "\n");
            Console.WriteLine("Value at 5: " + ll.Get(5));
            ll.DeleteAtIndex(6);
            ll.DeleteAtIndex(4);

            /*
            ll.addAtHead(2);
            ll.deleteAtIndex(1);
            Console.Write(ll.printListNode() + "\n");

            ll.addAtHead(2);
            ll.addAtHead(7);
            ll.addAtHead(3);
            ll.addAtHead(2);
            ll.addAtHead(5);
            Console.Write(ll.printListNode() + "\n");
            ll.addAtTail(5);
            Console.Write(ll.printListNode() + "\n");
            Console.WriteLine("Value at 5: " + ll.get(5));
            ll.deleteAtIndex(6);
            ll.deleteAtIndex(4);
            */

            //ll.AddAtHead(12);
            Console.Write(Utils.printListNode(ll.GetHead()) + "\n");


            Console.WriteLine("\n");
            ll = null;
            return;
        }

    /*
    141. Linked List Cycle  https://leetcode.com/problems/linked-list-cycle/
    Return true if there is a cycle in the linked list. Otherwise, return false.


    Runtime: 96 ms, faster than 88.39% of C# online submissions for Linked List Cycle.
    Memory Usage: 42 MB, less than 70.54% of C# online submissions for Linked List Cycle.
    */
        public void HasCycle() {
            MyLinkedList ll = new MyLinkedList();

            ll.AddAtHead(5);
            ll.AddAtHead(4);
            ll.AddAtHead(3);
            ll.AddAtHead(2);
            ll.AddAtHead(1);
            Console.Write(Utils.printListNode(ll.GetHead()) + "\n");

            // ---------- HAS CYCLE 
            //ll.HasCycle(ll.GetHead());
            
            // ---------- REVERSE WHOLE LIST
            //ListNode reversed = ll.ReverseList_Iteratively(ll.GetHead());
            //Console.Write(Utils.printListNode(reversed) + "\n");

            // ---------- REVERSE k # OF NODES IN LIST
            ListNode reversedKNodes = ll.ReverseKGroup(ll.GetHead(), 2);
            Console.Write(Utils.printListNode(reversedKNodes) + "\n");

            Console.WriteLine("\n");
            ll = null;
            return;
        }

        public void TestStack() {
            MyStack stack = new MyStack(5);
            stack.Pop();
            stack.Push(4);
            stack.Push(5);
            //stack.printStack();
            stack.Pop();
            //stack.Peek();
        }

        public void TestBalanceParentheses() {
            string str = "{[()]}";
            Console.WriteLine($"Is {str} valid : " + IsValid(str));
        }

        public void TestTrapRainWater() {
            int[] height = {0,1,0,2,1,0,1,3,2,1,2,1};
            //height = new int[] {4,2,0,3,2,5};

            int trapped = Trap(height);
            int trapStack = Trap_Stack(height);
            Console.WriteLine("Water Trapped : " + trapped);
            Console.WriteLine("Water Trapped (Stack) : " + trapStack);
        }

        public void TestNumPairsDivisibleBy60() {
            int[] time = {30,20,150,100,40};
            time = new int[] {60,60,60};

            int pairs = NumPairsDivisibleBy60(time);
            //int trapStack = Trap_Stack(height);
            Console.WriteLine("Pairs found (Brute-force) : " + pairs);
            //Console.WriteLine("Water Trapped (Stack) : " + trapStack);
        }
 
    /*
    20. Valid Parentheses   https://leetcode.com/problems/valid-parentheses/
    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

    An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
Runtime: 72 ms, faster than 93.32% of C# online submissions for Valid Parentheses.
Memory Usage: 37.2 MB, less than 76.80% of C# online submissions for Valid Parentheses.
    */
        public bool IsValid(string s) {
            Stack<char> parenStack = new Stack<char>();
            for (int i= 0 ; i < s.Length; i++)
            {
                //Console.WriteLine(s[i]);
                // For an open parentheses, add to stack
                if (s[i] == '(' || s[i] == '{' || s[i] == '[')
                    parenStack.Push(s[i]);
                else {
                    if (parenStack.Count == 0)
                        return false;

                    char lastParen = parenStack.Peek();
                    if ( (lastParen == '(' && s[i] == ')') ||
                          (lastParen == '[' && s[i] == ']') ||
                          (lastParen == '{' && s[i] == '}') ) {
                        // Remove from stack
                        parenStack.Pop();
                    }
                    else 
                        return false;
                }
            }

            return parenStack.Count == 0 ? true : false;
        }

        /**
    42. Trapping Rain Water https://leetcode.com/problems/trapping-rain-water/
        Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
            Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
            Output: 6
            Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.
        Example 2:
            Input: height = [4,2,0,3,2,5]
            Output: 9
 
        Constraints:
            n == height.length
            1 <= n <= 2 * 104
            0 <= height[i] <= 105

    Runtime: 84 ms, faster than 89.61% of C# online submissions for Trapping Rain Water.
    Memory Usage: 39.6 MB, less than 67.46% of C# online submissions for Trapping Rain Water.
    Time : O(N) Space: O(1)
        */
        public int Trap(int[] height) {
            if (height.Length == 0)
                return 0;
            
            // Index for pointers
            int l = 0, r = height.Length - 1;
            // Pointers value pointing at left & right respectively
            int leftMax = height[l], rightMax = height[r];
            int res = 0;

            while (l < r) {
                // Move the pointer
                if (leftMax < rightMax) {
                    l++;
                    leftMax = (leftMax > height[l]) ? leftMax : height[l];
                    res += leftMax - height[l];
                } else {
                    // Since r is at last of array, decrement it
                    r--;
                    rightMax = (rightMax > height[r]) ? rightMax : height[r];
                    res += rightMax - height[r];
                }
            }

            return res;
        }

        // Trap Rain Water using Stack
        // Time : O(N) Space: O(N) - Space due to using Stack
        public int Trap_Stack(int[] height) {
            if (height.Length == 0)
                return 0;

            Stack<int> st = new Stack<int>();
            int curr = 0;
            int water = 0;

            while (curr < height.Length) {
                while(st.Count > 0 && height[curr] > height[st.Peek()]) {
                    int top = st.Pop();
                    if (st.Count == 0)
                        break;
                    
                    // Distance between towers
                    int distance = curr - st.Peek() - 1;
                    int fill = distance * (Math.Min(height[curr], height[st.Peek()]) - height[top]);
                    water += fill;
                }
                st.Push(curr++);
            }

            return water;
        }

        /*
    1010. Pairs of Songs With Total Durations Divisible by 60     https://leetcode.com/problems/pairs-of-songs-with-total-durations-divisible-by-60/  
        You are given a list of songs where the ith song has a duration of time[i] seconds.

        Return the number of pairs of songs for which their total duration in seconds is divisible by 60. 
        Formally, we want the number of indices i, j such that i < j with (time[i] + time[j]) % 60 == 0.

        Example 1:
            Input: time = [30,20,150,100,40]
            Output: 3
            Explanation: Three pairs have a total duration divisible by 60:
            (time[0] = 30, time[2] = 150): total duration 180
            (time[1] = 20, time[3] = 100): total duration 120
            (time[1] = 20, time[4] = 40): total duration 60
        Example 2:
            Input: time = [60,60,60]
            Output: 3
            Explanation: All three pairs have a total duration of 120, which is divisible by 60.

        Constraints:
            1 <= time.length <= 6 * 104
            1 <= time[i] <= 500
        */
        public int NumPairsDivisibleBy60(int[] time) {
            if (time.Length == 0)
                return 0;
            
            int pairs = 0;
            int[] map = new int[60];    // Stores the count in index as remainders
            
            foreach (int t in time) 
            {
                int rem = t % 60;
                if (rem == 0)
                    pairs += map[0];
                else 
                    pairs += map[60 - rem];

                map[rem]++;
            }

            map = null;
            return pairs;
        }

    }
}