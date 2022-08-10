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
//Tric to avoid dictionary key sorting
public class Solution {
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var result = new List<IList<int>>();        
        if (root == null) return result; // Needed this
        
        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 0));
        
        Dictionary<int, IList<int>> dict = new(); 
        int minIndex = 0, maxIndex = 0;
        while (queue.Count() > 0)
        {
            var (node, index) = queue.Dequeue();
            minIndex = Math.Min(minIndex, index);
            maxIndex = Math.Max(maxIndex, index);
            
            if (dict.ContainsKey(index))
            {
                dict[index].Add(node.val);
            }
            else
            {
                dict.Add(index, new List<int>{ node.val });
            }
            
            if (node.left != null)
            {
                queue.Enqueue((node.left, index - 1));                
            }
            if (node.right != null)
            {
                queue.Enqueue((node.right, index + 1));                
            }
        }
        
        for (int i = minIndex; i <= maxIndex; i++)
        {
            result.Add(dict[i]);
        }
        return result;
    }
}

// Visualize the 2D matrix and add arrays in the dictionary. Order the dict by index
//Time Complexity: O(NlogN) -> BFS O(N) + Sort O(NlogN) -> only left child node
//Space Complexity: O(N) for dict + BFS queue
public class Solution1 {
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var result = new List<IList<int>>();        
        if (root == null) return result; // Needed this
        
        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 0));
        
        Dictionary<int, IList<int>> dict = new();        
        while (queue.Count() > 0)
        {
            var (node, index) = queue.Dequeue();
            if (dict.ContainsKey(index))
            {
                dict[index].Add(node.val);
            }
            else
            {
                dict.Add(index, new List<int>{ node.val });
            }
            
            if (node.left != null)
            {
                queue.Enqueue((node.left, index - 1));                
            }
            if (node.right != null)
            {
                queue.Enqueue((node.right, index + 1));                
            }
        }
        
        foreach (var item in dict.OrderBy(d => d.Key))
        {
            result.Add(item.Value);
        }
        return result;
    }
}