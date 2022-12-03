namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            var parentNode = this.FindNodeWithDfs(parentKey);

            if (parentNode is null)
            {
                throw new ArgumentNullException();
            }
            
            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        private Tree<T> FindNodeWithDfs(T parentKey)
        {
            var workingQueue = new Queue<Tree<T>>();
            
            workingQueue.Enqueue(this);

            while (workingQueue.Count > 0)
            {
                var subtree = workingQueue.Dequeue();

                if (subtree.value.Equals(parentKey))
                {
                    return subtree;
                }

                foreach (var child in subtree.children)
                {
                    workingQueue.Enqueue(child);
                }
            }

            return null;
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
            var toBeDelitedNode = this.FindNodeWithDfs(nodeKey);

            if (toBeDelitedNode is null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = toBeDelitedNode.parent;

            if (parentNode == null)
            {
                throw new ArgumentException();
            }

            //parentNode.children = parentNode.children.Where(node => !node.value.Equals(nodeKey)).ToList();
            parentNode.children.Remove(toBeDelitedNode); //tova e ekvivalent na gornoto
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNodeWithDfs(firstKey);
            var secondNode = this.FindNodeWithDfs(secondKey);

            if (firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            var firstParent = firstNode.parent;
            var secondParent = secondNode.parent;


            if (firstParent is null || secondParent is null)
            {
                throw new ArgumentException();
            }

            var indexOfFirstNode = firstParent.children.IndexOf(firstNode);
            var indexOfSecondNode = secondParent.children.IndexOf(secondNode);

            firstParent.children[indexOfFirstNode] = secondNode;
            secondParent.children[indexOfSecondNode] = firstNode;
        }
    }
}
