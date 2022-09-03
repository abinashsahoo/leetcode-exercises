//Started from MSD; Compare with my own soln
public class Solution {
    public int[] NumsSameConsecDiff(int n, int k) {
        var result = new List<int>();
        for (int i = 1; i<=9; i++)
        {
            Dfs(n, k, i, result);
        }
        return result.ToArray();
    }
    
    private void Dfs(int n, int k, int num, List<int> result)
    {
        if (n == 1)//No need of digitPosition, n can be used for that
        {
            result.Add(num);
            return;
        }
        
        int lsd = num % 10;
        int nextDigit1 = lsd - k;
        int nextDigit2 = lsd + k;
        
        if (nextDigit1 >= 0)//(digit - k >= 0)
            Dfs(n - 1, k, num * 10 + nextDigit1, result);
        
        if (nextDigit2 <=9 && nextDigit1 != nextDigit2)//Removes duplicated //(digit + k <= 9)
            Dfs(n - 1, k, num * 10 + nextDigit2, result);
    }
}

// Started from LSD
public class Solution1 {
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