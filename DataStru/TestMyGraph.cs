using System;
using System.Collections.Generic;

namespace DataStru {
     class TestMyGraph 
     {
         public void Operations() {
             MyGraph graph = new MyGraph(4);
             graph.AddEdge(0, 1);
             graph.AddEdge(0, 2);
             graph.AddEdge(1, 2);
             graph.AddEdge(2, 0);
             //graph.AddEdge(1, 4);
             graph.AddEdge(2, 3);
             graph.AddEdge(3, 3);

        
            int v = 4;
             List<List<int>> list = new List<List<int>>();
             // [0]
             List<int> sub = new List<int>();
             sub.Add(1); sub.Add(2);
             list.Add(sub);
             //[1]
             sub = new List<int>();
             sub.Add(2); 
             list.Add(sub);
             // [2]
             sub = new List<int>();
             sub.Add(0); sub.Add(3);
             list.Add(sub);
             // [3]
             sub = new List<int>();
             sub.Add(3);
             list.Add(sub);
        
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("\nOrg Adjacency list of vertex " + i);
                Console.Write("head");
                
                foreach (var item in list[i])
                {
                    Console.Write(" -> " + item);
                }
                Console.WriteLine();
            }
        
        /**
        // Clone MyGraph to list of list
            List<List<int>> newList = graph.PrintGraph(5, list);
            for (int i = 0; i < newList.Count; i++)
            {
                Console.WriteLine("\nCloned Adjacency list of vertex " + i);
                Console.Write("head");
                
                foreach (var item in newList[i])
                {
                    Console.Write(" -> " + item);
                }
                Console.WriteLine();
            } 
        */

            // List<int> bfs = graph.bfsOfGraph(list.Count, list);
            // foreach (var item in bfs)
            // {
            //     Console.Write(" " + item);
            // }

            /*
            // BFS of MyGraph
            Console.WriteLine("\nBreadth First Traversal of MyGraph  ");
            graph.BFS_MyGraph(0);

            Console.WriteLine("\n Depth First Traversal (DFS) of MyGraph  ");
            graph.DFS_MyGraph(0);

            Console.WriteLine("\nBreadth First Traversal of List of List  ");
            graph.bfsOfGraph(list.Count, list);
            
            Console.WriteLine("\n Depth First Traversal (DFS) of List of List  ");
            graph.dfsOfGraph(list.Count, list);
            */

            graph = new MyGraph(6);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            graph.TopoSort_MyGraph(0);

            Console.WriteLine("\n");
            graph = null;
            return;
         }
     }
}
