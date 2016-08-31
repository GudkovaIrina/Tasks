using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOOP4
{
    class MyString
    {
        char[] arr;

        public MyString(char[] arr)
        {
            this.arr = arr;
        }
        public MyString(int length)
        {
            arr = new char[length];
        }
        
        public char this[int item]
        {
            get
            {
                return arr[item];
            }
            set
            {
                arr[item] = value;
            }
        }

        public int Length { get { return arr.Length; } }

        public MyString Join(MyString str)
        { 
            char[] arr = new char[this.Length+str.Length];
            this.arr.CopyTo(arr,0);
            str.arr.CopyTo(arr,this.Length);
            return new MyString(arr);
        }

        public void CopyTo(int sourseIndex,  ref MyString destination, int destinationIndex, int count)
        {
            char[] arr = new char[destination.Length];
            destination.arr.CopyTo(arr, 0);
            for (int i = destinationIndex, j = sourseIndex; i < destinationIndex + count; i++,j++)
			{
			    arr[i] = this.arr[j];
			}
            destination = new MyString(arr);

        }

        public void Insert(int startIndex, MyString str)
        {
            MyString newstr = new MyString(this.Length + str.Length);
            this.CopyTo(0, ref newstr, 0, startIndex);
            str.CopyTo(0, ref newstr, startIndex, str.Length);
            this.CopyTo(startIndex, ref newstr, startIndex + str.Length, this.Length - startIndex);
            this.arr = newstr.arr;
        }

        static public MyString operator +(MyString str1, MyString str2)
        {
            return str1.Join(str2);
        }

        static public  implicit operator String(MyString str)
        {
            return new string(str.arr);
        }

        static public explicit operator MyString(String str)
        {
            return new MyString(str.ToCharArray());
        }
    }
}
