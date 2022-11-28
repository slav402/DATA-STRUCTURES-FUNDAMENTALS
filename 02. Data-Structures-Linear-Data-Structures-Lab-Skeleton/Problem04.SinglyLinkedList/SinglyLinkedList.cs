namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;
        
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = newNode;
            }
            this.Count++;
        }


        public T GetFirst()
        {
            IsEmpty();

            return head.Element;
        }

        public T GetLast()
        {
            IsEmpty();

            var node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            return node.Element;
        }

        public T RemoveFirst()
        {
            IsEmpty();

            var oldFirst = this.head;
            this.head = oldFirst.Next;
            this.Count--;
            return oldFirst.Element;
        }

        public T RemoveLast()
        {
            IsEmpty();

            if (this.Count == 1)
            {
                var singleElem = this.head;
                this.head = null;
                this.Count--;
                return singleElem.Element;
            }
            
            var element = this.head;

            while (element.Next.Next != null)
            {
                element = element.Next;
            }

            var lastElement = element.Next;
            element.Next = null;
            this.Count--;
            return lastElement.Element;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void IsEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}