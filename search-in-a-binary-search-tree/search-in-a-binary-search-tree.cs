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
    public TreeNode SearchBST(TreeNode root, int val) {
        if(root == null) 
        {
           return null;
        }
         
        if(root.val == val)
        {
            return root;
        }
        
        var result1 = SearchBST(root.left, val);
        if(result1 != null)
            return result1;
        
        var result2 = SearchBST(root.right, val);
        if(result2 != null) 
            return result2;
        
        return null;
    }
}