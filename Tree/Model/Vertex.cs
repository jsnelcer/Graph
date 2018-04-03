namespace Tree.Model
{
    using System.Collections.Generic;
    using System;

    public class Vertex<T>
    {
        private T value;
        private List<Vertex<T>> children;
        private bool hasParent;

        public Vertex(T value)
        {
            this.Value = value;
            this.children = new List<Vertex<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot create a vertex with null value!");
                }
                this.value = value;
            }
        }

        public int ChildrentCount
        {
            get { return this.children.Count; }
        }

        public void AddChild(Vertex<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot add child with null value!");
            }
            if (child.hasParent)
            {
                throw new ArgumentNullException("The vertex already has a parent!");
            }
            child.hasParent = true;
            this.children.Add(child);
        }

        public Vertex<T> GetChild(int index)
        {
            if (index >= this.children.Count)
            {
                throw new ArgumentOutOfRangeException("Index is bigger than then number!");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index cannot be negative!");
            }
            return this.children[index];
        }

        public List<Vertex<T>> GetChildren()
        {
            return children;
        }

        public bool IsRoot()
        {
            return !this.hasParent;
        }

        public bool IsTerminal()
        {
            return this.ChildrentCount == 0;
        }
    }
}