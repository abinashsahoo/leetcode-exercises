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
    public int GoodNodes(TreeNode root) {
        int result = 0;
        if (root == null) return result;
        
        result += Dfs(root, root.val);
        return result;
    }
    
    private int Dfs(TreeNode root, int currentMax)
    {
        if (root == null)
        {
            return 0;
        }
        
        int count = 0;
        if (root.val >= currentMax)
        {
            currentMax = root.val;
            count++;
        }
        
        count += Dfs(root.left, currentMax);
        count += Dfs(root.right, currentMax);
        
        return count;
    }
}