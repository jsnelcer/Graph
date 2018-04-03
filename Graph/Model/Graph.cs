namespace Graph.Model
{
    using System.Collections.Generic;
    using System.Collections;
    using System;

    public class Graph<T> : IEnumerable<Vertex<T>>
    {
        private VertexList<T> vertexSet;
        public Graph():this(null)
        {

        }

        public Graph(VertexList<T> vertexSet)
        {
            if(vertexSet == null)
            {
                this.vertexSet = new VertexList<T>();
            }
            else
            {
                this.vertexSet = vertexSet;
            }
        }


        public IEnumerator<Vertex<T>> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.vertexSet[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddVertex(Vertex<T> vertex)
        {
            for (int i = 0; i < this.vertexSet.Count; i++)
            {
                if (this.vertexSet[i].Value.Equals(vertex.Value))
                {
                    throw new InvalidOperationException("You can't add vertices with the same value!");
                }
            }
            this.vertexSet.Add(vertex);
        }

        public void AddVertex(T value)
        {
            this.AddVertex(new Vertex<T>(value));
        }

        public void AddDirectedEdge(Vertex<T> from, Vertex<T> to)
        {
            //ToDo: check form repeated edges! (neighbours ... ??? )
            if (!this.vertexSet.Contains(from) || !this.vertexSet.Contains(to))
            {
                throw new InvalidOperationException("Edge is already exist!");
            }

            from.Neighbours.Add(to);
        }

        public void AddDirectedEdge(T from, T to)
        {
            Vertex<T> v_from = this.vertexSet.FindByValue(from);
            Vertex<T> v_to = this.vertexSet.FindByValue(to);
            this.AddDirectedEdge(v_from, v_to);
        }

        public void AddUndirectedEdge(Vertex<T> vertex_a, Vertex<T> vertext_b)
        {
            this.AddDirectedEdge(vertex_a, vertext_b);
            this.AddDirectedEdge(vertext_b, vertex_a);
        }

        public void AddUndirectedEdge(T value_a, T value_b)
        {
            this.AddDirectedEdge(value_a, value_b);
            this.AddDirectedEdge(value_b, value_a);
        }

        public bool RemoveVertex(Vertex<T> vertex2Remove)
        {
            if (vertex2Remove == null)
            {
                return false;
            }

            this.vertexSet.Remove(vertex2Remove);
            foreach (Vertex<T> gVertex in this.vertexSet)
            {
                int index = gVertex.Neighbours.IndexOf(vertex2Remove);
                if (index != -1)
                {
                    gVertex.Neighbours.RemoveAt(index);
                }
            }
            return true;
        }

        public bool RemoveVertex(T value)
        {
            Vertex<T> vertex2Remove = this.vertexSet.FindByValue(value);
            if (vertex2Remove != null)
            {
                return RemoveVertex(vertex2Remove);
            }
            else
            {
                return false;
            }
        }

        public bool Contains(T value)
        {
            return this.vertexSet.FindByValue(value) != null;
        }

        public bool Contains(Vertex<T> vertex)
        {
            return this.vertexSet.Contains(vertex);
        }

        public int Count
        {
            get
            {
                return this.vertexSet.Count;
            }
        }

        public VertexList<T> Vertices
        {
            get
            {
                return this.vertexSet;
            }
        }

        // indexer :) I <3 IT
        public Vertex<T> this[int index]
        {
            get
            {
                return this.vertexSet[index];
            }
        }

        public VertexList<T> DeepFirstSearch(Vertex<T> startNode)
        {
            return Algorithms.DeepFirstSearch<T>.Compute(this, startNode);
        }

        public Dictionary<Vertex<T>, List<VertexList<T>>> GetAllPath()
        {
            return Algorithms.FindAllPath<T>.Compute(this);
        }

        public List<VertexList<T>> GetAllPath(Vertex<T> startingVertex)
        {
            if (!this.vertexSet.Contains(startingVertex))
            {
                throw new InvalidOperationException("Please, pass a vertex is a part of Graph");
            }
            return Algorithms.FindAllPath<T>.Compute(this, startingVertex);
        }
    }
}
