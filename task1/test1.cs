using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    internal class test1
    {
        static void Main(string[] args)
        {
            var divider = int.Parse(Console.ReadLine());
            var line = Console.ReadLine().Split(' ');
            var a = new HashTable(divider);
            foreach ( var element in line ) 
            {
                a.Insert(int.Parse(element));
            }
            a.ShowHashTable();
        }
    }
    class HashTable
    {
        public Array<int>[] values;
        public int Divider;
        public HashTable(int n)
        {
            Divider = n;
            values = new Array<int>[n];
        }
        public void Insert(int newValue)
        {
            var key = GetHash(newValue);
            if (values[key] == null)
                values[key] = new Array<int>();
            values[key].Add(newValue);
        }
        private int GetHash(int newValue)
        {
            return newValue % Divider;
        }
        public void ShowHashTable()
        {
            for ( int i = 0; i < Divider; i++)
            {
                Console.Write(i+": ");
                if (values[i] != null)
                {
                    foreach (var j in values[i])
                    {
                        Console.Write(j+" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class ListNode<T>
    {
        public T value;
        public ListNode<T> next;

        public ListNode(T newValue)
        {
                value = newValue;    
        }
    }

    class Array<T>
    {
        public ListNode<T> head;
        public ListNode<T> tail;

        public void Add(T newVal)
        {
            ListNode<T> node = new ListNode<T>(newVal);

            if (head == null)
                head = node;
            else
                tail.next = node;

            tail = node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.value;
                current = current.next;
            }
        }
    }
}
