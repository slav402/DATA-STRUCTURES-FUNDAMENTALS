namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get;  private set; }
            public Node Right { get;  set; }
            public Node Left { get;  set; }
        }

        private Node root;

        public BinarySearchTree() { }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(action, this.root);
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);

            action.Invoke(node.Value);

            this.EachInOrder(action, node.Right);
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        public IBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
    }
}
