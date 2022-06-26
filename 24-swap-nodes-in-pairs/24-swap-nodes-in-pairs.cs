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
    public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null) return head;
        
        var temp = head.next;
        head.next = temp.next;
        temp.next = head;
        head = temp;
        
        head.next.next = SwapPairs(head.next.next);
        
        return head;
    }
}