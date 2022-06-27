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
        
        ListNode dummy = new ListNode(-1);
        dummy.next = head;
        
        ListNode prevNode = dummy;
        
        while(head != null && head.next != null)
        {        
            prevNode.next = head.next;
            head.next = prevNode.next.next;
            prevNode.next.next = head;
            
            prevNode = head;
            head = head.next;
        }
        
        return dummy.next;
    }
    
    public ListNode SwapPairs1(ListNode head) {
        if(head == null || head.next == null) 
        {
            return head;
        }
        
        var temp = head.next;
        head.next = temp.next;
        temp.next = head;
        head = temp;
        
        head.next.next = SwapPairs1(head.next.next);
        
        return head;
    }
}