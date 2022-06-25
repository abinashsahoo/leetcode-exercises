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
    public IList<IList<int>> LevelOrder(TreeNode root) {        
        var result = new List<IList<int>>();
        
        var queue = new Queue<TreeNode>();
        if(root !=null) queue.Enqueue(root); //If root can be null?
        
        while (queue.Count > 0)
        {
            int count = queue.Count; 
            var level = new List<int>();           
            for(int i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                level.Add(node.val);
                
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);                
            }
            
            result.Add(level);
        }
        
        return result;
    }
}