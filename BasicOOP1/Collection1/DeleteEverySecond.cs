using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection1
{
    class DeleteEveryMultiple<T>
    {
        private LinkedList<T> list;

        public DeleteEveryMultiple(IEnumerable<T> collection)
        {
            list = new LinkedList<T>(collection);
        }

        public T ResultProcess(int multiple)
        {
            LinkedListNode<T> node;
            LinkedListNode<T> nextNode;
            node = SearchElementForDeleted(list.Last, multiple);
            
            while (list.Count > 1)
            {
                nextNode = SearchElementForDeleted(node, multiple);
                list.Remove(node);
                node = nextNode;
            }

            return list.First.Value;
        }

        private LinkedListNode<T> SearchElementForDeleted(LinkedListNode<T> node, int multiple)
        {
            for (int i = 0; i < multiple; i++)
            {
                if (node.Next == null)
                {
                    node = list.First;
                }
                else
                {
                    node = node.Next;
                }
            }
            return node;
        }
    }
}
