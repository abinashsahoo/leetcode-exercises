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
    public IList<int> PreorderTraversal(TreeNode root) {
        var result = new List<int>();
        PreorderTraversalLocal(root, result);
        return result;
    }
    
    private void PreorderTraversalLocal(TreeNode root, List<int> list) {
        if(root == null) return;
        list.Add(root.val);
        PreorderTraversalLocal(root.left, list);
        PreorderTraversalLocal(root.right, list);
    }
}