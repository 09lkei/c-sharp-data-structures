using System;

class Program
{
    public static void Main(string[] args)
    {
        myPriorityQueue<int> queue = new myPriorityQueue<int>(10,10);
        for (int i = 0; i < 100; i++)
        {
            queue.enqueue(i,(i+1)%10);
        }

        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(queue.dequeue());
        }
    }
}

class myPriorityQueue<T>
{
    private T[,] data;
    private int size;
    private int levels;
    private int[] backs;
    private int[] fronts;
    public myPriorityQueue(int size, int levels)
    {
        this.size = size;
        this.levels = levels;
        data = new T[levels,size];
        backs = new int[size];
        fronts = new int[size];
    }

    public void enqueue(T newItem, int level)
    {
        int back = backs[level];
        int front = fronts[level];
        if ((back-front)<size) {
            data[level, back%size] = newItem;
            if (back<size*2) {
                backs[level]++;
            }
            else
            {
                backs[level] = 0;
                fronts[level] -= size;
            }
        } else {
            Console.WriteLine("Full queue!");
        }
    }
    public T dequeue() {
        for (int i = 1; i < levels; i++)
        {
            if (backs[i] > fronts[i])
            {
                T removed = data[i,fronts[i]%size];
                if (fronts[i] < size)
                {
                    fronts[i]++;
                }
                else
                {
                    fronts[i] = 0;
                    backs[i] -= size;
                }
                return removed;
            }
        }
        Console.WriteLine("Tried dequeueing from empty list");
        return default(T);
    }
}