// Can we never buy/sell stock not to incur loss? - Yes
// Can we buy and sell on the same day not to incur loss? - Yes
// So profit can't go negative

// TLE
public class Solution {
    public int MaxProfit(int[] prices) {
        int[,] dp = new int[prices.Length,2];
        ArrayFill(dp, -1); //Time O(2n)
        return MaxProfit(prices, 0, 1, dp);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int[,] dp) {
        if (index == prices.Length)
            return 0;
        
        if (dp[index, buy] != -1)
            return dp[index, buy];
        
        int profit = 0;
        if (buy == 1)
        {
            profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, dp), 0 + MaxProfit(prices, index + 1, 1, dp));
        }
        else //sell
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, dp), 0 + MaxProfit(prices, index + 1, 0, dp));
        }
        return dp[index, buy] = profit;
    }
    
    //Time O(2n)
    private void ArrayFill(int[,] dp, int value)
    {
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                dp[i,j] = value;
            }
        }
    }
}

// TLE - Explore all options: 
//Time: O(2^n)
//Space: Stack O(n)
public class Solution1 {
    public int MaxProfit(int[] prices) {
        return MaxProfit(prices, 0, 1);
    }
    
    private int MaxProfit(int[] prices, int index, int buy) {
        if (index == prices.Length)
            return 0;
        
        int profit = 0;
        if (buy == 1)
        {
            profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0), 0 + MaxProfit(prices, index + 1, 1));
        }
        else //sell
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1), 0 + MaxProfit(prices, index + 1, 0));
        }
        return profit;
    }
}