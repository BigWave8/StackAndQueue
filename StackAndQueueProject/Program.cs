Stack<int> myStack = new Stack<int>();
myStack.Push(10);
myStack.Push(1);
myStack.Peek();
myStack.Push(2);
myStack.Push(3);
myStack.Pop();
myStack.Clear();



Queue<string> myQueue = new Queue<string>();
myQueue.Enqueue("a");
myQueue.Enqueue("b");   
myQueue.Enqueue("c");
myQueue.Dequeue();
Console.WriteLine(myQueue.Peek());
myQueue.Enqueue("d");
myQueue.Clear();
myQueue.Enqueue("e");
myQueue.Enqueue("f");    
myQueue.Enqueue("g");
myQueue.Enqueue("h");

List<string> myList = myQueue.ToList();

Stack<string> yourStack = new Stack<string>(myList);
Console.WriteLine(yourStack.Peek());