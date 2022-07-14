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
    public IList<int> PostorderTraversal(TreeNode root) {
        var result = new List<int>();
        PostorderTraversalLocal(root, result);
        return result;
    }
    
    private void PostorderTraversalLocal(TreeNode root, IList<int> list) {
        if (root == null) return;
        PostorderTraversalLocal(root.left, list);
        PostorderTraversalLocal(root.right, list);
        list.Add(root.val);
    }
}