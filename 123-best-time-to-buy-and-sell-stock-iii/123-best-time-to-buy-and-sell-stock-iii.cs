
public class Solution {
    public int MaxProfit(int[] prices) {
        int[,,] dp = new int[prices.Length, 3, 2]; //dp states
        ArrayFill(dp, -1); //Time O(2n)
        return MaxProfit(prices, 0, 1, 2, dp);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int k, int[,,] dp) {
        
        if (index == prices.Length)// || k <= 0) // Because I still want to explore other options
            return 0;

        if (dp[index,k,buy] != -1)
            return dp[index,k,buy];
        
        int profit = 0;
        if (buy == 1)
        {
            if (k > 0)
                profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, k - 1, dp), MaxProfit(prices, index + 1, 1, k, dp));
            else
                profit = MaxProfit(prices, index + 1, 1, k, dp);
        }
        else
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, k, dp), MaxProfit(prices, index + 1, 0, k, dp));
        }
        
        return dp[index,k,buy] = profit;
    }
    
    //Time O(2n)
    private void ArrayFill(int[,,] dp, int value)
    {
        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                for (int k = 0; k < dp.GetLength(2); k++)
                {
                    dp[i,j,k] = value;
                }                
            }
        }
    }
}

// TLE
public class Solution1 {
    public int MaxProfit(int[] prices) {
        return MaxProfit(prices, 0, 1, 2);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int k) {
        
        if (index == prices.Length)// || k <= 0) // Because I still want to explore other options
            return 0;
        
        int profit = 0;
        if (buy == 1)
        {
            if (k > 0)
                profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, k - 1), MaxProfit(prices, index + 1, 1, k));
            else
                profit = MaxProfit(prices, index + 1, 1, k);
        }
        else
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, k), MaxProfit(prices, index + 1, 0, k));
        }
        return profit;
    }
}