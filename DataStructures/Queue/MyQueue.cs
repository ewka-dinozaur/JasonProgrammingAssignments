using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    public class MyQueue
    {
        private LinkedList list = new LinkedList();

        public void Enqueue (int value) // dodaje element ze zmiennej value
        {
            list.Add(value);

        }

        public int Dequeue()
        {
            return list.RemoveFirst();// usuwa pierwszy element
        }
        public void Print()
        {
            list.Print();
        }

    }
}

