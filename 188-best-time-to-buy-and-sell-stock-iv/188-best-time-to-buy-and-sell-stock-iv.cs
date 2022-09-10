public class Solution {
    public int MaxProfit(int k, int[] prices) {
        var n = prices.Length;
	    if (n <= 0 || k <= 0) 
        {
            return 0;
        }

        if (2 * k  >= n)
        {            
            var result = 0;
            // as many as you can
            for (int i = 1; i < n; i++)
            {
                result += Math.Max(0, prices[i] - prices[i-1]);
            }
            return result;
        }

        var dp = new int[k+1,n];
        for (int i = 1; i <= k; i++)
        {
            var minBuy = prices[0];
            for (int j = 1; j < n; j++)
            {
                // 1. not sell, 2. sell => find the max
                dp[i,j] = Math.Max(dp[i,j-1], prices[j] - minBuy);
                // use the profit dp[i-1,j-1] to buy
                minBuy = Math.Min(minBuy, prices[j] - dp[i-1,j-1]);
            }
        }

        return dp[k, n-1];
    }
}