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
    public IList<int> InorderTraversal(TreeNode root) {
        var result = new List<int>();
        InorderTraversalLocal(root, result);
        return result;
    }
    
    private void InorderTraversalLocal(TreeNode root, IList<int> list) {
        if(root == null) return;
        InorderTraversalLocal(root.left, list);
        list.Add(root.val);
        InorderTraversalLocal(root.right, list);
    }
}