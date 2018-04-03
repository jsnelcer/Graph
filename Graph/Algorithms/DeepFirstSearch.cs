namespace Graph.Algorithms
{
    using Graph.Model;

    public static class DeepFirstSearch<T>
    {

        private static VertexList<T> list;
        private static VertexList<T> checkList;

        public static VertexList<T> Compute(Graph<T> graph, Vertex<T> startNode)
        {
            list = new VertexList<T>();
            checkList = new VertexList<T>();

            checkList.Add(startNode);
            Search(startNode);

            return list;
        }

        private static Vertex<T> Search(Vertex<T> currentVertex)
        {
            foreach (var neighbour in currentVertex.Neighbours)
            {
                if (!checkList.Contains(neighbour))
                {
                    checkList.Add(neighbour);
                    Search(neighbour);
                }
            }

            list.Add(currentVertex);
            return currentVertex;
        }

    }
}
