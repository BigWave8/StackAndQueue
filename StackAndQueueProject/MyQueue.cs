using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueueProject
{
    public class MyQueue<T>
    {
        public List<T> Queue { get; set; }

        public MyQueue()
        { 
            Queue = new List<T>();
        }

        public MyQueue(List<T> queue) { this.Queue = queue; }

        public void Enqueue(T newElement)
        {
            if (newElement == null)
            {
                return;
            }
            Queue.Add(newElement);
        }

        public T Dequeue()
        {
            if (Queue.Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            T firstElement = Queue[0];
            Queue.RemoveAt(0);
            return firstElement;
        }

        public T Peek()
        {
            if (Queue.Count == 0)
            {
                throw new Exception("Queue is empty");
            }
            return Queue[0];
        }

        public void Clear()
        {
            Queue = new List<T>();
        }
    }
}
