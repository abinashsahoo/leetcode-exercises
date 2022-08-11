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
//https://leetcode.com/problems/validate-binary-search-tree/discuss/32112/Learn-one-iterative-inorder-traversal-apply-it-to-multiple-tree-questions-(Java-Solution)
//Iterative InOrder
public class Solution {
    public bool IsValidBST(TreeNode root) 
    {
       if (root == null) return true;
       var stack = new Stack<TreeNode>();
       TreeNode pre = null;
       while (root != null || stack.Count > 0) 
       {
          while (root != null) 
          {
             stack.Push(root);
             root = root.left;
          }
          root = stack.Pop();
          if(pre != null && root.val <= pre.val) 
          {
              return false;
          }
          pre = root;
          root = root.right;
       }
       return true;
    }
}

public class Solution5 {
    int? prevNumber = null; //NOTE: If it was passed in recursively, did not work ex, [1, 1]
    public bool IsValidBST(TreeNode root) { 
        return TraverseInOrder(root);
    }
    
    public bool TraverseInOrder(TreeNode root) {
        if (root == null) 
        {
            return true;
        }
        
        bool flag = TraverseInOrder(root.left);
        if (prevNumber >= root.val) 
        {
            flag = false;
        }
        else
        {
            prevNumber = root.val;
        }
        
        return flag && TraverseInOrder(root.right);
    }
}

//InOrder and check if the array is sorted
public class Solution4 {
    public bool IsValidBST(TreeNode root) {
        if (root == null) 
        {
            return true;
        }
        
        var list = new List<int>();      
        TraverseInOrder(root, list);
        return IsSorted(list);
    }
    
    public void TraverseInOrder(TreeNode root, IList<int> list) {
        if (root == null) 
        {
            return;
        }
        
        TraverseInOrder(root.left, list);
        list.Add(root.val);
        TraverseInOrder(root.right, list);
    }
    
    private bool IsSorted(IList<int> arr)
    {   
        for (int i = 1; i < arr.Count; i++)
            if (arr[i - 1] >= arr[i]) return false;  
        return true;
        
        // //int prevNumber = list[0]; //Did not work for [1, 1]
        // int? prevNumber = null;
        // foreach (var n in list)
        // {
        //     if (prevNumber >= n) return false;
        //     prevNumber = n;
        // }
    }  
}

//Did not work for: [120,70,140,50,100,130,160,20,55,75,110,119,135,150,200]
//Worked for this: [3,1,5,0,2,4,6]
public class Solution3 {
    public bool IsValidBST3(TreeNode root) {
        if (root == null) 
        {
            return true;
        }
        
        var isValidBST = root.left == null ? true : root.val > root.left.val;
        isValidBST = isValidBST && (root.right == null ? true : root.val < root.right.val); // NOTE: isValidBST &&        
        return isValidBST && IsValidBSTLeft(root.left, root.val) && IsValidBSTRight(root.right, root.val);
    }
    
    private bool IsValidBSTLeft(TreeNode root, int prevRoot) {
        if (root == null) 
        {
            return true;
        }
        
        var isValidBST = root.left == null ? true : (root.val > root.left.val && prevRoot > root.left.val);
        Console.WriteLine(isValidBST);
        isValidBST = isValidBST && (root.right == null ? true : root.val < root.right.val && prevRoot > root.right.val);   
        return isValidBST && IsValidBSTLeft(root.left, root.val) && IsValidBSTRight(root.right, root.val);
    }
    
    private bool IsValidBSTRight(TreeNode root, int prevRoot) {
        if (root == null) 
        {
            return true;
        }
        
        var isValidBST = root.left == null ? true : (root.val > root.left.val && prevRoot < root.left.val);
        Console.WriteLine(isValidBST);
        isValidBST = isValidBST && (root.right == null ? true : root.val < root.right.val && prevRoot < root.right.val);   
        return isValidBST && IsValidBSTLeft(root.left, root.val) && IsValidBSTRight(root.right, root.val);
    }
}

// Did not work for this Test case: [5,4,6,null,null,3,7]
public class Solution2 {
    public bool IsValidBST(TreeNode root) {
        if (root == null) 
        {
            return true;
        }
        
        var isValidBST = root.left == null ? true : root.val > root.left?.val;
        isValidBST = isValidBST && (root.right == null ? true : root.val < root.right?.val); // NOTE: isValidBST &&  and ()      
        return isValidBST && IsValidBST(root.left) && IsValidBST(root.right);
    }
}

// Did not work for this Test case: [1,2]
public class Solution1 {
    public bool IsValidBST(TreeNode root) {
        if (root == null) 
        {
            return true;
        }
        
        var isValidBST = root.left == null ? true : root.val > root.left?.val;
        isValidBST = root.right == null ? true : root.val < root.right?.val;     
        return isValidBST && IsValidBST(root.left) && IsValidBST(root.right);
    }
}