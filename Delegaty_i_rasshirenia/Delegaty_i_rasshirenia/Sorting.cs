using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia3
{
    public class Sorting<T>
    {
        T[] arr;
        Func<T, T, int> func;
        
        public Sorting(T[] arr, Func<T, T, int> func)
        {
            this.arr = arr;
            this.func = func;
        }
        
        private int Partition(T[] arr, int a, int b, Func<T, T, int> func)
        {
            int i = a;
            for (int j = a; j <= b; j++)
            {
                if (func(arr[j], arr[b]) <= 0)
                {
                    T t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;
                    i++;
                }
            }
            return i - 1;
        }
        
        public void Sort(T[] arr, int a, int b, Func<T, T, int> func)
        {
            if (a >= b) return;
            int c = Partition(arr, a, b, func);
            Sort(arr, a, c - 1, func);
            Sort(arr, c + 1, b, func);
        }
        
        private void Sort(object obj) 
        {
            if (obj is T[])
            {
                T[] arr = (T[])obj;
                Sort(arr, 0, arr.Length - 1, this.func);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        
        public void SortInSeparateThread() 
        {
            Thread thread = new Thread(Sort);
            thread.Start(arr);
            EventHandler<EventArgsForSortingIsMade<T>> handler = SortingIsMade;
            EventArgsForSortingIsMade<T> e = new EventArgsForSortingIsMade<T>(arr);
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<EventArgsForSortingIsMade<T>> SortingIsMade;
    }
}
