public class Solution {
    public int UniquePaths(int m, int n) {
        var dict = new Dictionary<(int, int), int>();
        return UniquePaths(m, n, 0, 0, dict);
    }
    
    private int UniquePaths(int m, int n, int i, int j, Dictionary<(int, int), int> dict) {
        if (i == m - 1 && j == n - 1) return 1;        
        if (i >= m || j >= n) return 0;
        
        if (dict.ContainsKey((i, j))) return dict[(i, j)];
        
        int right = UniquePaths(m, n, i, j + 1, dict);
        int bottom = UniquePaths(m, n, i + 1, j, dict); 
        dict[(i, j)] =  right + bottom;
        return right + bottom;
    }    
}

// TLE for 19, 15
public class Solution1 {
    public int UniquePaths(int m, int n) {
        return UniquePaths(m, n, 0, 0);
    }
    
    private int UniquePaths(int m, int n, int i, int j) {
        if (i == m - 1 && j == n - 1) return 1;        
        if (i >= m || j >= n) return 0;
        
        int right = UniquePaths(m, n, i, j + 1);
        int bottom = UniquePaths(m, n, i + 1, j); 
        return right + bottom;
    }    
}