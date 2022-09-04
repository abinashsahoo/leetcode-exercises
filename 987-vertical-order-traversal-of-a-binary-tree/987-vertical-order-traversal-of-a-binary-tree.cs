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
//TC: [1,2,3,4,6,5,7] -> List Sort (same row/column)
public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        List<(int, int, int)> list = new();
        Dfs(root, 0, 0, list);
        
        //sort the list globally, according to the coordinates (column -> row -> val)
        list.Sort();
        
        // Group by column index
        List<IList<int>> result = new();
        int currColIndex = int.MinValue;
        List<int> currentColumn = null;
        foreach(var (column, row, val) in list)
        {
            if (column == currColIndex)
            {
                currentColumn.Add(val);
            }
            else //end of a column, and start the next column
            {
                if (currColIndex != int.MinValue)
                    result.Add(currentColumn);
                
                currColIndex = column;
                currentColumn = new List<int> { val };               
            }
        }        
        // Add the very last column //NOTE
        result.Add(currentColumn);
        
        return result;
    }    
    
    //Pre-Order DFS
    private void Dfs(TreeNode root, int column, int row, List<(int, int, int)> list)
    {
        if (root == null) return;
        list.Add((column, row, root.val));       
        Dfs(root.left, column - 1, row + 1, list);
        Dfs(root.right, column + 1, row + 1, list);
    }
}