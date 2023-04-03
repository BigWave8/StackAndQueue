using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueueProject
{
    public class MyStack<T>
    {
        public List<T> Stack { get; set; }

        public MyStack() 
        { 
            Stack = new List<T>();
        }

        public MyStack(List<T> stack) 
        {
            Stack = stack; 
        }

        public void Push(T newElement)
        {
            if (newElement == null)
            {
                return;
            }
            Stack.Add(newElement);
        }

        public T Pop()
        {
            if (Stack.Count == 0)
            {
                throw new Exception("Stack is empty");
            }
            int lastItemIndex = Stack.Count - 1;
            T firstElement = Stack[lastItemIndex];
            Stack.RemoveAt(lastItemIndex);
            return firstElement;
        }

        public T Peek()
        {
            if (Stack.Count == 0)
            {
                throw new Exception("Stack is empty");
            }
            int lastItemIndex = Stack.Count - 1;
            return Stack[lastItemIndex];
        }

        public void Clear()
        {
            Stack = new List<T>();
        }
    }
}
