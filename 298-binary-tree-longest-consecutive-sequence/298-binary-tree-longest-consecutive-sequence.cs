/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int LongestConsecutive(TreeNode root) {
        if (root == null) return 0;
        return Dfs(root, root.val, 0);
    }
    
    private int Dfs(TreeNode root, int prev, int length)
    {
        if (root == null)
            return length;
        
        length = root.val == prev + 1 ? length + 1 : 1;
        
        int length1 = Dfs(root.left, root.val, length);
        int length2 = Dfs(root.right, root.val, length);
        
        return Math.Max(length, Math.Max(length1, length2));
    }
}