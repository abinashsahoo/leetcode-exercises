/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        List<IList<int>> result = new();
        if(root == null)
        {
            return result;
        }
        Queue<Node> queue = new();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            int count = queue.Count;
            List<int> level = new();
            for (int i = 0; i < count; i++)
            {
                var currNode = queue.Dequeue();
                level.Add(currNode.val);
                
                foreach (var node in currNode.children)
                {
                    queue.Enqueue(node);
                }                
            }
            result.Add(level);
        }
        return result;
    }
}