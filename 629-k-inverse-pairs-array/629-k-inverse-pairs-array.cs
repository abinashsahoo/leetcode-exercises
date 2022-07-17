public class Solution {    
    public int KInversePairs(int n, int k) 
    {        
        const int MOD = (int)1e9 + 7;
        int[][] dp = CreateDpArray(n, k);
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                if (j == 0)
                {
                    dp[i][j] = 1;
                }
                else
                {
                    int val = (dp[i - 1][j] + MOD - ((j - i) >=0 ? dp[i - 1][j - i] : 0)) % MOD;
                    dp[i][j] = (dp[i][j - 1] + val) % MOD;
                }
            }
        }
        return ((dp[n][k] + MOD - (k > 0 ? dp[n][k - 1] : 0)) % MOD);
    }
    
    private int[][] CreateDpArray(int n, int k)
    {
        int[][] memo = new int[n + 1][];
        for (int i = 0; i <= n; i++) //Can't use foreach here; i <= n
        {
            memo[i] = new int[k + 1];
            //Array.Fill(memo[i], -1);
        }
        return memo;
    }
}

public class Solution1 {
    const int MOD = (int)1e9 + 7;    
    public int KInversePairs(int n, int k) 
    {
        int[][] memo = CreateMemoizationArray(n, k);
        return KInversePairs(n, k, memo);
    }
    
    private int KInversePairs(int n, int k, int[][] memo) 
    {        
        if (n == 0)
            return 0;
        if (k == 0)
            return 1;
        if(memo[n][k] != -1)
        {
            return memo[n][k];
        }
        
        int inv = 0;
        for (int i = 0; i <= Math.Min(k, n - 1); i++)
        {
            inv = (inv + KInversePairs(n - 1, k - i)) % MOD;
        }
        memo[n][k] = inv;
        return inv;
    }
    
    private int[][] CreateMemoizationArray(int n, int k)
    {
        int[][] memo = new int[n + 1][];
        for (int i = 0; i <= n; i++) //Can't use foreach here; i <= n
        {
            memo[i] = new int[k + 1];
            Array.Fill(memo[i], -1);
        }
        return memo;
    }
}