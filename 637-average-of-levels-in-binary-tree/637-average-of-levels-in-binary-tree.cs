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
    public IList<double> AverageOfLevels(TreeNode root) {
        var result = new List<double>();
        if (root == null) return result;
        
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            int size = queue.Count;
            double sum = 0;
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;
                
                if(node.left != null) 
                    queue.Enqueue(node.left);
                if(node.right != null) 
                    queue.Enqueue(node.right);  
            }
            result.Add(sum/size);
        }
        return result;
    }
}