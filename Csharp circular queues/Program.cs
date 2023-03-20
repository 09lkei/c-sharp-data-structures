using System;

class Program {
  public static void Main (string[] args) {
    queue<string> myQueue = new queue<string>(5);
    Console.WriteLine(myQueue.dequeue());
    myQueue.enqueue("hello");
    myQueue.enqueue("hello2");
    myQueue.enqueue("hello3");
    myQueue.enqueue("hello4");
    myQueue.enqueue("hello5");
    myQueue.enqueue("hello6");
    myQueue.dequeue();
    myQueue.returnQueue();
  }
}

class queue<T> {
  private int maxSize = -1;
  private T[] data;
  private int back = 0;
  private int front = 0;
  public queue(int maxSize) {
    this.maxSize = maxSize;
    data = new T[maxSize];
  }

  public void enqueue(T newItem) {
    if ((back-front)<maxSize) {
      data[back%maxSize] = newItem;
      if (back<maxSize*2) {
        back++;
      }
      else
      {
        back = 0;
        front -= maxSize;
      }
    } else {
      Console.WriteLine("Full queue!");
    }
  }

  public T dequeue() {
    if (back-front>0)
    {
      T removed = data[front%maxSize];
      if (front < maxSize)
      {
        front++;
      }
      else
      {
        front = 0;
        back -= maxSize;
      }
      return removed;
    } else {
      return default(T);
    }
  }

  public void returnQueue()
  {
    for (int i =front;i<back;i++)
    {
      if (i < maxSize)
      {
        Console.WriteLine(data[i]);
      }
      else
      {
        Console.WriteLine(data[i-maxSize]);
      }
    }
  }
}