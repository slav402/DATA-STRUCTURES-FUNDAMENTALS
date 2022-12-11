using System;
using System.Collections.Generic;
using System.Text;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            this.HeapifyUp(this.elements.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = GetParentIndex(index);

            while (index > 0 && IsSmaller(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsSmaller(int index, int parentIndex)
        {
            return this.elements[index].CompareTo(this.elements[parentIndex]) < 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        public T ExtractMin()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var element = this.elements[0];
            this.Swap(0, this.elements.Count - 1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int index)
        {
            var smallerChildIndex = GetSlallerChildIndex(index);

            while (IsIndexValid(smallerChildIndex) && this.IsSmaller(smallerChildIndex, index))
            {
                this.Swap(index, smallerChildIndex);
                index = smallerChildIndex;
                smallerChildIndex = this.GetSlallerChildIndex(index);
            }
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < this.elements.Count;
        }

        private int GetSlallerChildIndex(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex = index * 2 + 2;

            if (secondChildIndex < this.elements.Count)
            {
                if (IsSmaller(firstChildIndex, secondChildIndex)) // da se pregleda ako ne raboti
                {
                    return firstChildIndex;
                }

                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;
            }
            else
            {
                return -1;
            }

        }

        public T Peek()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.elements[0];
        }
    }
}
