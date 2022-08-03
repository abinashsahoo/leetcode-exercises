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
    public IList<IList<int>> FindLeaves(TreeNode root) {
        var answer = new List<IList<int>>();
        GetHeight(root, answer);
        return answer;
    }
    
    private int GetHeight(TreeNode root, List<IList<int>> answer)
    {
        if (root == null)
        {
            return -1; // Important because 1 would get added
        }
        
        var height = 1 + Math.Max(GetHeight(root.left, answer), GetHeight(root.right, answer));
        if (answer.Count <= height)
        {
            answer.Add(new List<int>());
        }
        answer[height].Add(root.val);
        return height;
    }
}

//TestCase: [37,-34,-48,null,-100,-100,48,null,null,null,null,-54,null,-71,-22,null,null,null,8]
//NOTE: Here -100 is there multiple times
//did not work because use of dict and duplicates
public class Solution1 {
    public IList<IList<int>> FindLeaves(TreeNode root) {
        var answer = new List<IList<int>>();
        var dict = new Dictionary<int, int>();
        GetHeight(root, dict, answer);
        return answer;
    }
    
    private int GetHeight(TreeNode root, Dictionary<int, int> dict, List<IList<int>> answer)
    {
        if (root == null)
        {
            return -1; // Important because 1 would get added
        }
        
        if (dict.ContainsKey(root.val)) return dict[root.val];
        var height = 1 + Math.Max(GetHeight(root.left, dict, answer), GetHeight(root.right, dict, answer));
        dict[root.val] = height;
        if (answer.Count <= height)
        {
            answer.Add(new List<int>());
        }
        answer[height].Add(root.val);
        return height;
    }
}