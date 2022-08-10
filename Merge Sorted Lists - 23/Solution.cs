namespace LeetCode.SortedLists;

public abstract class Solution
{
    public abstract ListNode MergeKLists(ListNode[] lists);
}

/// <summary>
/// Naive implementation that does not use priority heap.
/// </summary>
public class NaiveSolution : Solution {

    public override ListNode MergeKLists(ListNode[] lists)
    {
        if (lists is null || lists.Length == 0)
        {
            return null;
        }

        ListNode resultHead = new(int.MinValue); // Placeholder to be discarded last
        ListNode? resultCursor = resultHead;
        for (int i = 0; i < lists.Length; ++i)
        {
            ListNode? listCursor = lists[i];
            while (listCursor is not null)
            {
                if (resultCursor.next is null)
                {
                    resultCursor.next = listCursor;
                    break;
                }

                if (listCursor.val <= resultCursor.next.val)
                {
                    ListNode nextNode = listCursor.next; 
                    listCursor.next = resultCursor.next;
                    resultCursor.next = listCursor;
                    listCursor = nextNode;
                }

                resultCursor = resultCursor.next;
            }
            
            resultCursor = resultHead;
        }

        return resultHead.next;
    }
}