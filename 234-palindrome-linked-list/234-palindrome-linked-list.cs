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
    public bool IsPalindrome(ListNode head) 
    {
        if (head == null) return true;
        
        ListNode firstHalfEnd = GetFirstHalfEnd(head);
        ListNode secondHalfStart = ReverseList(firstHalfEnd.next);
        
        ListNode p1 = head;
        ListNode p2 = secondHalfStart;
        
        // Check palindrome
        bool result = true;
        while (p2 != null)
        {
            if (p1.val != p2.val)
            {
                result = false;
                break;
            }
            
            p1 = p1.next;
            p2 = p2.next;
        }
        
        // Restore the list
        firstHalfEnd.next = ReverseList(secondHalfStart);        
        return result;
    }
    
    private ListNode GetFirstHalfEnd(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        
        //while (fast.next != null && fast.next.next != null)
        while (fast.next?.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        return slow;
    }
    
    private ListNode ReverseList(ListNode head)
    {        
        ListNode prev = null;
        ListNode curr = head;
        
        while (curr != null)
        {
            ListNode temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }
        return prev;        
    }
}

public class Solution1 {
    
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