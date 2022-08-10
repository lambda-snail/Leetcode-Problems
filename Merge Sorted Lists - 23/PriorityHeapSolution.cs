namespace LeetCode.SortedLists;

public class PriorityHeapSolution : Solution
{
    private static uint LIST_MAX_LENGTH = 500;
    public override ListNode MergeKLists(ListNode[] lists)
    {
        if (lists is null || lists.Length == 0)
        {
            return null;
        }

        PriorityHeap heap = new PriorityHeap((uint)lists.Length * LIST_MAX_LENGTH);
        
        for (int listNum = 0; listNum < lists.Length; ++listNum)
        {
            if (lists[listNum] is null) { continue; }

            ListNode n = lists[listNum];
            do
            {
                heap.Insert(n.val);
                n = n.next;
            } while (n is not null);
        }

        ListNode head = new ListNode(); // Placeholder to be discarded
        ListNode ptr = head;
        for (int i = 0; heap.Size > 0; ++i)
        {
            int val = heap.RemoveTopNode();
            
            ListNode n = new ListNode(val);
            ptr.next = n;
            ptr = n;
        }
        
        return head.next;
    }
}
