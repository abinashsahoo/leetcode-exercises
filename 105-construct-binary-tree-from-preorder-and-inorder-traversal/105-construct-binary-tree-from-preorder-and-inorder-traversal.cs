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
//[1,2,3]
//[1,2,3]

//Unique value??

public class Solution {
    int preorderRootIndex = 0;    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(inorder == null || inorder.Length == 0)
        {
            return null;
        }
        if(inorder.Length == 1)
        {
            return new TreeNode { val = inorder[0] };
        }
                
        int root = preorder[preorderRootIndex];
        var node = new TreeNode { val = root };
        
        var left = new List<int>();
        var right = new List<int>();
        
        bool split = false;
        for (int i = 0; i < inorder.Length; i++)
        {
            if (inorder[i] == root)
            {
                split = true;
            }
            else if(!split)
            {
                left.Add(inorder[i]);
            }
            else
            {
                right.Add(inorder[i]);
            }
        }
        
        if (left.Count > 0)
            ++preorderRootIndex;
        node.left = BuildTree(preorder, left.ToArray());
        if (right.Count > 0)
            ++preorderRootIndex;
        node.right = BuildTree(preorder, right.ToArray());
        
        return node;
    }
}