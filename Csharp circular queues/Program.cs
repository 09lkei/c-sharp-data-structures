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
  private int count = 0;
  public queue(int maxSize) {
    this.maxSize = maxSize;
    data = new T[maxSize];
  }

  public void enqueue(T newItem) {
    if (count<maxSize) {
      data[back] = newItem;
      if (back<maxSize) {
        back++;
      }
      else
      {
        back = 0;
      }
      count++; 
      } else {
      Console.WriteLine("Full queue!");
    }
  }

  public T dequeue() {
    if (count>0)
    {
      T removed = data[front];
      data[front] = default(T);
      if (front < maxSize)
      {
        front++;
      }
      else
      {
        front = 0;
      }
      count--;
      return removed;
    } else {
      return default(T);
    }
  }

  public void returnQueue() {
    foreach (T s in data) {
      Console.WriteLine(s);
    }
  }
}