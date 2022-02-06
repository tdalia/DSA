using System;
using System.Collections.Generic;

namespace DataStru {

    /*
    class MyLinkedList {
        private NodeLeet head ;
        private NodeLeet tail ;
        private int size ;

        public MyLinkedList() {
            this.head = null ;
            this.tail = null ;
            this.size = 0 ;
        }

        public int get(int index) {
            if (head == null){
                return -1 ;
            }

            if (index == 0){
                return head.val ;
            }

            NodeLeet temp = head ;
            for (int i = 0 ; temp != null && i<index ; i++){
                temp = temp.next ;
            }

            if (temp == null){
                return -1 ;
            }

            return temp.val ;
        }

        public void addAtHead(int val) {
            NodeLeet node = new NodeLeet(val);

            if (head == null){
                head = node ;
                tail = node ;
                size++ ;
                return;
            }

            node.next = head ;
            head = node ;
            size++ ;
        }

        public void addAtTail(int val) {
            NodeLeet node = new NodeLeet(val);

            if (tail == null){
                addAtHead(val);
                return;
            }

            tail.next = node ;
            tail = node ;
            size++ ;
        }

        public void addAtIndex(int index, int val) {
            if (index == 0){
                addAtHead(val);
                return;
            }
            if (index == size){
                addAtTail(val);
                return;
            }

            if (index > size || index < 0){
                return;
            }

            NodeLeet temp = head ;
            NodeLeet node = new NodeLeet(val);

            for (int i = 1 ; i < index ;i++){
                temp = temp.next ;
            }

            node.next = temp.next ;
            temp.next = node ;
            size++ ;
        }

        public void deleteAtIndex(int index) {
            if (index >= size || index < 0){
                return;
            }
            
            if (index == 0){
                head = head.next ;
                size-- ;
                return;
            }
            
            
            NodeLeet temp = head ;

            for (int i = 1 ; i < index ;i++){
                temp = temp.next ;
            }
            
            if (temp.next == tail){
                tail = temp ;
            }
            temp.next = temp.next.next ;
            size-- ;
            
        }

        public string printListNode() {
            NodeLeet node = head;
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

        class NodeLeet{
            public int val ;
            public NodeLeet next ;

            public NodeLeet(){
                this.val = 0 ;
                this.next = null ;
            }

            public NodeLeet(int val){
                this.val = val ;
            }
        }


    }
    */

    class MyLinkedList {
        private ListNode head;
        private int count;

        public MyLinkedList() {
            head = null;
            count = 0;
        }
        
        public int Get(int index) {
            int val = -1;
            ListNode node = head;
            int i = 0;
            while (node != null)
            {
                if (i == index) {
                    val = node.val;
                    break;
                }
                else {
                    i++;
                    node = node.next;
                }
            }
            return val;
        }
        
        public void AddAtHead(int val) {
            if (head == null) {
                head = new ListNode(val);
            }
            else {
                ListNode newNode = new ListNode(val, head);
                head = newNode;
            }

            count++;
            return;
        }
        
        public void AddAtTail(int val) {
            if (count == 0) {
                AddAtHead(val);
                return;
            }

            // Navigate to last
            ListNode node = GetNodeAt(count - 1);
            if (node != null) {
                // Create a new node
                ListNode newNode = new ListNode(val);
                // Assign the newNode to end node's next reference
                node.next = newNode;
                
                count++;
            }
            return;
        }
        
        public void AddAtIndex(int index, int val) {
            // Retrieve previous node of index
            ListNode node;
            if (index == 0) {
                AddAtHead(val);
                return;
            } else if (index == count) {
                AddAtTail(val);
                return;
            }
            else {
                node = GetNodeAt(index-1);
                if (node != null) {
                    // Create a new node
                    ListNode newNode = new ListNode(val, node.next);
                    node.next = newNode;
                    count++;
                }
            }
            return;
        }
        
        public void DeleteAtIndex(int index) {
            if (head == null || index >= count || index < 0)
                return;

            ListNode node;
            if (index == 0) {
                node = head;
                head = node.next;
                count--;
            } else {
                // Retrieve the previous node
                node = GetNodeAt(index -1);
                if (node != null) {
                    ListNode actualNode = node.next;
                    if (actualNode == null)
                        node.next = actualNode;
                    else 
                        node.next = actualNode.next;
                    actualNode = null;
                    count--;
                }
            }

            node = null;
            return;
        }

        private ListNode GetNodeAt(int index) {
            ListNode node = head;
            ListNode retNode = null;
            int i = 0;
            while (node != null)
            {
                if (i == index) {
                    retNode = node;
                    break;
                }
                else {
                    i++;
                    node = node.next;
                }
            }
            node = null;
            return retNode;
        }

        /*
    Check if the LinkedList has a cycle. Return true/false

        This can be achieved by using HashSet<ListNode> & storing all visited nodes in the set.
        That will take extra Space resulting in O(N). Using Floyds Tortoise And Hare algorithm
        we can achieve the same with O(1) Space complexity
        */
        public bool HasCycle(ListNode head) {
            // Floyds Tortoise And Hare algorithm
            ListNode fastMover = head;
            ListNode slowMover = head;
            
            while (fastMover != null && fastMover.next != null) {
                slowMover = slowMover.next;
                fastMover = fastMover.next.next;
                if (slowMover == fastMover)
                    return true;
            }
            return false;
        }

        /*
    142. Linked List Cycle II   https://leetcode.com/problems/linked-list-cycle-ii/
        Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.

        */
    /*
        Check if the LinkedList has a cycle. Return the node where the cycle begins
    */
        public ListNode DetectCycle(ListNode head) {
            if (head == null)
                return null;

    // Space complexity: O(1) using Floyd's Tortoise & Hare Algo
        // Runtime: 84 ms, faster than 91.47% of C# online submissions for Linked List Cycle II.
        // Memory Usage: 39.4 MB, less than 63.53% of C# online submissions for Linked List Cycle II.

            // If there is a cycle, the fast/slow pointers will intersect at some
            // node. Otherwise, there is no cycle, so we cannot find an entrance to
            // a cycle.
            ListNode intersect = GetIntersectNode(head);
            if (intersect == null) {
                return null;
            }

            // Now, we have an intersect node, so there is a cycle.
            // To find the entrance to the cycle, we have two pointers traverse at
            // the same speed -- one from the front of the list, and the other from
            // the point of intersection.
            ListNode ptr1 = head;
            ListNode ptr2 = intersect;
            while(ptr1 != ptr2) {
                ptr1 = ptr1.next;
                ptr2 = ptr2.next;
            }

            return ptr1;
            /*
        //         Space Complexity: O(N)
        // Runtime: 92 ms, faster than 58.97% of C# online submissions for Linked List Cycle II.
        // Memory Usage: 40.5 MB, less than 18.82% of C# online submissions for Linked List Cycle II.
            
            HashSet<ListNode> visited = new HashSet<ListNode>();

            ListNode node = head;
            while (node != null) {
                if (visited.Contains(node))
                    return node;
                else {
                    visited.Add(node);
                }
                node = node.next;
            }
            return null;
            */
        }

        private ListNode GetIntersectNode(ListNode head) {
            // Floyds Tortoise And Hare algorithm
            ListNode fastMover = head;
            ListNode slowMover = head;
            
            while (fastMover != null && fastMover.next != null) {
                slowMover = slowMover.next;
                fastMover = fastMover.next.next;
                if (slowMover == fastMover)
                    return slowMover;
            }
            return null;
        }

        /**
    206. Reverse Linked List    https://leetcode.com/problems/reverse-linked-list/
        Given the head of a singly linked list, reverse the list, and return the reversed list.

    Runtime: 88 ms, faster than 47.32% of C# online submissions for Reverse Linked List.
    Memory Usage: 38.3 MB, less than 28.10% of C# online submissions for Reverse Linked List.
        */
        public ListNode ReverseList_Iteratively(ListNode head) {
            if (head == null)
                return null;
            // Only 1 element i.e head
            if (head.next == null)
                return head;

            ListNode node = head;
            ListNode reversedHead = null;
            while(node != null) {
                if (reversedHead == null) {
                    reversedHead = new ListNode(node.val);
                } else {
                    ListNode newNode = new ListNode(node.val, reversedHead);
                    reversedHead = newNode;
                }

                node = node.next;
            }
            return reversedHead;
        }

    // Reverse k nodes of the given linked list.
        public ListNode ReverseKGroup(ListNode head, int k) {
            ListNode kTail = null;
            ListNode ptr = head;

            ListNode newHead = null;    // Head of modified LL

            // Until we have not reached the end of LL
            while (ptr != null) {
                int count = 0;

                // Start from head
                ptr = head;

                // Find the head of the next k nodes
                while(count < k && ptr != null) {
                    ptr = ptr.next;
                    count++;
                }

                // Have k nodes to reverse
                if (count == k) {
                    ListNode revHead = ReverseLinkedList(head, k);

                    if (newHead == null)
                        newHead = revHead;
                    
                    if (kTail != null)
                        kTail.next = revHead;
                    
                    kTail = head;
                    head = ptr;
                }
            }

            if (kTail != null)
                kTail.next = head;

            return newHead == null ? head : newHead;
        }

        public ListNode ReverseLinkedList(ListNode head, int k) {
            ListNode newHead = null;
            ListNode ptr = head;

            while (k > 0) {
                // Keep track of next node of original list
                ListNode next = ptr.next;

                // Insert ptr at begining of reversed list
                ptr.next = head;
                newHead = ptr;

                // Move to next node
                ptr = next;

                k--;
            }
            // Return the head of reversed list
            return newHead;
        }


        public ListNode GetHead() {
            return head;
        }

        public int GetCount() {
            return count;
        }
    }
    
}
