namespace Graph.Model
{
    using System.Collections.Generic;

    public class Vertex<T>
    {
        private T value;
        private VertexList<T> neighbours;

        #region Constructor
        
        public Vertex()
        {

        }

        public Vertex(T value):this(value, new VertexList<T>())
        {
            this.Value = value;
        }
        
        public Vertex(T value, VertexList<T> neighbours)
        {
            this.Value = value;
            this.Neighbours = neighbours;
        }

        #endregion

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public VertexList<T> Neighbours
        {
            get { return this.neighbours; }
            set { this.neighbours = value; }
        }
    }
}
