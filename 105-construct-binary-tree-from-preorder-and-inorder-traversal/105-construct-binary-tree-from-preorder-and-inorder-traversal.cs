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
//[1,2,3]
//[1,2,3]

//Unique value??

public class Solution {
    int preorderRootIndex = 0;    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {        
        return BuildTree(preorder, inorder, 0, inorder.Length - 1);
    }
    
    private TreeNode BuildTree(int[] preorder, int[] inorder, int leftIndex, int rightIndex) {
        if(leftIndex > rightIndex)
        {
            return null;
        }
                
        int root = preorder[preorderRootIndex];
        var node = new TreeNode { val = root };
        
        int rootIndex = -1;
        for (int i = leftIndex; i <= rightIndex; i++)
        {
            if (inorder[i] == root)
            {
                rootIndex = i;
            }
        }
        
        //Console.WriteLine($"Left: {leftIndex} to {rootIndex - 1}");
        if (leftIndex <= rootIndex - 1)
            ++preorderRootIndex;
        node.left = BuildTree(preorder, inorder, leftIndex, rootIndex - 1);
        
        //Console.WriteLine($"Right: {rootIndex + 1} to {rightIndex}");
        if (rootIndex + 1 <= rightIndex)
            ++preorderRootIndex;
        node.right = BuildTree(preorder, inorder, rootIndex + 1, rightIndex);
        
        return node;
    }
}

public class Solution2 {
    public TreeNode BuildTree(int[] preorder, int[] inorder) {        
        return BuildTree(preorder, inorder, 0, 0, inorder.Length - 1);
    }
    
    private TreeNode BuildTree(int[] preorder, int[] inorder, int preorderStart, int inorderStart, int inorderEnd) {
        if(inorderStart > inorderEnd)
        {
            return null;
        }
                
        int root = preorder[preorderStart];
        var node = new TreeNode { val = root };
        
        int rootIndex = -1;
        for (int i = inorderStart; i <= inorderEnd; i++)
        {
            if (inorder[i] == root)
            {
                rootIndex = i;
            }
        }
        
        node.left = BuildTree(preorder, inorder, preorderStart + 1, inorderStart, rootIndex - 1);
        node.right = BuildTree(preorder, inorder, preorderStart + rootIndex - inorderStart + 1, rootIndex + 1, inorderEnd);//NOTE: How to calculate preorderStart
        
        return node;
    }
}

public class Solution1 {
    int preorderRootIndex = 0;    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if(inorder == null || inorder.Length == 0)
        {
            return null;
        }
        if(inorder.Length == 1)
        {
            return new TreeNode { val = inorder[0] };
        }
                
        int root = preorder[preorderRootIndex];
        var node = new TreeNode { val = root };
        
        var left = new List<int>();
        var right = new List<int>();
        
        bool split = false;
        for (int i = 0; i < inorder.Length; i++)
        {
            if (inorder[i] == root)
            {
                split = true;
            }
            else if(!split)
            {
                left.Add(inorder[i]);
            }
            else
            {
                right.Add(inorder[i]);
            }
        }
        
        if (left.Count > 0)
            ++preorderRootIndex; // Passing it a param did not work because this has to linearly increase while left calling left recursively and pass the increased value to right recursives
        node.left = BuildTree(preorder, left.ToArray());
        if (right.Count > 0)
            ++preorderRootIndex;
        node.right = BuildTree(preorder, right.ToArray());
        
        return node;
    }
}