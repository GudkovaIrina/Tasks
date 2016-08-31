using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty_i_rasshirenia3
{
    public class EventArgsForSortingIsMade<T> :EventArgs
    {
        public string Message { get; set; }
        public T[] arr;

        public EventArgsForSortingIsMade(T[] arr)
        {
            this.arr = arr;
            Message = "Сортировка завершена!";
        }
    }
}
