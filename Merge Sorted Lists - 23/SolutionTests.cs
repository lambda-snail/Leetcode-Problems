using Xunit;

namespace LeetCode.SortedLists;

public class SolutionTests
{
    private Solution solution;

    public SolutionTests()
    {
        //solution = new NaiveSolution();
        solution = new PriorityHeapSolution();
    }
    
    [Fact] 
    public void ShouldHandle_EmptyList()
    {
        var result = solution.MergeKLists(new ListNode[0]);
        Assert.Null(result);
    }

    [Fact]
    public void ShouldHandle_OneNode_OneList()
    {
        var nodes = new ListNode[] { new ListNode(1, null) };
        var result = solution.MergeKLists(nodes);
        Assert.Equal(1, result.val);
        Assert.Null(result.next);
    }

    [Fact]
    public void ShouldHandle_TwoNodes_OneList()
    {
        var node1 = new ListNode(1);
        var node2 = new ListNode(2);
        node1.next = node2;
        
        var nodes = new ListNode[] { node1 };
        var result = solution.MergeKLists(nodes);
        
        Assert.Equal(1, result.val);
        Assert.NotNull(result.next);
        Assert.Equal(2, result.next.val);
        Assert.Null(result.next.next);
    }
    
    [Fact]
    public void ShouldHandle_OneNode_TwoList()
    {
        var node11 = new ListNode(1);
        // var node12 = new ListNode(2);
        // node11.next = node12;
        
        var node21 = new ListNode(0);
        // var node22 = new ListNode(4);
        // node21.next = node22;
        
        var nodes = new ListNode[] { node11, node21 };
        var result = solution.MergeKLists(nodes);
        
        Assert.Equal(0, result.val);
        Assert.Equal(1, result.next.val);
    }
    
    [Fact]
    public void ShouldHandle_TwoNodes_TwoList()
    {
        var node11 = new ListNode(1);
        var node12 = new ListNode(2);
        node11.next = node12;
        
        var node21 = new ListNode(0);
        var node22 = new ListNode(4);
        node21.next = node22;
        
        var nodes = new ListNode[] { node11, node21 };
        var result = solution.MergeKLists(nodes);
        
        Assert.Equal(0, result.val);
        Assert.Equal(1, result.next.val);
        Assert.Equal(2, result.next.next.val);
        Assert.Equal(4, result.next.next.next.val);
    }

    [Fact]
    //[[1,4,5],[1,3,4],[2,6]]
    public void LeetCode_TestCase1()
    {
        ListNode n11 = new(1);
        ListNode n12 = new(4);
        ListNode n13 = new(5);
        
        ListNode n21 = new(1);
        ListNode n22 = new(3);
        ListNode n23 = new(4);
        
        ListNode n31 = new(2);
        ListNode n32 = new(6);

        n11.next = n12;
        n12.next = n13;
        
        n21.next = n22;
        n22.next = n23;
        
        n31.next = n32;

        var result = solution.MergeKLists(new ListNode[] {n11, n21, n31});
        
        // Expect: [1,1,2,3,4,4,5,6]
        Assert.Equal(1, result.val);
        Assert.Equal(1, result.next.val);
        Assert.Equal(2, result.next.next.val);
        Assert.Equal(3, result.next.next.next.val);
        Assert.Equal(4, result.next.next.next.next.val);
        Assert.Equal(4, result.next.next.next.next.next.val);
        Assert.Equal(5, result.next.next.next.next.next.next.val);
        Assert.Equal(6, result.next.next.next.next.next.next.next.val);
    }

    [Fact]
    // In: [[],[-1,5,11],[],[6,10]]
    // Out: [-1,5,6,10,11]
    public void LeetCode_TestCase2()
    {
        ListNode n11 = new(-1);
        //ListNode n12 = new(5); n11.next = n12;
        ListNode n13 = new(11); n11.next = n13;
        
        ListNode n21 = new(6);
        ListNode n22 = new(10); n21.next = n22;
        
        var result = solution.MergeKLists(new ListNode[] {null, n11, null, n21});
        
        Assert.Equal(-1, result.val);
        Assert.Equal(6, result.next.val);
        Assert.Equal(10, result.next.next.val);
        Assert.Equal(11, result.next.next.next.val);
        //Assert.Equal(11, result.next.next.next.next.val);
    }
    
    [Fact]
    public void EmptyListOfEmptyNode()
    {
        solution.MergeKLists(new ListNode[] {null});
    }
}
