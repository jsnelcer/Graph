namespace GraphDemo
{
    using System;
    using Graph.Model;
    using Graph.Algorithms;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            //                      0
            //              ----------------
            //              1               2
            //      ----------------
            //      3               4
            //                  ---------
            //                  5   6   7       (8)

            Graph<int> myGraph = new Graph<int>();

            for (int i = 0; i <= 8; i++)
            {
                myGraph.AddVertex(i);
            }

            myGraph.AddUndirectedEdge(0, 1);
            myGraph.AddUndirectedEdge(0, 2);

            myGraph.AddUndirectedEdge(1, 3);
            myGraph.AddUndirectedEdge(1, 4);

            myGraph.AddUndirectedEdge(4, 5);
            myGraph.AddUndirectedEdge(4, 6);
            myGraph.AddUndirectedEdge(4, 7);

            Console.WriteLine("Node => Neighbors");

            foreach (var vertex in myGraph.Vertices)
            {
                Console.Write("{0} => ", vertex.Value);
                foreach (var neighbour in vertex.Neighbours)
                {
                    Console.Write("{0} ", neighbour.Value);
                }
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.WriteLine("All Path from one node");
            List<VertexList<int>> allpath = myGraph.GetAllPath(myGraph[1]);

            foreach (var item in allpath)
            {
                foreach (var vertex_x in item)
                {
                    Console.Write(vertex_x.Value + " ");
                }
                Console.WriteLine();
            }


            Console.WriteLine();
            Console.WriteLine("All Path in Graph");
            Dictionary<Vertex<int>, List<VertexList<int>>> dictionary = myGraph.GetAllPath();

            foreach (var vertex in dictionary.Keys)
            {
                foreach (var item in dictionary[vertex])
                {
                    foreach (var vertex_x in item)
                    {
                        Console.Write(vertex_x.Value + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
