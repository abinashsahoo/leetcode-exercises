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
    
    public ListNode SwapPairs2(ListNode head) {
        
        var dummy = new ListNode(-1);
        //dummy.next = head;    //Not really needed    
        var prevNode = dummy;
        var currNode = head;
        
        while(currNode != null && currNode.next != null)
        {     
            //Swap Nodes - Approach 1
            prevNode.next = currNode.next;
            currNode.next = currNode.next.next;
            
            //Moving ahead for the next swap
            prevNode = currNode;
            currNode = currNode.next;
        }
        
        return dummy.next;
    }
    
    public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null) 
        {
            return head;
        }
        
        var temp = head.next;
        head.next = SwapPairs(temp.next);
        temp.next = head;
        
        return temp;
    }
}