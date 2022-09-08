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

// public class Solution {
//     public IList<int> InorderTraversal(TreeNode root) {
//         List<int> result = new();
//         if(root == null)
//         {
//             return result;
//         }
//         Stack<TreeNode> stack = new();
//         stack.Push(root);
        
//         while (stack.Count > 0)
//         {
//             var node = stack.Pop();
            
//             if (node.left != null)
//             {
//                 stack.Push(node.left);
//             }
            
            
//             if (node.right != null)
//             {
//                 stack.Push(node.right);
//             }
//             result.Add(node.val);
//         }
//         return result;
//     }
// }