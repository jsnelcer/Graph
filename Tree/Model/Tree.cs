namespace Tree.Model
{
    using System;

    public class Tree<T>
    {
        private Vertex<T> root;

        public Vertex<T> Root
        {
            get { return this.root; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Root cannot be null!");
                }

                this.root = value;
            }
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (var child in children)
            {
                root.AddChild(child.Root);
            }
        }

        public Tree(Vertex<T> root)
        {
            this.Root = root;
        }

        public Tree(T value)
        {
            this.Root = new Vertex<T>(value);
        }
    }
}
