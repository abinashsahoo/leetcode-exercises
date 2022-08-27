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
    // Using PostOrder traversal Approach
    public int LongestConsecutive(TreeNode root) {
        // if (root == null) return 0;
        int maxSortedLen = 0;
        BinaryTreeLongestConsecutiveSequence(root, ref maxSortedLen);
        return maxSortedLen;
    }
    
    // Time O(n) || Space O(1)
    public int[] BinaryTreeLongestConsecutiveSequence(TreeNode root, ref int maxSortedLen)
    {
        if (root == null) return new int[2];
        int asc = 1, desc = 1;
        var ltSubTreeMaxLen = BinaryTreeLongestConsecutiveSequence(root.left, ref maxSortedLen);
        var rtSubTreeMaxLen = BinaryTreeLongestConsecutiveSequence(root.right, ref maxSortedLen);

        // if left is not null and absolute diff is 1
        if (root.left != null && Math.Abs(root.left.val - root.val) == 1)
        {
            // if Ascending order
            if (root.left.val - 1 == root.val) asc += ltSubTreeMaxLen[0];
            // if Descending order
            else desc += ltSubTreeMaxLen[1];
        }
        // if right is not null and absolute diff is 1
        if (root.right != null && Math.Abs(root.right.val - root.val) == 1)
        {
            // if Ascending order, and length greater than Ascending order length from left subtree
            if (root.right.val - 1 == root.val) asc = Math.Max(asc, 1 + rtSubTreeMaxLen[0]);
            // if Descending order, and length greater than Descending order length from left subtree
            else desc = Math.Max(desc, 1 + rtSubTreeMaxLen[1]);
        }

        // Update result if longer sequence found in either left-subtree or right-subtree
        // or sequence coming from left-subtree and passing thru root and going into right-subtree
        maxSortedLen = Math.Max(maxSortedLen, asc + desc - 1);

        // return Max Ascending & Descending sequence length possible from current Node
        return new int[] { asc, desc };
    }
}