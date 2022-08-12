/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        while (root != null)
        {
            if (p.val > root.val &&  q.val > root.val)
            {
                root = root.right;
            }
            else if (p.val < root.val &&  q.val < root.val)
            {
                root = root.left;
            }
            else
            {
                return root;
            }            
        }
        
        return null;
    }
}

//Question: What if p or q are not a node of the Tree? This problem assumes both of them are tree's node
//This is for any binary tree
public class Solution1 {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        Console.WriteLine($"root = {root?.val}, p = {p?.val}, q = {q?.val}");
        if (root == null)
        {
            return null;
        }
        
        if (root.val == p.val || root.val == q.val)
        {
            return root;
        }
        
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        
        Console.WriteLine($"HERE --> root = {root.val}, left = {left?.val}, right = {right?.val}");
        
        if (left == null) return right;
        if (right == null) return left;
        
        return root;
    }
}