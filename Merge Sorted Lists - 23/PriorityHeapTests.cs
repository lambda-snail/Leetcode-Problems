using System.Collections.Immutable;
using Xunit;

namespace LeetCode.SortedLists;

public class PriorityHeapTests
{
    private PriorityHeap _heap;

    public PriorityHeapTests()
    {
        _heap = new PriorityHeap(10);
    }

    [Fact]
    public void ShouldBeEmpty_WhenConstructed()
    {
        Assert.Equal(0, _heap.Size);
    }

    [Fact]
    public void ShouldReturnInsertedItem_WhenInsertingOne()
    {
        int val = 10;
        
        _heap.Insert(val);
        int ret = _heap.RemoveTopNode();
        
        Assert.NotEqual(int.MinValue, ret);
        Assert.Equal(val, ret);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 3, 7, 2 })]
    [InlineData(new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, -1 }, 12)]
    public void ShouldReturnInCorrectOrder_WhenInsertingThree(int[] values, uint heapSize = 10)
    {
        _heap = new PriorityHeap(heapSize);
        int[] expected = new int[values.Length]; 
        Array.Copy(values, expected, expected.Length); 
        Array.Sort(expected);

        for (int i = 0; i < values.Length; ++i)
        {
            _heap.Insert(values[i]);
        }

        for (int i = 0; i < expected.Length; ++i)
        {
            int val = _heap.RemoveTopNode();
            Assert.Equal(expected[i], val);
        }
    }
}