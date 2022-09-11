public class Solution3 {
    
    public int MaxProfit1(int[] prices) {
        var dpAhead = new int[2];
        dpAhead[0] = 0; //Not Buy state; stores the max profit
        dpAhead[1] = 0; //Buy state; stores the max profit
        var dpCurrent = new int[2];
        for (int i = prices.Length - 1; i >= 0; i--)
        {
            dpCurrent[0] = Math.Max(dpAhead[0], dpAhead[1] + prices[i]); 
            dpCurrent[1] = Math.Max(dpAhead[1], dpAhead[0] - prices[i]);
            
            dpAhead = dpCurrent;
        }
            
        return dpCurrent[1];
    }
}

//Memoization - Reduce tran count on sell
public class Solution {
    public int MaxProfit(int[] prices) {
        int[,,] dp = new int[prices.Length, 3, 2]; //dp states
        ArrayFill(dp, -1); //Time O(2n)
        return MaxProfit(prices, 0, 1, 2, dp);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int k, int[,,] dp) {
        
        if (index == prices.Length || k <= 0) // NOTE: I need to add the condition here, because no more options available!
            return 0;

        if (dp[index,k,buy] != -1)
            return dp[index,k,buy];
        
        int profit = 0;
        if (buy == 1)
        {
            profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, k, dp), MaxProfit(prices, index + 1, 1, k, dp));
        }
        else
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1, k - 1, dp), MaxProfit(prices, index + 1, 0, k, dp));
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

//Memoization
public class Solution2 {
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