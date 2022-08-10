namespace LeetCode.SortedLists;

public struct HeapElement : IComparable<HeapElement>
{
    public int Value { get; set; }
    //public ListNode Node;
    public int CompareTo(HeapElement other)
    {
        if (Value < other.Value)
        {
            return -1;
        }

        if (Value > other.Value)
        {
            return 1;
        }

        return 0;
    }
}

public class PriorityHeap
{
    private HeapElement [] _heap;
    public int Size { get; private set; }

    public PriorityHeap(uint capacity)
    {
        _heap = new HeapElement [capacity];
        Size = 0;
    }

    private int LeftChild(int i)
    {
        return 2 * i + 1;
    }
    
    private int RightChild(int i)
    {
        return 2 * i + 2;
    }
    
    private int Parent(int i)
    {
        return (i - 1) / 2;
    }

    public void Insert(int n)
    {
        HeapElement e = new HeapElement() {Value = n};

        int newPos = Size++;

        while (newPos > 0 && e.CompareTo(_heap[Parent(newPos)]) < 0)
        {
            _heap[newPos] = _heap[Parent(newPos)];
            newPos = Parent(newPos);
        }

        _heap[newPos] = e;
    }

    private void Swap(int e1, int e2)
    {
        (_heap[e1], _heap[e2]) = (_heap[e2], _heap[e1]);
    }

    private void Heapify(int e)
    {
        int lchild = LeftChild(e);
        int rchild = RightChild(e);
        int smallest = lchild < Size && _heap[lchild].CompareTo(_heap[e]) < 0 ? lchild : e;
        
        if (rchild < Size && _heap[rchild].CompareTo(_heap[smallest]) < 0)
        {
            smallest = rchild;
        }
        
        if (smallest != e)
        {
            Swap(e, smallest);
            Heapify(smallest);
        }
    }
    
    public int RemoveTopNode()
    {
        var retval = int.MinValue;
        if(Size > 0)
        {
            retval = _heap[0].Value;
            _heap[0] = _heap[--Size];
            Heapify(0) ;
        }

        return retval;
    }
}