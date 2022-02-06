using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStru {
     class MyGraph {
         private int V;
         LinkedList<int>[] adjList;

         public MyGraph(int vertices) {
             V = vertices;
             adjList = new LinkedList<int>[V];

             for (int i = 0; i < vertices; i++)
             {
                 adjList[i] = new LinkedList<int>();
             }
         }

         public void AddEdge(int v, int w) {
             if (v > V || w > V)
                return;
            
            adjList[v].AddLast(w);
            //adjList[w].AddLast(v);
         }

        public void BFS_MyGraph(int start) {
            if (adjList == null || (adjList != null && adjList.Length == 0))
                return;

            bool[] visited = new bool[V];
            // for (int i=0; i < V; i++)
            //     visited[i] = false;

            // Create a Queue for BFS
            LinkedList<int> queue = new LinkedList<int>();
            visited[start] = true;
            queue.AddLast(start);

            while (queue.Any()) {
                // Get the 1st element from the queue & remove it from queue
                start = queue.First();
                Console.Write(start + "  ");
                queue.RemoveFirst();

                // Get all adjecent vertices of the 1st element
                LinkedList<int> list = adjList[start];

                foreach (int item in list)
                {
                    if (visited[item] == false) {
                        visited[item] = true;
                        queue.AddLast(item);
                    }
                }
            }
        }

        // Depth First Traversal
        public void DFS_MyGraph(int start) {
            if (adjList == null || (adjList != null && adjList.Length == 0))
                return;

            // Start from root
            
            bool[] visited = new bool[V];

            // For unconnected Graph, we need to make sure that all vertices are visited
            // Hence, the recursive call needs to be in the for loop
            // for (int i = 0; i < V; i++) {
            //     if (! visited[i])
            //         DFSUtil(start, visited);
            // }

            // For connected Graph, this call is sufficient
            DFSUtil(start, visited);
        }

        private void DFSUtil(int index, bool[] visited) {
            visited[index] = true;
            Console.Write(index + "  ");

            LinkedList<int> list = adjList[index];

            foreach (int item in list)
            {
                if (! visited[item]) {
                    DFSUtil(item, visited);
                }
            }
        }

        // Topological Sort
        public void TopoSort_MyGraph(int start) {
            if (adjList == null || (adjList != null && adjList.Length == 0))
                return;

            // Start from root
            
            bool[] visited = new bool[V];
            Stack<int> stack = new Stack<int>();

            // For unconnected Graph, we need to make sure that all vertices are visited
            // Hence, the recursive call needs to be in the for loop
            for (int i = 0; i < V; i++) {
                if (! visited[i])
                    TopoUtil(i, visited, stack);
            }

            Console.Write("\n Contents of Stack: ");
            // Print contents of Stack
            foreach (var item in stack)
            {
                Console.Write(item + "  ");
            }
            List<int> l = stack.ToList<int>();

        }

        private void TopoUtil(int index, bool[] visited, Stack<int> stack) {
            visited[index] = true;

            LinkedList<int> list = adjList[index];

            foreach (int item in list)
            {
                if (! visited[item]) {
                    TopoUtil(item, visited, stack);
                }
            }
            // Push the index to stack
            stack.Push(index);
        }

        

        // Clone/Copy the passed adj to a new list of list
        public List<List<int>> PrintGraph(int v, List<List<int>> adj) {
            if (adj == null || (adj != null && adj.Count == 0))
                return new List<List<int>>();

            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < adj.Count; i++) 
            {
                List<int> subList = new List<int>();
                subList.Add(i);
                
                List<int> aList = adj[i];
                for (int j = 0; j < aList.Count ; j++)
                {
                    subList.Add(aList[j]);
                }
                list.Add(subList);
            }
            return list;
        }

        // Function to return Breadth First Traversal of given graph.
        public List<int> bfsOfGraph(int V, List<List<int>> adj) {
            List<int> bfs = new List<int>();
            int index = 0;

            if (adj == null || (adj != null && adj.Count == 0))
                return bfs;

            bool[] visited = new bool[V];
            // for (int i=0; i < V; i++)
            //     visited[i] = false;

            LinkedList<int> queue = new LinkedList<int>();
            queue.AddLast(index);
            visited[index] = true;

            while(queue.Any()) {
                // Get the 1st element from the queue & remove it from queue
                index = queue.First();
                Console.Write(index + "  ");
                // Store in list to return
                bfs.Add(index);
                queue.RemoveFirst();

                // Get all adjecent vertices of the 1st element
                List<int> list = adj[index];
                foreach (int item in list)
                {
                    if (! visited[item]) {
                        visited[item] = true;
                        queue.AddLast(item);                        
                    }
                }

            }          

            return bfs;
        }


        /**

        Given a connected undirected graph. Perform a Depth First Traversal of the graph.
        Note: Use recursive approach to find the DFS traversal of the graph starting from the 0th vertex from left to right according to the graph..
        */
        public List<int> dfsOfGraph(int V, List<List<int>> adj) {

            List<int> dfs = new List<int>();

            int index = 0;

            if (adj == null || (adj != null && adj.Count == 0))
                return dfs;
            
            bool[] visited = new bool[V];

            dfsOfGraphUtil(index, visited, dfs, adj);

            return dfs;
        }

        private void dfsOfGraphUtil(int index, bool[] visited, List<int> dfs, List<List<int>> adj) 
        {
            visited[index] = true;
            Console.Write(index + "  ");
            dfs.Add(index);

            // Get al lthe verticies 
            List<int> list = adj[index];
            foreach (var item in list)
            { 
                if (! visited[item]) {
                    dfsOfGraphUtil(item, visited, dfs, adj);
                }
            }
        }

        public List<int> topoSort(int V, List<List<int>> adj)
        {
            //code here
            List<int> dfs = new List<int>();

            int index = 0;

            if (adj == null || (adj != null && adj.Count == 0) || V < 2)
                return dfs;
                
            bool[] visited = new bool[V];
            Stack<int> stack = new Stack<int>();
            
            // LinkedList<int> queue = new LinkedList<int>();
            // for (int i=0; i < V; i++) {
            //     queue.AddLast(i);
            // }
            
            for (int i = 0; i < V; i++) {
                //index = queue.First();
                //queue.RemoveFirst();
                
                if (! visited[i]) {
                    bool cycle = topoSortUtil(i, visited, stack, adj);
                    if (cycle)
                        break;
                }
            }
            
            return stack.ToList<int>();
        }
        
        private bool topoSortUtil(int index, bool[] visited, Stack<int> stack, List<List<int>> adj) {
            if (! visited[index]) {
                visited[index] = true;
                
                List<int> edges = adj[index];
                
                foreach(int item in edges) {
                    if (! visited[item])
                        topoSortUtil(index, visited, stack, adj);
                }
                
                stack.Push(index);
            } else {
                return true;
            }
            
            return false;
        }

     }
}