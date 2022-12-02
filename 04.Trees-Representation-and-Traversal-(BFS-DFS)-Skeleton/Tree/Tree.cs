namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private  List<Tree<T>> children;
        private T value;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var childe in children)
            {
                childe.parent = this;
                this.children.Add(childe);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>() {  };
            var result = new List<T>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);

                foreach (var childe in subtree.children)
                {
                    queue.Enqueue(childe);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
