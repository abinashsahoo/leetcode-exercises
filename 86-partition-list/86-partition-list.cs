/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        var newHead = new ListNode();
        var dummy1 = newHead;
        var pointer = new ListNode();
        var dummy2 = pointer;
        
        while (head != null)
        {
            if(head.val < x)
            {
                dummy1.next = head;
                dummy1 = dummy1.next;
                head = head.next;
            }
            else
            {
                dummy2.next = head;
                dummy2 = dummy2.next;
                head = head.next;
            }
        }
        dummy2.next=null;
        dummy1.next = pointer.next;
        return newHead.next;
        
    }
}