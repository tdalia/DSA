using System;

namespace DataStru {
    class TestBST_AVL {

        public void BSTOperations() {
            BinarySearchTreeAVL bst = new BinarySearchTreeAVL();
            bst.Insert(10);
            bst.Insert(2);
            bst.Insert(15);
            bst.Insert(12);

            //Console.WriteLine("Found 10 ? " + bst.Find(10));
            //Console.WriteLine("Found 5 ? " + bst.Find(5));
            //Console.WriteLine("Found 2 ? " + bst.Find(2));
            //Console.WriteLine("Found 20 ? " + bst.Find(20));
            //Console.WriteLine("Found 15 ? " + bst.Find(15));

            // Depth First Traversal (InOrder, PreOrder, PostOrder)
            bst.DFS_Traverse();

            bst.Insert(5);
            bst.Insert(20);
            // Breadth First Traversal - Level Order Traversal
            bst.BFS_Traversal();
            bst.BFS_LevelTraversal2();

            // Check if Tree is a BST
            //Console.WriteLine("Is BST : " + bst.IsBST());

            // Print nodes without any siblings
            bst.noSibling();

            bst.LargestValueInLevel();

            Console.WriteLine("\n");
            bst = null;
            return;
        }
    }
}