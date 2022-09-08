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

public class Solution2 {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new();
        Stack<TreeNode> stack = new();
        
        TreeNode currNode = root;        
        while (currNode != null || stack.Count > 0)
        {
            while (currNode != null)
            {
                stack.Push(currNode);
                currNode = currNode.left;
            }
            
            currNode = stack.Pop();
            result.Add(currNode.val);            
            currNode = currNode.right;            
        }
        return result;
    }
}

public class Solution {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new();
        Stack<TreeNode> stack = new();
        
        TraverseLeft(root, stack);
        
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            result.Add(node.val);            
            TraverseLeft(node.right, stack);
        }
        return result;
    }
    
    private void TraverseLeft(TreeNode node, Stack<TreeNode> stack)
    {
        while (node != null)
        {
            stack.Push(node);
            node = node.left;
        }
    }
}

public class Solution1 {
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> result = new();
        if(root == null)
        {
            return result;
        }
        result.AddRange(InorderTraversal(root.left));
        result.Add(root.val);
        result.AddRange(InorderTraversal(root.right));
        return result;
    }
}