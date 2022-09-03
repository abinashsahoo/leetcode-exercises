public class Solution {
    public int[] NumsSameConsecDiff(int n, int k) {
        var result = new HashSet<int>();
        for (int i = 0; i<=9; i++)
        {
            Dfs(n, k, i, 0, 0, result);
        }
        return result.ToArray();
    }
    
    private void Dfs(int n, int k, int digit, int digitPosition, int num, HashSet<int> result)
    {
        if (digitPosition == n)
        {
            if (num >= Math.Pow(10, n - 1))
                result.Add(num);
            return;
        }
        
        num = 10 * num + digit;
        
        if (digit - k >= 0)
            Dfs(n, k, digit - k, digitPosition + 1, num, result);
        
        if (digit + k <= 9)
            Dfs(n, k, digit + k, digitPosition + 1, num, result);
    }
}