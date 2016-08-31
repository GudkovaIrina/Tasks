using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BasicOOP9
{
    public class MyDynamicArray<T> : IEnumerable<T>, IList<T>, IList, ICollection<T>, ICollection, IEnumerable
    {
        private T[] arr;
        private int length;
        private const int DefaultCapacity = 8;

        public int Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= Capacity)
                {
                    length = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Capacity
        {
            get
            {
                return arr.Length;
            }
        }

        public T this[int i]
        {
            get
            {
                return arr[i];
            }
            set
            {
                if ((i < 0) || (i >= Length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    arr[i] = value;
                }
            }
        }

        public MyDynamicArray()
            : this(DefaultCapacity)
        {
        }

        public MyDynamicArray(int capacity)
        {
            arr = new T[capacity];
            Length = 0;
        }

        public MyDynamicArray(IEnumerable<T> collection)
        {
            int newSize = collection.Count();
            this.ReCreation(collection, newSize * 2);
            Length = newSize;
        }

        private void ReCreation(IEnumerable<T> collection, int newCapacity)
        {
            T[] newarr = new T[newCapacity];
            int i = 0;
            foreach (var item in collection)
            {
                newarr[i] = item;
                i++;
            }
            arr = newarr;
        }

        private void DoubledCapacity()
        {
            Array.Resize<T>(ref arr, Capacity * 2);
        }

        public void Add(T item)
        {
            if (Length >= Capacity)
            {
                DoubledCapacity();
            }
            arr[Length] = item;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int newSize = Length + collection.Count();
            if (newSize > Capacity)
            {
                this.ReCreation(arr, newSize * 2);
            }
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public bool Remove(T value)
        {
            int index = Array.IndexOf(arr, value,0,Length);

            if (index >= 0)
            {
                for (int i = index, j = index; i < length; i++, j++)
                {
                    if (arr[j].Equals(value))
                    {
                        j++;
                        Length--;
                    }
                    arr[i] = arr[j];
                }
            }
            return index >= 0;
        }

        private struct MyIEnumerator : IEnumerator<T>
        {
            private int index;
            private MyDynamicArray<T> arr;

            public MyIEnumerator(MyDynamicArray<T> arr)
            {
                this.arr = arr;
                index = -1;
            }

            public T Current
            {
                get { return arr[index]; }
            }

            public void Dispose()
            {
                index = -1;
            }

            object IEnumerator.Current
            {
                get { return arr[index]; }
            }

            public bool MoveNext()
            {
                if (index < arr.Length)
                {
                    index++;
                }
                return index < arr.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyIEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new MyIEnumerator(this);
        }

        #region Enumerator

        //public IEnumerator<int> GetEnumerator()
        //{
        //    return new ArrayEnumerator(this);
        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    return new ArrayEnumerator(this);
        //}

        //private struct ArrayEnumerator : IEnumerator<int>, IDisposable, IEnumerator
        //{
        //    private int index;
        //    private MyDynamicArray arr;

        //    public ArrayEnumerator(MyDynamicArray arr)
        //    {
        //        this.arr = arr;
        //        index = -1;
        //    }

        //    public int Current
        //    {
        //        get { return arr[index]; }
        //    }

        //    public void Dispose()
        //    {
        //    }

        //    object System.Collections.IEnumerator.Current
        //    {
        //        get { return arr[index]; }
        //    }

        //    public bool MoveNext()
        //    {
        //        if (index < arr.Length)
        //        {
        //            index++;
        //        }
        //        return index < arr.Length;
        //    }

        //    public void Reset()
        //    {
        //        index = -1;
        //    }
        //}

        #endregion Enumerator

        public int IndexOf(T item)
        {
            return Array.IndexOf(arr, item,0,Length);
        }

        public void Insert(int index, T item)
        {
            if ((index < 0) || (index >= Length))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (Length >= Capacity)
                {
                    DoubledCapacity();
                }
                Length++;
                for (int i = Length - 1; i > index; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[index] = item;
            }
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Length))
            {
                Length--;
                for (int i = index; i < length; i++)
                {
                    arr[i] = arr[i + 1];
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Clear()
        {
            arr = new T[DefaultCapacity];
        }

        public bool Contains(T item)
        {
            return arr.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            arr.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int Add(object value)
        {
            try
            {
                this.Add((T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Can not cast added value to object");
            }
            return Length - 1;
        }

        public bool Contains(object value)
        {
            try
            {
                return this.Contains((T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("This object can not cast to type MyDynamicArray<T>");
            }
        }

        public int IndexOf(object value)
        {
            try
            {
                return this.IndexOf((T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("This object can not cast to type MyDynamicArray<T>");
            }
        }

        public void Insert(int index, object value)
        {
            try
            {
                this.Insert(index, (T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("This object can not cast to type MyDynamicArray<T>");
            }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public void Remove(object value)
        {
            try
            {
                this.Remove((T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("This object can not cast to type MyDynamicArray<T>");
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                try
                {
                    arr[index] = (T)value;
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException("This object can not cast to type MyDynamicArray<T>");
                }
            }
        }

        public void CopyTo(Array array, int index)
        {
            try
            {
                this.CopyTo(array, index);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("This object can not cast to type MyDynamicArray<T>");
            }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}