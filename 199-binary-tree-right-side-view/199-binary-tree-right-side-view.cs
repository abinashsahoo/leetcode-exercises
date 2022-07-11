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
    public IList<int> RightSideView(TreeNode root) {        
        var result = new List<int>();
        if (root == null) return result;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            int levelLength = queue.Count;

            for (int i = 0; i < levelLength; i++)
            {
                var node = queue.Dequeue();
                //if right most element
                if(i == 0)
                {                   
                    result.Add(node.val); 
                }

                // Add child nodes in the queue, starting from right
                if (node.right != null)
                {
                     queue.Enqueue(node.right);
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
            }

        }
        
        return result;
    }
}