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
        Stack<(TreeNode, int)> stack = new();
        stack.Push((root, root.val));
        
        while (stack.Count > 0)
        {
            var (currNode, currMax) = stack.Pop();
            if (currNode.val >= currMax)
            {
                result++;
                currMax = currNode.val;
            }
            
            if (currNode.left != null)
                stack.Push((currNode.left, currMax));
            
            if (currNode.right != null)
                stack.Push((currNode.right, currMax));
        }
        
        return result;
    }
}

public class Solution1 {
    public int GoodNodes(TreeNode root) {
        return Dfs(root, root.val);
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