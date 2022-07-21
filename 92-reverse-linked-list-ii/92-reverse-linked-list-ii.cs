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
    public ListNode ReverseBetween(ListNode head, int left, int right) {        
        var rightNext = Find(head, right + 1);
        var previousNode = Find(head, left - 1);
        
        var newHead = rightNext;
        var currentNode = previousNode == null ? head : previousNode.next;  
        
        while(currentNode != rightNext) {
            var next = currentNode.next;
            currentNode.next = newHead;
            newHead = currentNode;
            currentNode = next;
        }
        
        if(previousNode != null) {            
            previousNode.next = newHead;
        }
        else {
            head = newHead;            
        }
        
        return head;
    }
    
    public ListNode Find(ListNode head, int position) {
        if(position < 1) return null;
        var result = head;
        for(int i = 1; i < position; i++) {
            result = result.next;
            if(result == null)
                return result;
        }
        return result;
    }
}

public class Solution1 {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
        if (head == null) {
            return null;
        }
        
        ListNode current = head;
        ListNode prev = null;
        while (left > 1) {
            prev = current;
            current = current.next;
            left--;
            right--;
        }
        
        ListNode con = prev;
        ListNode tail = current;
       
        while (right > 0) {
            var temp = current.next;            
            current.next = prev;
            prev = current;
            current = temp;
            
            right--;
        }
        
        if (con != null) {
            con.next = prev;
        }
        else {
            head = prev;
        }
        
        tail.next = current;
        return head;
    }
}