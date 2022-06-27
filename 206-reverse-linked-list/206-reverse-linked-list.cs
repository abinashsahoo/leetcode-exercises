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
    
    public ListNode ReverseList(ListNode head) 
    {
        return ReverseListLocal(head, null);
    }

    private ListNode ReverseListLocal(ListNode head, ListNode newHead) 
    {
        if (head == null)
            return newHead;
        
        ListNode next = head.next;
        head.next = newHead;
        return ReverseListLocal(next, head);
    }
    
    public ListNode ReverseList1(ListNode head) {
        Console.WriteLine($"1. head = {head.val}");
        if(head == null || head.next == null) return head;
        
        Console.WriteLine($"2. head = {head.val}");
        var node = ReverseList1(head.next);   
        Console.WriteLine($"node = {node.val}; head = {head?.val};head.next.next = {head?.next?.next?.val};head.next = {head?.next?.val}");
        head.next.next = head;
        head.next=null;
        return node;
    }
    
    public ListNode ReverseListIterative(ListNode head) {
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