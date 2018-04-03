namespace Graph.Algorithms
{
    using System.Linq;
    using System.Collections.Generic;
    using Graph.Model;

    public static class FindAllPath<T>
    {
        private static List<VertexList<T>> allPathWitAStartingVertex;
        private static VertexList<T> iteratorList;
        private static Dictionary<Vertex<T>, List<VertexList<T>>> allPath;

        public static Dictionary<Vertex<T>, List<VertexList<T>>> Compute(Graph<T> graph)
        {
            allPath = new Dictionary<Vertex<T>, List<VertexList<T>>>();
            foreach (var current_vertex in graph.Vertices)
            {
                allPath.Add(current_vertex, Compute(graph, current_vertex));
            }

            return allPath;
        }

        public static List<VertexList<T>> Compute(Graph<T> graph, Vertex<T> startingVertex)
        {
            iteratorList = new VertexList<T>();
            allPathWitAStartingVertex = new List<VertexList<T>>();
            iteratorList.Add(startingVertex);
            DepthFirstSearch(startingVertex);

            return allPathWitAStartingVertex.OrderBy(x => x.Count).ToList();
        }

        private static void DepthFirstSearch(Vertex<T> vertex)
        {
            foreach (var neighbour in vertex.Neighbours)
            {
                if (!iteratorList.Contains(neighbour))
                {
                    iteratorList.Add(neighbour);
                    DepthFirstSearch(neighbour);
                }
            }

            allPathWitAStartingVertex.Add(iteratorList.Clone());
            iteratorList.RemoveAt(iteratorList.Count - 1);
            return;
        }
    }
}
