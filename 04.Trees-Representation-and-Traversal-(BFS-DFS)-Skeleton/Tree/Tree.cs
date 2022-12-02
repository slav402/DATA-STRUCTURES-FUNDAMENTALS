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
            var workingQueue = new Queue<Tree<T>>();
            var result = new List<T>();
            workingQueue.Enqueue(this);

            while (workingQueue.Count > 0)
            {
                var currentNode = workingQueue.Dequeue();

                foreach (var child in currentNode.children)
                {
                    workingQueue.Enqueue(child);
                }

                result.Add(currentNode.value);
            }

            return result;
        }

        private void Dfs (Tree<T> currentNode, ICollection<T> result)
        {
            foreach (var child in currentNode.children)
            {
                this.Dfs(child, result);
            }

            result.Add(currentNode.value);
        }
        
        public IEnumerable<T> OrderDfs()
        {
            var resultList = new List<T>();
            this.Dfs(this, resultList);
            return resultList;
        }

        private IEnumerable<T> DfsWithStack()
        {
            var workingStack = new Stack<Tree<T>>();
            var result = new Stack<T>();
            workingStack.Push(this);

            while (workingStack.Count > 0)
            {
                var currentNode = workingStack.Pop();

                foreach (var child in currentNode.children)
                {
                    workingStack.Push(child);
                }

                result.Push(currentNode.value);
            }

            return result;
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
