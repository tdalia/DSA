using System;
using System.Collections;
using System.Collections.Generic;

/*****************************************************************************************************************
 *   AVL self-balancing binary search tree
 *   -------------------------------------
 *   This is a special kind of binary search tree that checks to see if it is still in balance after every
 *   add or delete.  If it isn't, a rebalancing operation occurs.  
 *   
 *   "In balance" means that the height of the tree on the right and left are within one level of
 *   each other.  
 * ***************************************************************************************************************/

namespace DataStru {
    class BinarySearchTreeAVL {
        internal Node Root;

        public BinarySearchTreeAVL() {
            Root = null;
        }

        public void Insert(int key) {
            Root = Insert(Root, key);

            return;
        }

        private Node Insert(Node parent, int key) {
            if (parent == null) {
                parent = new Node(key);
                return parent;
            }

            if (parent.Key > key) {
                parent.Left = Insert(parent.Left, key);
            } else {
                parent.Right = Insert(parent.Right, key);
            }

            return parent;
        }
    
        public bool Find(int key) {
            return Find(Root, key);
        }

        private bool Find(Node node, int key) {
            if (node == null)
                return false;
            
            if (node.Key == key)
                return true;
            
            if (node.Key > key) {
                if (node.Left == null)
                    return false;
                // node = node.Left;
                return Find(node.Left, key);
            } else {
                if (node.Right == null)
                    return false;
                // node = node.Right;
                return Find(node.Right, key);
            }
        }

        public void DFS_Traverse() {
            Console.Write("\nInOrder (L, N, R): ");
            InOrderTraverse(Root);
            Console.Write("\nPreOrder (N, L, R): ");
            PreOrderTraverse(Root);
            Console.Write("\nPostOrder (L, R, N): ");
            PostOrderTraverse(Root);
            Console.Write("\n");
        }

        // Left, Root, Right
        public void InOrderTraverse(Node node) {
            if (node == null)
                return;
            InOrderTraverse(node.Left);
            Console.Write(node.Key + ", ");
            InOrderTraverse(node.Right);
        }

        // Root, Left, Right
        public void PreOrderTraverse(Node node) {
            if (node == null)
                return;
            Console.Write(node.Key + ", ");
            PreOrderTraverse(node.Left);
            PreOrderTraverse(node.Right);
        }

        // Left, Right, Root
        public void PostOrderTraverse(Node node) {
            if (node == null)
                return;
            PostOrderTraverse(node.Left);
            PostOrderTraverse(node.Right);
            Console.Write(node.Key + ", ");
        }

        public void BFS_Traversal() {
            // Get height of tree
            int h = GetHeight(Root);
            Console.Write("\n Level Order (BFS) Height (" + h + "): ");
            List<int> orderList = new List<int>();
            // Go thru each level of the tree
            for (int i = 0; i <= h; i++)
            {
                // Print current level
                PrintLevelNode(Root, i, orderList);
            }
            foreach (var item in orderList)
            {
                Console.WriteLine(item);
            }
        }

        // Result = List inside List    https://leetcode.com/problems/binary-tree-level-order-traversal/submissions/
    // Runtime: 196 ms, faster than 10.78% of C# online submissions for Binary Tree Level Order Traversal.
    // Memory Usage: 39 MB, less than 99.94% of C# online submissions for Binary Tree Level Order Traversal.
        public IList<IList<int>> BFS_LevelTraversal2() {
            
            IList<IList<int>> list = new List<IList<int>>();
            if (Root == null)
                return (IList<IList<int>>)list;

            // Get height of tree
            int h = GetHeight(Root);
            Console.Write("\n Level Order (BFS) Height (" + h + "): ");

            // Go thru each level of the tree
            for (int i = 0; i <= h; i++)
            {
                List<int> orderList = new List<int>();
                // Print current level
                PrintLevelNode(Root, i, orderList);
                if (orderList.Count > 0)
                    list.Add(orderList);
            }
            foreach (var item in list)
            {
                List<int> orderList = (List<int>)item;
                foreach (var item2 in orderList)
                {
                    Console.WriteLine(item2);
                }    
            }

            return (IList<IList<int>>)list;
        }

        private int GetHeight(Node node) {
            int height = 0;
            if (node != null) {
                int l = GetHeight(node.Left);
                int r = GetHeight(node.Right);
                int m = l > r ? l : r;
                height = 1 + m;
            }
            return height;
        }

        // Print data of single level
        private void PrintLevelNode(Node node, int level, List<int> orderList) {
            if (node == null)
                return;
            
            if (level == 0) {
                Console.Write("  " + node.Key);
                orderList.Add(node.Key);
            }
            else if (level > 0) {
                PrintLevelNode(node.Left, level-1, orderList);
                PrintLevelNode(node.Right, level -1, orderList);
            }
        }

        public bool IsBST() {
            return CheckIsBST(Root);
            // return isValidBST(Root, Int64.MinValue, Int64.MaxValue);
        }

        private bool CheckIsBST(Node parent) {
            
            if (parent == null)
                return true;
            if (parent.Left != null) {
                if (parent.Key < parent.Left.Key)
                    return false;
                CheckIsBST(parent.Left);
            }
            if (parent.Right != null) {
                if (parent.Key > parent.Right.Key)
                    return false;
                CheckIsBST(parent.Right);
            }
            return true;
        }
/*
        private boolean isValidBST(TreeNode root, long min, long max) {
            if (root == null) {
                return true;
            }    
            
            if (root.val <= min || root.val >= max) {
                return false;
            }
            
            return isBST(root.left, min, root.val) && isBST(root.right, root.val, max);
        } */

        public List<int> noSibling() {
            List<int> list = new List<int>();

            CheckSiblings(Root, list);
            if (list.Count == 0)
                list.Add(-1);

            Console.Write("\nNo Siblings: ");
            foreach (var item in list)
            {
                Console.Write(item + "  ");
            }
            return list;
        }

        private void CheckSiblings(Node node, List<int> list) {
            if (node == null)
                return;
            
            if (node.Left != null && node.Right == null)
                list.Add(node.Left.Key);
            if (node.Right != null && node.Left == null)
                list.Add(node.Right.Key);

            CheckSiblings(node.Left, list);
            CheckSiblings(node.Right, list);
        }

        // Find the largest value in each level & return it
        // BFS Level/Pre Order traversal to iterate thru each level, find the max value & sore in a list
        // LeetCode - Medium - https://leetcode.com/problems/find-largest-value-in-each-tree-row/
        // G4G - Easy - https://practice.geeksforgeeks.org/problems/largest-value-in-each-level/1
        
        public List<int> LargestValueInLevel() {
            Node node = Root;
            List<int> maxValues = new List<int>();

            if (node == null) {
                return maxValues;
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            int qSize = queue.Count;
            while (qSize > 0) {
                int currLevelMax = Int32.MinValue;

                for (int i =0; i < qSize; i++) {
                    Node currNode = queue.Dequeue();

                    if (currLevelMax < currNode.Key) {
                        currLevelMax = currNode.Key;
                    }

                    if (currNode.Left != null) {
                        queue.Enqueue(currNode.Left);
                    }
                    if (currNode.Right != null) {
                        queue.Enqueue(currNode.Right);
                    }
                }
                maxValues.Add(currLevelMax);
                qSize = queue.Count;
            }

            Console.WriteLine("\nLargest Values in each Level: ");
            foreach (int i in maxValues) {
                Console.Write($"{i}  ");
            }
            Console.WriteLine();

            return maxValues;
        }


        internal class Node {
            public int Key;
            public Node Left;
            public Node Right;

            public Node(int key) {
                this.Key = key;
                Left = null;
                Right = null;
            }
        }
    }
}
