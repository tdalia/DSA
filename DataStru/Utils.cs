using System;

namespace DataStru {
    class Utils {
        public static string printArray<T>(T[] array)
        {
            string result = String.Format("[{0}]", string.Join(", ", array));

            return result;
        }

        public static string printMatrix<T>(T[][] matrix) {
            string result = "[";

            for(int i = 0; i < matrix.Length; i++) {
                result += "\n{ ";
                for (int j = 0; j < matrix[i].Length; j++) {
                    result += matrix[i][j];
                    if (j < matrix[i].Length - 1)
                        result += ", ";
                }
                result += " }";
            }

            result += "\n]";
            return result;
        }

        public static string printListNode(ListNode node) {
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

/*
        public static string printMyListNode(MyListNode node) {
            string result = "{ ";

            while(node != null) {
                result += node.val;
                node = node.next;
                if (node != null)
                    result += ", ";
            }
            result += " }";
            return result;
        } */
    }
}