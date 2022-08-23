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
    
    private ListNode frontPointer;
    
    public bool IsPalindrome(ListNode head) 
    {
        frontPointer = head;
        return RecursivelyCheck(head);
    }
    
    private bool RecursivelyCheck(ListNode currentNode)
    {        
        if(currentNode != null)
        {
            if (!RecursivelyCheck(currentNode.next)) return false;
            if (currentNode.val != frontPointer.val) return false;
            frontPointer = frontPointer.next;
        }
        return true;
    }
}