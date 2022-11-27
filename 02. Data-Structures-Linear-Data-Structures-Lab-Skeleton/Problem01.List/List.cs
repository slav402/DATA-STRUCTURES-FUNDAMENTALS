namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index] 
        {
            get 
            {
                this.ValidateIndex(index);
                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            
            this.Grow();

            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            //foreach (var elemnt in this.items.Take(this.Count))     //"Take" vzema ot masiva samo tolkova elementa kolkoto e Count-a
            //{
            //    if (item.Equals(elemnt))
            //    {
            //        return true;
            //    }
            //}
            //     //-------------------------------------------------------------------------------

            //for (int i = 0; i < this.Count; i++)  // tova e sy6toto kato gornoto
            //{
            //    if (this.items[i].Equals(item))
            //    {
            //        return true;
            //    }
            //}

            //return false;

            return this.IndexOf(item) != -1 ? true : false; //preizpolzwame "IndexOf"
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow ()
        {
            if (this.Count == this.items.Length)
            {
                T[] itemsCopy = new T[this.items.Length * 2];
                Array.Copy(items, itemsCopy, this.Count);   // tova kopira edin masiv vav drug

                items = itemsCopy;
            }
        }

        private void ValidateIndex (int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}