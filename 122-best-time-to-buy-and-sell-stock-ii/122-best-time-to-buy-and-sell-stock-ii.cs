// Can we never buy/sell stock not to incur loss? - Yes
// Can we buy and sell on the same day not to incur loss? - Yes
// So profit can't go negative

// Greedy Solution
// Check out: https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/discuss/2556523/Faster-than-98C%2B%2BGreedyVery-Easy-to-understand
class SolutionGreedy {
    
    public int MaxProfit1(int[] prices) {
        int minPrice = int.MaxValue, profit = 0;
        for(int i = 0; i < prices.Length; i++) 
        {
            if (prices[i] > minPrice) 
            {
                profit += prices[i] - minPrice; 
            }
                       
            minPrice = prices[i];
        }
        return profit;
    }
    
    public int MaxProfit2(int[] prices) {
        int maxprofit = 0;
        for (int i = 1; i < prices.Length; i++) {
            if (prices[i] > prices[i - 1])
                maxprofit += prices[i] - prices[i - 1];
        }
        return maxprofit;
    }
}

public class Solution {
    
    public int MaxProfit(int[] prices) {
        var dpAhead = new int[2];
        dpAhead[0] = 0; //Not Buy state; stores the max profit
        dpAhead[1] = 0; //Buy state; stores the max profit
        var dpCurrent = new int[2];
        for (int i = prices.Length - 1; i >= 0; i--)
        {
            // if (buy == 1) //allowed to buy
            // {
            //     profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, dp), 0 + MaxProfit(prices, index + 1, 1, dp));
            // }
            // else //allowed to sell
            // {
            //     profit = Math.Max(prices[i] + MaxProfit(prices, index + 1, 1, dp), 0 + MaxProfit(prices, index + 1, 0, dp));
            // }
            dpCurrent[0] = Math.Max(dpAhead[0], dpAhead[1] + prices[i]); 
            dpCurrent[1] = Math.Max(dpAhead[1], dpAhead[0] - prices[i]);
            
            dpAhead = dpCurrent;
        }
            
        return dpCurrent[1];
    }
    
    public int MaxProfit1(int[] prices) {
        var dp = new int[2];
        dp[0] = 0; //Not Buy state; stores the max profit
        dp[1] = Int32.MinValue; //Buy state; stores the max profit
        foreach (int price in prices)
        {
            dp[0] = Math.Max(dp[0], dp[1] + price); 
            dp[1] = Math.Max(dp[1], dp[0] - price);
        }
            
        return dp[0];
    }
    
    // public int MaxProfit(int[] prices) {
    //     var dp = new int[2]{0, Int32.MinValue};
    //     foreach (int price in prices)
    //         dp = new int[2] {Math.Max(dp[0], dp[1] + price), Math.Max(dp[1], dp[0] - price)};
    //     return dp[0];
    // }
}

// Memoization
// Time: O(2n)
// Space: O(2n) + Stack O(n)
public class Solution2 {
    
    public int MaxProfit(int[] prices) {
        int[,] dp = new int[prices.Length,2]; //dp states
        ArrayFill(dp, -1); //Time O(2n)
        return MaxProfit(prices, 0, 1, dp);
    }
    
    private int MaxProfit(int[] prices, int index, int buy, int[,] dp) {
        if (index == prices.Length)
            return 0;
        
        if (dp[index, buy] != -1)
            return dp[index, buy];
        
        int profit = 0;
        if (buy == 1) //allowed to buy
        {
            profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0, dp), 0 + MaxProfit(prices, index + 1, 1, dp));
        }
        else //allowed to sell
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
        if (buy == 1)//allowed to buy
        {
            profit = Math.Max(-prices[index] + MaxProfit(prices, index + 1, 0), 0 + MaxProfit(prices, index + 1, 1));
        }
        else //allowed to sell
        {
            profit = Math.Max(prices[index] + MaxProfit(prices, index + 1, 1), 0 + MaxProfit(prices, index + 1, 0));
        }
        return profit;
    }
}