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
    public string Tree2str(TreeNode root) {
        StringBuilder sb = new();
        Dfs(root, sb);
        return sb.ToString();
    }
    
    private void Dfs(TreeNode root, StringBuilder sb)
    {
        if (root == null)
            return;
        
        if (root.left == null && root.right == null)
        {
            sb.Append(root.val);
            return;
        }
        
        sb.Append(root.val);
        
        sb.Append("(");
        Dfs(root.left, sb);
        sb.Append(")");
             
        if (root.right != null)
        {            
            sb.Append("(");
            Dfs(root.right, sb);
            sb.Append(")");
        }
    }
}

// Looks complex?
public class Solution2 {
    public string Tree2str(TreeNode root) {
        StringBuilder sb = new();
        Dfs(root, sb);
        return sb.ToString();
    }
    
    private void Dfs(TreeNode root, StringBuilder sb)
    {
        if (root == null)
            return;
        
        sb.Append(root.val);

        if (root.left != null || root.right != null)
        {
            sb.Append("(");
            Dfs(root.left, sb);
            sb.Append(")");
        }
        
        if (root.right != null)
        {            
            sb.Append("(");
            Dfs(root.right, sb);
            sb.Append(")");
        }
    }
}
public class Solution1 {
    public string Tree2str(TreeNode root) {
        StringBuilder sb = new();
        Dfs(root, sb);
        return sb.ToString();
    }
    
    private void Dfs(TreeNode root, StringBuilder sb)
    {
        if (root == null)
            return;
        sb.Append(root.val);
        if (root.left != null && root.right != null)
        {
            sb.Append("(");
            Dfs(root.left, sb);
            sb.Append(")");
            
            sb.Append("(");
            Dfs(root.right, sb);
            sb.Append(")");
        }
        else if (root.left != null && root.right == null)
        {
            sb.Append("(");
            Dfs(root.left, sb);
            sb.Append(")");
        }
        else if (root.left == null && root.right != null)
        {
            sb.Append("(");
            sb.Append(")");
            
            sb.Append("(");
            Dfs(root.right, sb);
            sb.Append(")");
        }
    }
}