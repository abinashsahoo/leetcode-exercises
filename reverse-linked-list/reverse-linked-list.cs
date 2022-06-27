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
    public ListNode ReverseList(ListNode head) {
        ListNode prevNode = null;
        ListNode currNode = head;
        
        while (currNode != null)
        {
            // Swap
            var temp = currNode.next;
            currNode.next = prevNode;
            
            //Move Next
            prevNode = currNode;
            currNode = temp;
        }
        
        return prevNode;
    }
}